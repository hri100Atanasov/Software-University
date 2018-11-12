using System;
using System.Collections.Generic;

namespace _03.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split();
                people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = people[index];

            int equalCounter = 0;

            foreach (var person in people)
            {
                if (personToCompare.CompareTo(person) == 0)
                {
                    equalCounter++;
                }
            }

            var totalPeople = people.Count;

            if (equalCounter > 1)
            {
                Console.WriteLine($"{equalCounter} {totalPeople - equalCounter} {totalPeople}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
