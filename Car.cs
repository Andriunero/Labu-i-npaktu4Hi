namespace Module1
{
    public class Car : Transport
    {
        public Car() : base("Автомобіль") { }

        public override decimal CalculateCost(Order order)
        {
            return 50 + 8 * (decimal)order.DistanceKm + 1 * (decimal)order.WeightKg;
        }
    }
}