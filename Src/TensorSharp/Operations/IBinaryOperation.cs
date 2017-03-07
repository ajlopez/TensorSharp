namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IBinaryOperation<T, R, S>
    {
        Tensor<S> Evaluate(Tensor<T> tensor1, Tensor<R> tensor2);
    }
}
