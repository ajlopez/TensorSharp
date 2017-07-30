﻿namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Matrix<T> : INode<T>
    {
        private int[] shape;
        private T[] values;
        private int nrows;
        private int ncols;

        public Matrix(int nrows, int ncols)
        {
            this.nrows = nrows;
            this.ncols = ncols;
            this.values = new T[nrows * ncols];
            this.shape = new int[] { nrows, ncols };
        }

        public int Rank { get { return 2; } }

        public int[] Shape { get { return this.shape; } }

        public T GetValue(params int[] coordinates)
        {
            return this.values[coordinates[0] * this.ncols + coordinates[1]];
        }

        public void SetValue(T value, params int[] coordinates)
        {
            this.values[coordinates[0] * this.ncols + coordinates[1]] = value;
        }
    }
}
