namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tensor
    {
        private int[] dimensions;

        public Tensor(params int[] dimensions)
        {
            this.dimensions = (int[])dimensions.Clone();
        }

        public int NoDimensions { get { return this.dimensions.Length; } }
    }
}
