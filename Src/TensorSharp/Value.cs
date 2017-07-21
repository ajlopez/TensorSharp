﻿namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Value<T>
    {
        private static int[] shape = new int[0];
        private T value;

        public Value(T value)
        {
            this.value = value;
        }

        public int Rank { get { return 0; } }

        public int[] Shape { get { return shape; } }

        public T GetValue(params int[] coordinates)
        {
            return this.value;
        }
    }
}