using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Entities.Storages
{
    public abstract class Storage
    {
        private readonly List<Product> products;
        private readonly Vehicle[] garage;

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(garage);
        public IReadOnlyCollection<Product> Products => products.AsReadOnly();

        public string Name { get; set; }
        //Maximum weight of products the storage can handle
        public int Capacity { get; set; }
        public int GarageSlots { get; set; }
        public bool IsFull => products.Sum(p => p.Weight) >= Capacity;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            products = new List<Product>();
            garage = new Vehicle[garageSlots];

            InitializeGarage(vehicles);
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= garage.Length)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            var vehicle = garage[garageSlot];
            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = GetVehicle(garageSlot);
            if (!deliveryLocation.garage.Any(v => v == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            garage[garageSlot] = null;

            var slotIndex = Array.IndexOf(deliveryLocation.garage, null);

            deliveryLocation.garage[slotIndex] = vehicle;

            return slotIndex;
        }

        public void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            var garageSlot = 0;
            foreach (var vehicle in vehicles)
            {
                garage[garageSlot++] = vehicle;
            }
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var vehicle = GetVehicle(garageSlot);

            var productsUnloadedCount = 0;
            while (!vehicle.IsEmpty && !IsFull)
            {
                var product = vehicle.Unload();
                products.Add(product);
                productsUnloadedCount++;
            }

            return productsUnloadedCount;
        }
    }
}
