using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodStrings
{
    class Box<T> : IComparable<T> where T : IComparable<T>
    {
        private readonly T value;
        public Box(T value)
        {
            this.value = value;
        }

        public int CompareTo(T other)
        {
            return value.CompareTo(other);
        }

        public override string ToString()
        {
            return $"{value.GetType().FullName}: {value}";
        }
    }
}
