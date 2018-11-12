using System;
using System.Collections.Generic;

namespace _04.StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> nameSort = new SortedSet<Person>(new NameComparer());
            SortedSet<Person> ageSort = new SortedSet<Person>(new AgeComperator());

            var count = int.Parse(Console.ReadLine());
            while (count-->0)
            {
                var line = Console.ReadLine().Split();
                var person = new Person(line[0], int.Parse(line[1]));

                nameSort.Add(person);
                ageSort.Add(person);
            }

            foreach (var person in nameSort)
            {
                Console.WriteLine(person);
            }

            foreach (var perso in ageSort)
            {
                Console.WriteLine(perso);
            }
        }
    }
}
