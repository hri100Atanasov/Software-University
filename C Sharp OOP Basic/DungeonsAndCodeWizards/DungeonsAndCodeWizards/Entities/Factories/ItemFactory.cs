using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Linq;
using System.Reflection;

namespace DungeonsAndCodeWizards.Entities.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemType)
        {
            var assembly = Assembly.GetExecutingAssembly().GetTypes();
            var type = assembly.FirstOrDefault(t => t.Name == itemType);

            if (type == null)
            {
                throw new ArgumentException($"Invalid item \"{itemType}\"!");
            }

            Item item = (Item)Activator.CreateInstance(type);

            return item;
        }
    }
}
