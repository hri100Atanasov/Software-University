using StorageMaster.Entities.Factories;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storages;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;

namespace StorageMaster.Core
{
    class StorageMaster
    {
        private readonly ProductFactory productFactory;
        private readonly StorageFactory storageFactory;
        private readonly Dictionary<string, Storage> storageRegistry;
        private readonly List<Product> productPool;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            productFactory = new ProductFactory();
            storageFactory = new StorageFactory();

            storageRegistry = new Dictionary<string, Storage>();
            productPool = new List<Product>();
        }

        public string AddProduct(string type, double price)
        {
            var product = productFactory.CreateProduct(type, price);
            productPool.Add(product);

            return $"Added {product.GetType().Name} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = storageFactory.CreateStorage(type, name);
            storageRegistry.Add(type, storage);

            return $"Registered {storage.GetType().Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = storageRegistry[storageName];
            currentVehicle = storage.GetVehicle(garageSlot);

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            foreach (var product in productNames)
            {
                if (!currentVehicle.IsFull)
                {
                    break;
                }


            }


            throw new NotImplementedException();
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            throw new NotImplementedException();
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            throw new NotImplementedException();
        }

        public string GetStorageStatus(string storageName)
        {
            throw new NotImplementedException();
        }

        public string GetSummary()
        {
            throw new NotImplementedException();
        }
    }
}
