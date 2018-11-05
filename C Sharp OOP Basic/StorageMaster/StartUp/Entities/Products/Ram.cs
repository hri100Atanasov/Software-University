namespace StorageMaster.Entities.Products
{
    internal class Ram : Product
    {
        private const double WEIGHT = 0.1;
        public Ram(double price) : base(price, weight: WEIGHT)
        {
        }
    }
}
