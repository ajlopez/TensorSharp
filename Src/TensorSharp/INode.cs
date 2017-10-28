namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface INode<T>
    {
        int Rank { get; }

        int[] Shape { get; }

        T[] Values { get; }

        T GetValue(params int[] coordinates);

        INode<T> Evaluate();
    }
}
