namespace TensorSharp.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IUnaryOperation<T, S>
    {
        Tensor<S> Evaluate(Tensor<T> tensor);
    }
}
