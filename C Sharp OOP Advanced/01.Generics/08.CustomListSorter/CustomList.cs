using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _08.CustomListSorter
{
    public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly List<T> customList;

        public CustomList()
        {
            customList = new List<T>();
        }

        public CustomList(IEnumerable<T> items)
        {
            customList = new List<T>();
        }

        public void Add(T element)
        {
            customList.Add(element);
        }

        public void Remove(int index)
        {
            customList.RemoveAt(index);
        }

        public bool Contains(T element)
        {
            return customList.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            var currecntElement = customList[index1];
            customList[index1] = customList[index2];
            customList[index2] = currecntElement;
        }

        public int CountGreaterThan(T element)
        {
            var count = 0;
            foreach (var item in customList)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public void Max()
        {
            Console.WriteLine(customList.Max());
        }

        public void Min()
        {
            Console.WriteLine(customList.Min());
        }

        public void Print()
        {
            Console.WriteLine(string.Join(Environment.NewLine, customList));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in customList)
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
