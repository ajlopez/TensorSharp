namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Vector<T> : BaseValueNode<T>
    {
        public Vector(int length)
            : base(new int[] { length }, new T[length])
        {
        }

        public Vector(T[] values)
            : base(new int[] { values.Length }, values)
        {
        }
    }
}
