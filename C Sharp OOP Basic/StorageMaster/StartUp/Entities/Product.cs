using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities
{
    public abstract class Product
    {
        private double price;

        public double Price
        {
            get { return price; }
            set {
                if (value<0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                price = value; }
        }

    }
}
