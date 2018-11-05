using StorageMaster.Entities.Products;
using System.Collections.Generic;

namespace StorageMaster.Entities.Storages
{
    public abstract class Storage
    {
        private List<Product> products;

        public IReadOnlyCollection<Product> Products => products.AsReadOnly();

        public string Name { get; set; }
        //Maximum weight of products the storage can handle
        public int Capacity { get; set; }
        public int GarageSlots { get; set; }
    }
}
