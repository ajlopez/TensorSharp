namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NegateDoubleOperation : IUnaryOperation<double, double>
    {
        public Tensor<double> Evaluate(Tensor<double> tensor)
        {
            double[] values = tensor.GetValues();
            int l = values.Length;
            double[] newvalues = new double[l];

            for (int k = 0; k < l; k++)
                newvalues[k] = -values[k];

            return tensor.CloneWithNewValues(newvalues);
        }
    }
}
