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
            : base(CalculateShape(values), ToFlatArray(values))
        {
        }

        private static int[] CalculateShape(T[][] values)
        {
            int[] shape = new int[2];

            shape[0] = values.Length;
            shape[1] = values[0].Length;

            return shape;
        }

        private static T[] ToFlatArray(T[][] values)
        {
            int[] shape = CalculateShape(values);

            T[] flatvalues = new T[shape[0] * shape[1]];

            return flatvalues;
        }
    }
}
