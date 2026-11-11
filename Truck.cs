namespace Module1
{
    public class Truck : Transport
    {
        public Truck() : base("Вантажівка") { }

        public override decimal CalculateCost(Order order)
        {
            return 200 + 15 * (decimal)order.DistanceKm + 0.5m * (decimal)order.WeightKg;
        }
    }
}