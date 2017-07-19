namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Matrix<T>
    {
        private int[] shape;

        public Matrix(int nrows, int ncols)
        {
            this.shape = new int[] { nrows, ncols };
        }

        public int Rank { get { return 2; } }

        public int[] Shape { get { return this.shape; } }

    }
}
