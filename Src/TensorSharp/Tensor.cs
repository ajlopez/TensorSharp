namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tensor<T>
    {
        private int[] dimensions;

        public Tensor(params int[] dimensions)
        {
            this.dimensions = (int[])dimensions.Clone();
        }

        public int Rank { get { return this.dimensions.Length; } }

        public int GetDimensionLength(int ndim)
        {
            return this.dimensions[ndim];
        }

        public T GetValue(params int[] coordinates)
        {
            if (coordinates.Any(c => c < 0))
                throw new TensorException("Invalid coordinate");

            return default(T);
        }
    }
}
