namespace TensorSharp.Operations
{
    using TensorSharp.Nodes;

    public abstract class UnaryOperation<T, R> : BaseNode<R>
    {
        private INode<T> node;

        public UnaryOperation(INode<T> node)
        {
            this.node = node;
        }

        public override int Rank { get { return this.node.Rank; } }

        public override int[] Shape { get { return this.node.Shape; } }

        public INode<T> Node { get { return this.node; } }

        public override INode<R> EvaluateValue()
        {
            T[] values = this.Node.Evaluate().Values;
            int l = values.Length;
            R[] newvalues = new R[l];

            this.Calculate(newvalues, values);

            return new BaseValueNode<R>(this.Shape, newvalues);
        }

        public override bool ApplyContext(Context context)
        {
            var app = this.node.ApplyContext(context);

            if (app)
                this.ClearValue();

            return app;
        }

        public abstract void Calculate(R[] newvalues, T[] values);
    }

    public abstract class UnaryOperation<T> : UnaryOperation<T, T>
    {
        public UnaryOperation(INode<T> node)
            : base(node)
        {
        }
    }
}
