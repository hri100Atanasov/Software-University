using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Entities.Vehicles
{
    public abstract class Vehicle
    {
        private List<Product> trunk;

        public IReadOnlyCollection<Product> Trunk => trunk.AsReadOnly();

        public int Capacity { get; set; }

        public bool IsFull => Trunk.Sum(p => p.Weight) >= Capacity;
        public bool IsEmpty => !Trunk.Any();

        protected Vehicle(int capacity)
        {
            Capacity = capacity;
            trunk = new List<Product>();
        }

        public void LoadProduct(Product product)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            trunk.Add(product);
        }

        public Product Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            var product = trunk.Last();
            trunk.RemoveAt(trunk.Count - 1);

            return product;
        }
    }
}
