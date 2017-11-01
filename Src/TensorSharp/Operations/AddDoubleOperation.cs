namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AddDoubleOperation : BinaryOperation<double>
    {
        public AddDoubleOperation(INode<double> left, INode<double> right)
            : base(left, right)
        {
        }

        public override INode<double> Evaluate()
        {
            double[] leftvalues = this.Left.Values;
            double[] rightvalues = this.Right.Values;
            int l = leftvalues.Length;
            double[] newvalues = new double[l];

            for (int k = 0; k < l; k++)
                newvalues[k] = leftvalues[k] + rightvalues[k];

            return new BaseValueNode<double>(this.Shape, newvalues);
        }
    }
}
