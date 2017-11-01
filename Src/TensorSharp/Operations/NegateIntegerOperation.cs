namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NegateIntegerOperation : UnaryOperation<int>
    {
        public NegateIntegerOperation(INode<int> node)
            : base(node)
        {
        }

        public override void Calculate(int[] newvalues, int[] values)
        {
            int l = newvalues.Length;

            for (int k = 0; k < l; k++)
                newvalues[k] = -values[k];
        }
    }
}
