namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AddIntegerOperation : BinaryOperation<int>
    {
        public AddIntegerOperation(INode<int> left, INode<int> right)
            : base(left, right)
        {
        }

        public override void Calculate(int[] newvalues, int[] leftvalues, int[] rightvalues)
        {
            int l = newvalues.Length;

            for (int k = 0; k < l; k++)
                newvalues[k] = leftvalues[k] + rightvalues[k];
        }
    }
}
