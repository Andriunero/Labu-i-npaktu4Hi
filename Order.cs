namespace Module1
{
    public class Order
    {
        public int Id { get; }
        public string Description { get; }
        public double WeightKg { get; }
        public double DistanceKm { get; }
        public Transport AssignedTransport { get; set; }
        public bool IsDelivered { get; set; }
        public string PaymentMethod { get; set; }

        public Order(int id, string description, double weightKg, double distanceKm)
        {
            Id = id;
            Description = description;
            WeightKg = weightKg;
            DistanceKm = distanceKm;
            IsDelivered = false;
        }
    }
}