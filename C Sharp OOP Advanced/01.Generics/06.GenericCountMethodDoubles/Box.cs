using System;

namespace _06.GenericCountMethodDoubles
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
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
    }
}
