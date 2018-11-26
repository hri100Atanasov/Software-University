using System;
using System.Collections.Generic;

namespace _04.Iterator
{
   public class ListIterator
    {
        private List<string> strings;
        
        private int index = 0;

        public ListIterator(params string[] strings)
        {
            this.strings = new List<string>(strings);
        }

        public bool Move()
        {
            return ++index < strings.Count;
        }

        public bool HasNext()
        {
            return index + 1 < strings.Count;
        }

        public void Print()
        {
            if (strings.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(strings[index]);
        }
    }
}
