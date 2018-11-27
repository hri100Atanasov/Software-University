using System;

namespace Lab
{
    class Program
    {
        public delegate void DelegateToPrint(string stringToPrint);

        static void Main(string[] args)
        {
            var stringToPrint = "Iko";
            DelegateToPrint dp = PrintToConsole1;
            dp += PrintToConsole2;
            dp += PrintToConsole3;
            dp.GetInvocationList();
            dp(stringToPrint);
        }

        private static void PrintToConsole1(string stringToPrint)
        {
            Console.WriteLine("1: "+stringToPrint);
        }

        private static void PrintToConsole2(string stringToPrint)
        {
            Console.WriteLine("2: " + stringToPrint);
        }

        private static void PrintToConsole3(string stringToPrint)
        {
            Console.WriteLine("3: " + stringToPrint);
        }
    }
}
