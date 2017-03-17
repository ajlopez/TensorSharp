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
            Tensor<double> result = new Tensor<double>();

            result.SetValue(-tensor.GetValue());

            return result;
        }
    }
}
