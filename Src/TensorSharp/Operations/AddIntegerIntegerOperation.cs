namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AddIntegerIntegerOperation : IBinaryOperation<int, int, int>
    {
        public Tensor<int> Evaluate(Tensor<int> tensor1, Tensor<int> tensor2)
        {
            int[] values1 = tensor1.GetValues();
            int l = values1.Length;

            int[] values2 = tensor2.GetValues();

            int[] newvalues = new int[l];

            for (int k = 0; k < l; k++)
                newvalues[k] = values1[k] + values2[k];

            return tensor1.CloneWithNewValues(newvalues);
        }
    }
}
