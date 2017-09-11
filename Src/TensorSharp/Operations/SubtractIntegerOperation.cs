namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SubtractIntegerOperation : INode<int>
    {
        private INode<int> left;
        private INode<int> right;
        private int rank;
        private int[] shape;

        public SubtractIntegerOperation(INode<int> left, INode<int> right)
        {
            if (left.Rank == 1 && right.Rank == 1)
                if (left.Shape[0] != right.Shape[0])
                    throw new InvalidOperationException();

            if (left.Rank == 2 && right.Rank == 2)
                if (left.Shape[0] != right.Shape[0] || left.Shape[1] != right.Shape[1])
                    throw new InvalidOperationException();

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
            if (this.left.Rank == 1)
            {
                int[] newvalues = new int[this.left.Shape[0]];
                int l = newvalues.Length;

                for (int k = 0; k < l; k++)
                    newvalues[k] = this.left.GetValue(k) - this.right.GetValue(k);

                return new Vector<int>(newvalues);
            }

            if (this.left.Rank == 2)
            {
                int l = this.left.Shape[0];
                int m = this.left.Shape[1];
                int[][] newvalues = new int[l][];

                for (int k = 0; k < l; k++)
                {
                    newvalues[k] = new int[m];

                    for (int j = 0; j < m; j++)
                        newvalues[k][j] = this.left.GetValue(k, j) - this.right.GetValue(k, j);
                }

                return new Matrix<int>(newvalues);
            }

            if (this.left.Rank == 0)
                return new SingleValue<int>(this.left.GetValue() - this.right.GetValue());

            return null;
        }
    }
}
