using System;
using System.Collections.Generic;
using System.Text;

namespace _04.StrategyPattern
{
    class AgeComperator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
