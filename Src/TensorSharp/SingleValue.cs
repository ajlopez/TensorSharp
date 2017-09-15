namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SingleValue<T> : INode<T>
    {
        private static int[] shape = new int[0];
        private T value;

        public SingleValue(T value)
        {
            this.value = value;
        }

        public int Rank { get { return 0; } }

        public int[] Shape { get { return shape; } }

        public T GetValue(params int[] coordinates)
        {
            return this.value;
        }

        public INode<T> Evaluate()
        {
            return this;
        }
    }
}
