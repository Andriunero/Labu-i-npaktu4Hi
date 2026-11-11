using System;
using System.Collections.Generic;

namespace Module1
{
    public class DeliveryService
    {
        private readonly List<Transport> _transports = new List<Transport>();
        private readonly List<Order> _activeOrders = new List<Order>();
        private readonly List<Order> _deliveryHistory = new List<Order>();

        public void RegisterTransport(Transport transport)
        {
            _transports.Add(transport);
        }

        public void AddOrder(Order order)
        {
            _activeOrders.Add(order);
        }

        public void ShowCostForOrder(Order order)
        {
            Console.WriteLine($"--- Вартість доставки для замовлення №{order.Id} ({order.Description}, {order.WeightKg} кг, {order.DistanceKm} км) ---");

            bool anyAvailable = false;
            foreach (var transport in _transports)
            {
                if (transport.CanTake(order))
                {
                    decimal cost = transport.CalculateCost(order);
                    Console.WriteLine($" -> {transport.Name}: {cost:F2} грн");
                    anyAvailable = true;
                }
                else
                {
                    Console.WriteLine($" -> {transport.Name}: Не може прийняти (Зайнятий або обмеження)");
                }
            }

            if (!anyAvailable)
            {
                Console.WriteLine("Жоден транспорт не може взяти це замовлення.");
            }
            Console.WriteLine();
        }

        public bool AssignOrder(Order order, Transport transport)
        {
            if (!_transports.Contains(transport))
            {
                Console.WriteLine($"Транспорт {transport.Name} не зареєстрований у службі.");
                return false;
            }

            if (transport.CanTake(order))
            {
                order.AssignedTransport = transport;
                transport.IsBusy = true;
                Console.WriteLine($"Успіх: Замовлення №{order.Id} призначено на {transport.Name}.");
                return true;
            }

            Console.WriteLine($"Помилка: {transport.Name} не може взяти замовлення №{order.Id}.");
            return false;
        }

        public bool CompleteDelivery(Order order, string paymentMethod)
        {
            if (order.AssignedTransport == null)
            {
                Console.WriteLine($"Помилка: Замовлення №{order.Id} не має призначеного транспорту.");
                return false;
            }

            order.IsDelivered = true;
            order.PaymentMethod = paymentMethod;
            order.AssignedTransport.IsBusy = false;

            _activeOrders.Remove(order);
            _deliveryHistory.Add(order);

            Console.WriteLine($"Замовлення №{order.Id} доставлено! Оплата: {paymentMethod}. Транспорт {order.AssignedTransport.Name} знову вільний.");
            return true;
        }

        public void PrintStatus()
        {
            Console.WriteLine("================ АКТИВНІ ЗАМОВЛЕННЯ ================");
            if (_activeOrders.Count == 0)
            {
                Console.WriteLine("Немає активних замовлень.");
            }
            else
            {
                foreach (var order in _activeOrders)
                {
                    string transportName = order.AssignedTransport != null ? order.AssignedTransport.Name : "Не призначено";
                    Console.WriteLine($"Замовлення №{order.Id} | Опис: {order.Description} | Статус: Призначено на {transportName}");
                }
            }

            Console.WriteLine("\n================ ІСТОРІЯ ДОСТАВОК ================");
            if (_deliveryHistory.Count == 0)
            {
                Console.WriteLine("Історія порожня.");
            }
            else
            {
                foreach (var order in _deliveryHistory)
                {
                    decimal cost = order.AssignedTransport.CalculateCost(order);
                    Console.WriteLine($"Замовлення №{order.Id} | Опис: {order.Description} | Транспорт: {order.AssignedTransport.Name} | Вартість: {cost:F2} грн | Оплата: {order.PaymentMethod}");
                }
            }
            Console.WriteLine("===================================================\n");
        }
    }
}