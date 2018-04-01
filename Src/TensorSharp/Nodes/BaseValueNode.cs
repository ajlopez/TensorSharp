namespace TensorSharp.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BaseValueNode<T> : INode<T>
    {
        private int[] shape;
        private T[] values;

        public BaseValueNode(int[] shape, T[] values)
        {
            this.shape = shape;
            this.values = values;
        }

        public int[] Shape { get { return this.shape; } }

        public T[] Values { get { return this.values; } }

        public int Rank { get { return this.shape.Length; } }

        public INode<T> Evaluate()
        {
            return this;
        }

        public T GetValue(params int[] coordinates)
        {
            int offset = 0;
            int factor = 1;

            for (int k = 0; k < this.shape.Length; k++)
            {
                offset += coordinates[k] * factor;
                factor *= this.shape[k];
            }

            return this.values[offset];
        }

        public bool ApplyContext(Context context)
        {
            return false;
        }
    }
}
