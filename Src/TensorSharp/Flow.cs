namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TensorSharp.Operations;

    public static class Flow
    {
        public static INode<T> Constant<T>(T value)
        {
            return new BaseValueNode<T>(new int[0], new T[] { value });
        }

        public static INode<T> Constant<T>(T[] values)
        {
            return new BaseValueNode<T>(new int[] { values.Length }, values);
        }

        public static INode<T> Constant<T>(T[][] values)
        {
            return new BaseValueNode<T>(CalculateShape(values), ToFlatArray(values));
        }

        public static INode<int> Negate(INode<int> node)
        {
            return new NegateIntegerOperation(node);
        }

        public static INode<double> Negate(INode<double> node)
        {
            return new NegateDoubleOperation(node);
        }

        public static INode<int> Add(INode<int> left, INode<int> right)
        {
            return new AddIntegerOperation(left, right);
        }

        public static INode<double> Add(INode<double> left, INode<double> right)
        {
            return new AddDoubleOperation(left, right);
        }

        public static INode<int> Subtract(INode<int> left, INode<int> right)
        {
            return new SubtractIntegerOperation(left, right);
        }

        public static INode<double> Subtract(INode<double> left, INode<double> right)
        {
            return new SubtractDoubleOperation(left, right);
        }

        private static int[] CalculateShape<T>(T[][] values)
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

        private static T[] ToFlatArray<T>(T[][] values)
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
