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
            return new SingleValue<T>(value);
        }

        public static INode<T> Constant<T>(T[] values)
        {
            return new Vector<T>(values);
        }

        public static INode<T> Constant<T>(T[][] values)
        {
            return new Matrix<T>(values);
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
    }
}
