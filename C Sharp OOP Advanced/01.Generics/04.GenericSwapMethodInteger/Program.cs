using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCount = int.Parse(Console.ReadLine());
            var list = new List<Box<int>>();
            while (inputCount-- > 0)
            {
                var input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
                list.Add(box);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var index1 = indexes[0];
            var index2 = indexes[1];
            var elements = Swap(list, index1, index2);

            foreach (var item in elements)
            {
                Console.WriteLine(item);
            }
        }

        private static List<Box<int>> Swap(List<Box<int>> elements, int index1, int index2)
        {
            var currentElement = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = currentElement;

            return elements;
        }
    }
}
