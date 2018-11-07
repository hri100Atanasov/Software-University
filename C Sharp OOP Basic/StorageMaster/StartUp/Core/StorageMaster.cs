using StorageMaster.Entities.Factories;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storages;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private readonly ProductFactory productFactory;
        private readonly StorageFactory storageFactory;
        private readonly Dictionary<string, Storage> storageRegistry;
        private readonly Dictionary<string, Stack<Product>> productPool;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            productFactory = new ProductFactory();
            storageFactory = new StorageFactory();

            storageRegistry = new Dictionary<string, Storage>();
            productPool = new Dictionary<string, Stack<Product>>();
        }

        public string AddProduct(string type, double price)
        {
            if (!productPool.ContainsKey(type))
            {
                productPool[type] = new Stack<Product>();
            }

            var product = productFactory.CreateProduct(type, price);
            productPool[type].Push(product);

            return $"Added {product.GetType().Name} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = storageFactory.CreateStorage(type, name);
            storageRegistry[storage.Name] = storage;

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = storageRegistry[storageName];
            currentVehicle = storage.GetVehicle(garageSlot);

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            //var loadedProductsCount = 0;
            //foreach (var name in productNames)
            //{
            //    if (this.currentVehicle.IsFull)
            //    {
            //        break;
            //    }

            //    if (!this.productPool.ContainsKey(name) || !this.productPool[name].Any())
            //    {
            //        throw new InvalidOperationException($"{name} is out of stock!");
            //    }

            //    var product = this.productPool[name].Pop();

            //    this.currentVehicle.LoadProduct(product);

            //    loadedProductsCount++;
            //}

            //var totalProductsCount = productNames.Count();
            //return $"Loaded {loadedProductsCount}/{totalProductsCount} products into {this.currentVehicle.GetType().Name}";

            var loadedProductsCount = 0;
            foreach (var productName in productNames)
            {
                if (!currentVehicle.IsFull)
                {
                    break;
                }
                //check the solution without that check.
                if (!productPool.Any() || productPool.ContainsKey(productName))
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                var product = productPool[productName].Pop();
                currentVehicle.LoadProduct(product);
                loadedProductsCount++;

            }
            var productCount = productNames.Count();

            return $"Loaded {loadedProductsCount}/{productCount} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!storageRegistry.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!storageRegistry.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            var sourceStorage = storageRegistry[sourceName];
            var vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            var destinationStorage = storageRegistry[destinationName];
            var destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationStorage.GetType().Name} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = storageRegistry[storageName];
            var vehicle = storage.GetVehicle(garageSlot);
            var productsInVehicle = vehicle.Trunk.Count();
            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storage.Name}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = storageRegistry[storageName];

            var stockInfo = storage.Products
                .GroupBy(p => p.GetType().Name)
                .Select(g =>
                new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
              .OrderByDescending(p => p.Count)
              .ThenBy(p => p.Name)
              .Select(p => $"{p.Name} ({p.Count})")
              .ToArray();

            var productsCapacity = storage.Products.Sum(p => p.Weight);

            var stockFormat = string.Format("Stock ({0}/{1}): [{2}]"
                , productsCapacity
                , storage.Capacity,
                string.Join(", ", stockInfo));

            var garage = storage.Garage.ToArray();
            var vehicleNames = garage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();
            var garageFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));
            return stockFormat + Environment.NewLine + garageFormat;
        }

        public string GetSummary()
        {
            var sortedStorageRegistry = storageRegistry.Values.OrderByDescending(s => s.Products.Sum(p => p.Price)).ToList();

            var sb = new StringBuilder();

            foreach (var storage in sortedStorageRegistry)
            {
                sb.AppendLine($"{storage.Name}:");
                var totalMoney = storage.Products.Sum(p => p.Price);
                sb.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }
    }
}
