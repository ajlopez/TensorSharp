namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Flow
    {
        public static INode<T> Constant<T>(T value)
        {
            return new SingleValue<T>(value);
        }
    }
}
