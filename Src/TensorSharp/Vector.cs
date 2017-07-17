namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Vector<T>
    {
        private T[] values;
        private int[] shape;

        public Vector(int length)
        {
            this.values = new T[length];
            this.shape = new int[] { length };
        }

        public int Rank { get { return 1; } }

        public int[] Shape { get { return this.shape; } }
    }
}
