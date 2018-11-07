namespace StorageMaster.Core
{
    using Entities.Factories;
    using Entities.Products;
    using Entities.Storages;
    using Entities.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StorageMaster
    {
        private readonly Dictionary<string, Storage> storageRegistry;
        private readonly Dictionary<string, Stack<Product>> productsPool;

        private readonly ProductFactory productFactory;
        private readonly StorageFactory storageFactory;

        private Vehicle currentVehicle;

        public StorageMaster()
        {
            productsPool = new Dictionary<string, Stack<Product>>();
            storageRegistry = new Dictionary<string, Storage>();

            productFactory = new ProductFactory();
            storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            if (!productsPool.ContainsKey(type))
            {
                productsPool[type] = new Stack<Product>();
            }

            var product = this.productFactory.CreateProduct(type, price);

            productsPool[type].Push(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);

            storageRegistry[storage.Name] = storage;

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = storageRegistry[storageName];
            var vehicle = storage.GetVehicle(garageSlot);

            currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProductsCount = 0;
            foreach (var name in productNames)
            {
                if (currentVehicle.IsFull)
                {
                    break;
                }

                if (!productsPool.ContainsKey(name) || !productsPool[name].Any())
                {
                    throw new InvalidOperationException($"{name} is out of stock!");
                }

                var product = productsPool[name].Pop();

                currentVehicle.LoadProduct(product);

                loadedProductsCount++;
            }

            var totalProductsCount = productNames.Count();
            return $"Loaded {loadedProductsCount}/{totalProductsCount} products into {currentVehicle.GetType().Name}";
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
            var destinationStorage = storageRegistry[destinationName];

            var vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            var destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationStorage.Name} (slot {destinationGarageSlot})";
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
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToArray();

            var productsCapacity = storage.Products.Sum(p => p.Weight);

            var stockFormat = string.Format("Stock ({0}/{1}): [{2}]",
                productsCapacity,
                storage.Capacity,
                string.Join(", ", stockInfo));

            var garage = storage.Garage.ToArray();
            var vehicleNames = garage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();

            var garageFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));
            return stockFormat + Environment.NewLine + garageFormat;
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            var sortedStorage = storageRegistry.Values
                .OrderByDescending(s => s.Products.Sum(p => p.Price))
                .ToArray();

            foreach (var storage in sortedStorage)
            {
                sb.AppendLine($"{storage.Name}:");
                var totalMoney = storage.Products.Sum(p => p.Price);
                sb.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }
    }
}
