using StorageMaster.Entities.Vehicles;
using System;
using System.Linq;
using System.Reflection;

namespace StorageMaster.Entities.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            //switch (type)
            //{
            //    case "Semi":
            //        return new Semi();
            //    case "Truck":
            //        return new Truck();
            //    case "Van":
            //        return new Van();
            //    default:
            //        throw new InvalidOperationException("Invalid vehicle type!");
            //}

            //Using reflection
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type factoryType = assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Vehicle).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (factoryType == null)
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            Vehicle vehicle = (Vehicle)Activator.CreateInstance(factoryType);
            return vehicle;
        }
    }
}
