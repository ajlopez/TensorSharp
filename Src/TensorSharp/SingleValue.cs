namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SingleValue<T> : BaseValueNode<T>
    {
        private static int[] shape = new int[0];

        public SingleValue(T value)
            : base(shape, new T[] { value })
        {
        }
    }
}
