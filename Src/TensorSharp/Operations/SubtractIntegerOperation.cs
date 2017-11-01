namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SubtractIntegerOperation : BinaryOperation<int>
    {
        public SubtractIntegerOperation(INode<int> left, INode<int> right)
            : base(left, right)
        {
        }

        public override INode<int> Evaluate()
        {
            int[] leftvalues = this.Left.Values;
            int[] rightvalues = this.Right.Values;
            int l = leftvalues.Length;
            int[] newvalues = new int[l];

            for (int k = 0; k < l; k++)
                newvalues[k] = leftvalues[k] - rightvalues[k];

            return new BaseValueNode<int>(this.Shape, newvalues);
        }
    }
}
