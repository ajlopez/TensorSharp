namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class UnaryOperation<T> : BaseNode<T>
    {
        private INode<T> node;

        public UnaryOperation(INode<T> node)
        {
            this.node = node;
        }

        public override int Rank { get { return this.node.Rank; } }

        public override int[] Shape { get { return this.node.Shape; } }

        public INode<T> Node { get { return this.node; } }

        public override T GetValue(params int[] coordinates)
        {
            throw new NotImplementedException();
        }

        public override INode<T> Evaluate()
        {
            T[] values = this.Node.Values;
            int l = values.Length;
            T[] newvalues = new T[l];

            this.Calculate(newvalues, values);

            return new BaseValueNode<T>(this.Shape, newvalues);
        }

        public abstract void Calculate(T[] newvalues, T[] values);
    }
}
