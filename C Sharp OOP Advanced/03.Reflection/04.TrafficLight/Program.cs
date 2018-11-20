using System;

namespace _04.TrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            var three = 3;
            var input = Console.ReadLine().Split();
            var currentSignal = input[2];
            var count = int.Parse(Console.ReadLine());
            var generatedSignal = new string[3];


            while (three-- > 0)
            {
                var index = 0;
                Console.WriteLine(Enum.GetName(typeof(Signals), currentSignal));
                index++;
            }

            foreach (var item in generatedSignal)
            {
                Console.WriteLine(item);
            }

        }
    }
}
