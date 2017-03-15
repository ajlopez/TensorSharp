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
            Tensor<int> result = new Tensor<int>();

            result.SetValue(-tensor.GetValue());

            return result;
        }
    }
}
