namespace TensorSharp.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class BaseNode<T> : INode<T>
    {
        private INode<T> value;

        public T[] Values
        {
            get
            {
                if (this.value == null)
                    this.value = this.Evaluate();

                return this.value.Values;
            }
        }

        public abstract int Rank { get; }

        public abstract int[] Shape { get; }

        public T GetValue(params int[] coordinates)
        {
            if (this.value == null)
                this.value = this.Evaluate();

            return this.value.GetValue(coordinates);
        }

        public abstract INode<T> Evaluate();
    }
}
