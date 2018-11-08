using System;

namespace _02.GenericInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCount = int.Parse(Console.ReadLine());
            while (inputCount-- > 0)
            {
                var input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}
