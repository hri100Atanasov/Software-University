using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    public abstract class Bag
    {
        private readonly List<Item> items;
        private const int CAPACITY = 100;
        public int Capacity { get; set; }
        public IReadOnlyCollection<Item> Items { get { return items.AsReadOnly(); } }
        public int Load => Items.Sum(i => i.Weight);

        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var item = items.FirstOrDefault(i => i.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            items.Remove(item);

            return item;
        }
    }
}
