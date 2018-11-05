namespace StorageMaster.Entities.Products
{
    internal class HardDrive : Product
    {
        private const double WEIGHT = 1;
        public HardDrive(double price) : base(price, weight: WEIGHT)
        {
        }
    }
}
