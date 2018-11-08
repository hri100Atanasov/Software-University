using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCount = int.Parse(Console.ReadLine());
            var list = new List<Box<string>>();
            while (inputCount-- > 0)
            {
                var input = Console.ReadLine();
                var box = new Box<string>(input);
                list.Add(box);
            }

            var elementToCompare = Console.ReadLine();
            var result = CountCompare<string>(list, elementToCompare);
            Console.WriteLine(result);
        }

        private static int CountCompare<T>(IEnumerable<Box<T>> list, T elementToCompare) where T:IComparable<T>
        {
            var count = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(elementToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
