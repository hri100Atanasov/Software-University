using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Collection
{
    class ListyIterator<T>:IEnumerable<T>
    {
        private readonly List<T> items;

        private int currentIndex;

        public ListyIterator(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public bool Move()
        {
            if (currentIndex < items.Count - 1)
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

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
