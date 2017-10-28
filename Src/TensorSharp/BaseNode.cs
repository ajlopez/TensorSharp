namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class BaseNode<T> : INode<T>
    {
        public T[] Values { get { return this.Evaluate().Values; } }

        public abstract int Rank { get; }

        public abstract int[] Shape { get; }

        public abstract T GetValue(params int[] coordinates);

        public abstract INode<T> Evaluate();
    }
}
