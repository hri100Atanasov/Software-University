﻿namespace StorageMaster.Entities.Products
{
    public class Gpu : Product
    {
        private const double WEIGHT = 0.7;
        public Gpu(double price) : base(price, weight: WEIGHT)
        {

        }
    }
}
