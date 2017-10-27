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
            if (values == null)
                throw new InvalidOperationException();

            for (int k = 1; k < values.Length; k++)
                if (values[k].Length != values[0].Length)
                    throw new InvalidOperationException();

            int[] shape = new int[2];

            shape[0] = values.Length;
            shape[1] = values[0].Length;

            return shape;
        }

        private static T[] ToFlatArray(T[][] values)
        {
            int[] shape = CalculateShape(values);
            int nrows = shape[0];
            int ncols = shape[1];

            T[] flatvalues = new T[nrows * ncols];

            int k = 0;

            for (int x = 0; x < ncols; x++)
                for (int y = 0; y < nrows; y++)
                    flatvalues[k++] = values[y][x];

            return flatvalues;
        }
    }
}
