namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IValue<T>
    {
        int Rank { get; }

        int[] Shape { get; }

        T GetValue(params int[] coordinates);
    }
}
