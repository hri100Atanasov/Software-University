using StorageMaster.Entities.Storages;
using System;
using System.Linq;
using System.Reflection;

namespace StorageMaster.Entities.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            //switch (type)
            //{
            //    case "AutomatedWarehouse":
            //        return new AutomatedWarehouse(name);
            //    case "DistributionCenter":
            //        return new DistributionCenter(name);
            //    case "Warehouse":
            //        return new Warehouse(name);
            //    default:
            //        throw new InvalidOperationException("Invalid storage type!");
            //}

            //Using reflection
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type storageType = assembly.GetTypes().FirstOrDefault(t => t.Name == type && !t.IsAbstract);
            if (storageType==null&&!typeof(Storage).IsAssignableFrom(storageType))
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            Storage storage = (Storage)Activator.CreateInstance(storageType, name);
            return storage;
        }
    }
}
