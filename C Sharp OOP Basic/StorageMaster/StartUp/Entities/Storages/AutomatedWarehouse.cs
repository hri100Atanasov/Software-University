using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int CAPACITY = 1;
        private const int GARAGE_SLOTS = 2;
        private static readonly Vehicle[] defaultVehicles =
        {
            new Truck()
        };
        public AutomatedWarehouse(string name)
            : base(name, capacity: CAPACITY, garageSlots: GARAGE_SLOTS, vehicles: defaultVehicles)
        {
        }
    }
}
