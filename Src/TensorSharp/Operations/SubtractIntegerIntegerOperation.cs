namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SubtractIntegerIntegerOperation : IBinaryOperation<int, int, int>
    {
        public Tensor<int> Evaluate(Tensor<int> tensor1, Tensor<int> tensor2)
        {
            Tensor<int> result = new Tensor<int>();

            result.SetValue(tensor1.GetValue() - tensor2.GetValue());

            return result;
        }
    }
}
