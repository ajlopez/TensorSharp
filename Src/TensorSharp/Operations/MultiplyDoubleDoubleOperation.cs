namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MultiplyDoubleDoubleOperation : IBinaryOperation<double, double, double>
    {
        public Tensor<double> Evaluate(Tensor<double> tensor1, Tensor<double> tensor2)
        {
            double[] values1 = tensor1.GetValues();
            int l = values1.Length;

            double value2 = tensor2.GetValue();

            double[] newvalues = new double[l];

            for (int k = 0; k < l; k++)
                newvalues[k] = values1[k] * value2;

            return tensor1.CloneWithNewValues(newvalues);
        }
    }
}
