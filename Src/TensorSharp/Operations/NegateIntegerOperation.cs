namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NegateIntegerOperation : IUnaryOperation<int, int>
    {
        public Tensor<int> Evaluate(Tensor<int> tensor)
        {
            int[] values = tensor.GetValues();
            int l = values.Length;
            int[] newvalues = new int[l];

            for (int k = 0; k < l; k++)
                newvalues[k] = -values[k];

            return tensor.CloneWithNewValues(newvalues);
        }
    }
}
