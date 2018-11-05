using System;

namespace StorageMaster.Entities.Products
{
    public abstract class Product
    {
        private double price;

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }

                price = value;
            }
        }

        public double Weight { get; set; }

        public Product(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }
    }
}
