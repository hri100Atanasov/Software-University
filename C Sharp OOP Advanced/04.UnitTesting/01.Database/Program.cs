using System;

namespace _01.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var database = new Database();
                var a = database.Fetch();
                Console.WriteLine(a.Length);
                Console.WriteLine(string.Join(" ", a));
                database.Add(null);
                database.Remove();
                var ba = database.Fetch();
                Console.WriteLine(string.Join(" ", ba));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
