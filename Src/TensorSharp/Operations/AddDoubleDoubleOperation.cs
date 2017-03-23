namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AddDoubleDoubleOperation : IBinaryOperation<double, double, double>
    {
        public Tensor<double> Evaluate(Tensor<double> tensor1, Tensor<double> tensor2)
        {
            double[] values1 = tensor1.GetValues();
            int l = values1.Length;

            double[] values2 = tensor2.GetValues();

            double[] newvalues = new double[l];

            for (int k = 0; k < l; k++)
                newvalues[k] = values1[k] + values2[k];

            return tensor1.CloneWithNewValues(newvalues);
        }
    }
}
