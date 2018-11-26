using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _04.Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
           var listIterator = new ListIterator("iko", "tiko", "piko");
            FieldInfo fieldInfo = typeof(ListIterator).GetField("strings", BindingFlags.NonPublic | BindingFlags.Instance);
            List<string> a = (List<string>)fieldInfo.GetValue(listIterator);

            Console.WriteLine(string.Join(", ", a));

            var list = new ListIterator();
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var data = input.Split();

                switch (data[0])
                {
                    case "Create":
                        list = new ListIterator(data.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException ane)
                        {
                            Console.WriteLine(ane.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    default:
                        throw new ArgumentNullException();
                }
            }
        }
    }
}
