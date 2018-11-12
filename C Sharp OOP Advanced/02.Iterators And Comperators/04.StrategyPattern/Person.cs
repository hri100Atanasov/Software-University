using System;
using System.Collections.Generic;
using System.Text;

namespace _04.StrategyPattern
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
