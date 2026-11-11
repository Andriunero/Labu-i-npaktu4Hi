using System;

namespace Module1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

          
            var bike = new Bicycle();
            var car = new Car();
            var truck = new Truck();

            var service = new DeliveryService();
            service.RegisterTransport(bike);
            service.RegisterTransport(car);
            service.RegisterTransport(truck);

       
            var order1 = new Order(1, "Документи", 1.5, 5.0); 
            var order2 = new Order(2, "Ноутбук", 3.0, 15.0);   
            var order3 = new Order(3, "Диван", 80.0, 8.0);     

            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);


            service.ShowCostForOrder(order1);
            service.ShowCostForOrder(order2);
            service.ShowCostForOrder(order3);


            Console.WriteLine("--- Призначення замовлень ---");
            service.AssignOrder(order2, bike); 
            service.AssignOrder(order1, bike); 
            service.AssignOrder(order3, bike); 

            service.AssignOrder(order2, car);   
            service.AssignOrder(order3, truck); 
            Console.WriteLine();

            service.PrintStatus();

            Console.WriteLine("--- Виконання доставок ---");
            service.CompleteDelivery(order1, "Картка");
            service.CompleteDelivery(order2, "Готівка");
            Console.WriteLine();

            service.PrintStatus();
        }
    }
}