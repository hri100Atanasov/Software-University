using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GenericInteger
{
    public class Box<T>
    {
        private readonly T value;
        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"{value.GetType().FullName}: {value}";
        }
    }
}
