using StorageMaster.Entities.Products;
using System;
using System.Linq;
using System.Reflection;

namespace StorageMaster.Entities.Factories
{
    class ProductFactory : IProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            //switch (type)
            //{
            //    case "Gpu":
            //        return new Gpu(price);
            //    case "HardDrive":
            //        return new HardDrive(price);
            //    case "Ram":
            //        return new Ram(price);
            //    case "SolidStateDrive":
            //        return new SolidStateDrive(price);
            //    default:
            //        throw new InvalidOperationException("Invalid product type!");
            //}

            //Factory using reflection
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(t => typeof(Product).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (model == null)
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            if (!typeof(Product).IsAssignableFrom(model))
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            try
            {
                Product product = (Product)Activator.CreateInstance(model, price);
                return product;
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }
    }
}
