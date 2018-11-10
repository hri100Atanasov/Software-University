using System;

namespace _08.CustomListSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var customList = new CustomList<string>();

            dynamic input = Console.ReadLine();
            while (input != "END")
            {
                input = input.Split();
                var command = input[0];

                switch (command)
                {
                    case "Add":
                        var element = input[1];
                        customList.Add(element);
                        break;
                    case "Remove":
                        var index = int.Parse(input[1]);
                        customList.Remove(index);
                        break;
                    case "Contains":
                        element = input[1];
                        System.Console.WriteLine(customList.Contains(element));
                        break;
                    case "Swap":
                        index = int.Parse(input[1]);
                        var index2 = int.Parse(input[2]);
                        customList.Swap(index, index2);
                        break;
                    case "Greater":
                        element = input[1];
                        System.Console.WriteLine(customList.CountGreaterThan(element));
                        break;
                    case "Max":
                        customList.Max();
                        break;
                    case "Min":
                        customList.Min();
                        break;
                    case "Sort":
                        CustomListSorter.Sort(ref customList);
                        break;
                    case "Print":
                        customList.Print();
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
