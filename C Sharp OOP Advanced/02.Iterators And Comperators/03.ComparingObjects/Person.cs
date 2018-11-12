using System;

namespace _03.ComparingObjects
{
    class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public int CompareTo(Person other)
        {
            if (Name.CompareTo(other.Name) != 0)
            {
                return 1;
            }

            if (Age.CompareTo(other.Age) != 0)
            {
                return 1;
            }

            return Town.CompareTo(other.Town);
        }
    }
}
