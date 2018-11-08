using System;

namespace _01.GenericBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var boxInt = new Box<int>(123123);
            var boxString = new Box<string>("life in a box");
            Console.WriteLine(boxInt);
            Console.WriteLine(boxString);
        }
    }
}
