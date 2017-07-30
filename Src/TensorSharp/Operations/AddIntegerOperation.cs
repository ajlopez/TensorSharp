namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AddIntegerOperation : INode<int>
    {
        private INode<int> left;
        private INode<int> right;
        private int rank;
        private int[] shape;

        public AddIntegerOperation(INode<int> left, INode<int> right)
        {
            this.left = left;
            this.right = right;
            this.rank = left.Rank;
            this.shape = left.Shape;
        }

        public int Rank { get { return this.rank; } }

        public int[] Shape { get { return this.shape; } }

        public int GetValue(params int[] coordinates)
        {
            throw new NotImplementedException();
        }

        public INode<int> Evaluate()
        {
            return new SingleValue<int>(this.left.GetValue() + this.right.GetValue());
        }
    }
}
