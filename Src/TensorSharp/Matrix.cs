namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Matrix<T> : BaseValueNode<T>
    {
        public Matrix(int nrows, int ncols)
            : base(new int[] { nrows, ncols }, new T[nrows * ncols])
        {
        }

        public Matrix(T[][] values)
            : base(new int[0], new T[0])
        {
        }
    }
}
