﻿using System.Collections.Generic;

namespace _03.GenericSwapMethodString
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
