namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DivideDoubleDoubleOperation : IBinaryOperation<double, double, double>
    {
        public Tensor<double> Evaluate(Tensor<double> tensor1, Tensor<double> tensor2)
        {
            Tensor<double> result = new Tensor<double>();

            result.SetValue(tensor1.GetValue() / tensor2.GetValue());

            return result;
        }
    }
}
