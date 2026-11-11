namespace Module1
{
    public abstract class Transport : IDeliveryCostCalculator
    {
        public string Name { get; protected set; }
        public bool IsBusy { get; set; }

        protected Transport(string name)
        {
            Name = name;
            IsBusy = false;
        }

        public abstract decimal CalculateCost(Order order);

        public virtual bool CanTake(Order order)
        {
            return !IsBusy;
        }
    }
}