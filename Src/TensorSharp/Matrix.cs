namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Matrix<T> : INode<T>
    {
        private int[] shape;
        private T[][] values;
        private int nrows;
        private int ncols;

        public Matrix(int nrows, int ncols)
        {
            this.nrows = nrows;
            this.ncols = ncols;
            this.values = new T[nrows][];

            for (int k = 0; k < nrows; k++)
                this.values[k] = new T[ncols];

            this.shape = new int[] { nrows, ncols };
        }

        public Matrix(T[][] values)
        {
            this.nrows = values.Length;
            this.ncols = values[0].Length;
            this.shape = new int[] { this.nrows, this.ncols };
            this.values = values;
        }

        public int Rank { get { return 2; } }

        public int[] Shape { get { return this.shape; } }

        public T GetValue(params int[] coordinates)
        {
            return this.values[coordinates[0]][coordinates[1]];
        }

        public void SetValue(T value, params int[] coordinates)
        {
            this.values[coordinates[0]][coordinates[1]] = value;
        }
    }
}
