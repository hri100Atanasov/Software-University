using System;
using System.Linq;

namespace _02.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listIterator = null;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var arguments = command.Split();
                switch (arguments[0])
                {
                    case "Create":
                        listIterator = new ListyIterator<string>(arguments.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(listIterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            listIterator.Print();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(listIterator.HasNext());
                        break;
                    case "PrintAll":
                        foreach (var item in listIterator)
                        {
                            Console.Write(item + " ");
                        }

                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
