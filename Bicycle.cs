namespace Module1
{
    public class Bicycle : Transport
    {
        public Bicycle() : base("Велосипед") { }

        public override decimal CalculateCost(Order order)
        {
            return 20 + 5 * (decimal)order.DistanceKm;
        }

        public override bool CanTake(Order order)
        {
            return base.CanTake(order) && order.DistanceKm <= 10;
        }
    }
}