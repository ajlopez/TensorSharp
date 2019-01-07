namespace TensorSharp.Operations
{
    using System;
    using System.Linq;
    using TensorSharp.Nodes;

    public abstract class BinaryOperation<T, R> : BaseNode<R>
    {
        private readonly INode<T> left;
        private readonly INode<T> right;
        private readonly int rank;
        private readonly int[] shape;

        public BinaryOperation(INode<T> left, INode<T> right)
        {
            if (!left.Shape.SequenceEqual(right.Shape))
                throw new InvalidOperationException();

            this.left = left;
            this.right = right;
            this.rank = left.Rank;
            this.shape = left.Shape;
        }

        public override int Rank { get { return this.rank; } }

        public override int[] Shape { get { return this.shape; } }

        public INode<T> Left { get { return this.left; } }

        public INode<T> Right { get { return this.right; } }

        public override INode<R> EvaluateValue()
        {
            T[] leftvalues = this.Left.Evaluate().Values;
            T[] rightvalues = this.Right.Evaluate().Values;
            int l = leftvalues.Length;
            R[] newvalues = new R[l];

            this.Calculate(newvalues, leftvalues, rightvalues);

            return new BaseValueNode<R>(this.Shape, newvalues);
        }

        public abstract void Calculate(R[] newvalues, T[] leftvalues, T[] rightvalues);

        public override bool ApplyContext(Context context)
        {
            var lapp = this.left.ApplyContext(context);
            var rapp = this.right.ApplyContext(context);

            var app = lapp || rapp;

            if (app)
                this.ClearValue();

            return app;
        }
    }

    public abstract class BinaryOperation<T> : BinaryOperation<T, T>
    {
        public BinaryOperation(INode<T> left, INode<T> right)
            : base(left, right)
        {
        }
    }
}
