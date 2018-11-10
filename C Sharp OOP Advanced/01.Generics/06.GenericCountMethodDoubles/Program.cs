using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Box<double>>();
            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var input = double.Parse(Console.ReadLine());
                var box = new Box<double>(input);
                list.Add(box);
            }

            var elementToCompare = double.Parse(Console.ReadLine());
            var counter = 0;
            counter = CountCompare(list, elementToCompare);

            Console.WriteLine(counter);
        }

        private static int CountCompare<T>(List<Box<T>> list, T elementToCompare) where T : IComparable<T>
        {
            var counter = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(elementToCompare) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
