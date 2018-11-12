using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    class ListyIterator<T>
    {
        private readonly List<T> items;

        private int currentIndex;

        public ListyIterator(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public bool Move()
        {
            if (currentIndex < items.Count-1)
            {
                currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return currentIndex + 1 < items.Count;
        }

        public void Print()
        {
            if (!items.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(items[currentIndex]);
        }
    }
}
