namespace TensorSharp.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FlowTests
    {
        [TestMethod]
        public void CreateConstantSingleValue()
        {
            INode<int> value = Flow.Constant<int>(42);

            Assert.IsNotNull(value);
            Assert.AreEqual(42, value.GetValue());
        }

        [TestMethod]
        public void CreateConstantVector()
        {
            INode<int> value = Flow.Constant<int>(new int[] { 1, 2, 3 });

            Assert.IsNotNull(value);
            Assert.AreEqual(1, value.GetValue(0));
            Assert.AreEqual(2, value.GetValue(1));
            Assert.AreEqual(3, value.GetValue(2));

            Assert.AreEqual(1, value.Rank);
            Assert.IsTrue(value.Shape.SequenceEqual(new int[] { 3 }));
        }

        [TestMethod]
        public void CreateConstantMatrix()
        {
            INode<int> value = Flow.Constant<int>(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });

            Assert.AreEqual(2, value.Rank);
            Assert.IsNotNull(value.Shape);
            Assert.IsTrue(value.Shape.SequenceEqual(new int[] { 2, 3 }));

            Assert.AreEqual(1, value.GetValue(0, 0));
            Assert.AreEqual(2, value.GetValue(0, 1));
            Assert.AreEqual(3, value.GetValue(0, 2));

            Assert.AreEqual(4, value.GetValue(1, 0));
            Assert.AreEqual(5, value.GetValue(1, 1));
            Assert.AreEqual(6, value.GetValue(1, 2));
        }

        [TestMethod]
        public void NegateIntegerSingleValue()
        {
            INode<int> value = Flow.Negate(Flow.Constant(42)).Evaluate();

            Assert.IsNotNull(value);
            Assert.AreEqual(-42, value.GetValue());
        }

        [TestMethod]
        public void NegateIntegerVector()
        {
            INode<int> value = Flow.Negate(Flow.Constant(new int[] { 1, 2, 3 })).Evaluate();

            Assert.IsNotNull(value);
            Assert.AreEqual(-1, value.GetValue(0));
            Assert.AreEqual(-2, value.GetValue(1));
            Assert.AreEqual(-3, value.GetValue(2));

            Assert.AreEqual(1, value.Rank);
            Assert.IsTrue(value.Shape.SequenceEqual(new int[] { 3 }));
        }

        [TestMethod]
        public void NegateIntegerMatrix()
        {
            INode<int> value = Flow.Negate(Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } })).Evaluate();

            Assert.AreEqual(2, value.Rank);
            Assert.IsNotNull(value.Shape);
            Assert.IsTrue(value.Shape.SequenceEqual(new int[] { 2, 3 }));

            Assert.AreEqual(-1, value.GetValue(0, 0));
            Assert.AreEqual(-2, value.GetValue(0, 1));
            Assert.AreEqual(-3, value.GetValue(0, 2));

            Assert.AreEqual(-4, value.GetValue(1, 0));
            Assert.AreEqual(-5, value.GetValue(1, 1));
            Assert.AreEqual(-6, value.GetValue(1, 2));
        }

        [TestMethod]
        public void NegateDoubleSingleValue()
        {
            INode<double> value = Flow.Negate(Flow.Constant(42.0)).Evaluate();

            Assert.IsNotNull(value);
            Assert.AreEqual(-42.0, value.GetValue());
        }

        [TestMethod]
        public void NegateDoubleVector()
        {
            INode<double> value = Flow.Negate(Flow.Constant(new double[] { 1.1, 2.2, 3.3 })).Evaluate();

            Assert.IsNotNull(value);
            Assert.AreEqual(-1.1, value.GetValue(0));
            Assert.AreEqual(-2.2, value.GetValue(1));
            Assert.AreEqual(-3.3, value.GetValue(2));

            Assert.AreEqual(1, value.Rank);
            Assert.IsTrue(value.Shape.SequenceEqual(new int[] { 3 }));
        }

        [TestMethod]
        public void NegateDoubleMatrix()
        {
            INode<double> value = Flow.Negate(Flow.Constant(new double[][] { new double[] { 1.1, 2.2, 3.3 }, new double[] { 4.4, 5.5, 6.6 } })).Evaluate();

            Assert.AreEqual(2, value.Rank);
            Assert.IsNotNull(value.Shape);
            Assert.IsTrue(value.Shape.SequenceEqual(new int[] { 2, 3 }));

            Assert.AreEqual(-1.1, value.GetValue(0, 0));
            Assert.AreEqual(-2.2, value.GetValue(0, 1));
            Assert.AreEqual(-3.3, value.GetValue(0, 2));

            Assert.AreEqual(-4.4, value.GetValue(1, 0));
            Assert.AreEqual(-5.5, value.GetValue(1, 1));
            Assert.AreEqual(-6.6, value.GetValue(1, 2));
        }

        [TestMethod]
        public void AddIntegerSingleValues()
        {
            INode<int> left = Flow.Constant(1);
            INode<int> right = Flow.Constant(41);

            var add = Flow.Add(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);   
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void AddDoubleSingleValues()
        {
            INode<double> left = Flow.Constant(0.5);
            INode<double> right = Flow.Constant(41.5);

            var add = Flow.Add(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void AddIntegerVectors()
        {
            INode<int> left = Flow.Constant(new int[] { 1, 2, 3 });
            INode<int> right = Flow.Constant(new int[] { 4, 5, 6 });

            var add = Flow.Add(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(5, result.GetValue(0));
            Assert.AreEqual(7, result.GetValue(1));
            Assert.AreEqual(9, result.GetValue(2));
        }

        [TestMethod]
        public void AddDoubleVectors()
        {
            INode<double> left = Flow.Constant(new double[] { 1.5, 2.5, 3.5 });
            INode<double> right = Flow.Constant(new double[] { 4.0, 5.0, 6.0 });

            var add = Flow.Add(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(5.5, result.GetValue(0));
            Assert.AreEqual(7.5, result.GetValue(1));
            Assert.AreEqual(9.5, result.GetValue(2));
        }

        [TestMethod]
        public void AddIntegerMatrices()
        {
            INode<int> left = Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });
            INode<int> right = Flow.Constant(new int[][] { new int[] { 10, 20, 30 }, new int[] { 40, 50, 60 } });

            var add = Flow.Add(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));

            Assert.AreEqual(11, result.GetValue(0, 0));
            Assert.AreEqual(22, result.GetValue(0, 1));
            Assert.AreEqual(33, result.GetValue(0, 2));

            Assert.AreEqual(44, result.GetValue(1, 0));
            Assert.AreEqual(55, result.GetValue(1, 1));
            Assert.AreEqual(66, result.GetValue(1, 2));
        }

        [TestMethod]
        public void AddDoubleMatrices()
        {
            INode<double> left = Flow.Constant(new double[][] { new double[] { 1.5, 2.5, 3.5 }, new double[] { 4.5, 5.5, 6.5 } });
            INode<double> right = Flow.Constant(new double[][] { new double[] { 10.0, 20.0, 30.0 }, new double[] { 40.0, 50.0, 60.0 } });

            var add = Flow.Add(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));

            Assert.AreEqual(11.5, result.GetValue(0, 0));
            Assert.AreEqual(22.5, result.GetValue(0, 1));
            Assert.AreEqual(33.5, result.GetValue(0, 2));

            Assert.AreEqual(44.5, result.GetValue(1, 0));
            Assert.AreEqual(55.5, result.GetValue(1, 1));
            Assert.AreEqual(66.5, result.GetValue(1, 2));
        }

        [TestMethod]
        public void SubtractIntegerSingleValues()
        {
            INode<int> left = Flow.Constant(43);
            INode<int> right = Flow.Constant(1);

            var add = Flow.Subtract(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void SubtractIntegerVectors()
        {
            INode<int> left = Flow.Constant(new int[] { 1, 2, 3 });
            INode<int> right = Flow.Constant(new int[] { 4, 5, 6 });

            var add = Flow.Subtract(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(-3, result.GetValue(0));
            Assert.AreEqual(-3, result.GetValue(1));
            Assert.AreEqual(-3, result.GetValue(2));
        }

        [TestMethod]
        public void SubtractIntegerMatrices()
        {
            INode<int> left = Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });
            INode<int> right = Flow.Constant(new int[][] { new int[] { 10, 20, 30 }, new int[] { 40, 50, 60 } });

            var add = Flow.Subtract(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));

            Assert.AreEqual(-9, result.GetValue(0, 0));
            Assert.AreEqual(-18, result.GetValue(0, 1));
            Assert.AreEqual(-27, result.GetValue(0, 2));

            Assert.AreEqual(-36, result.GetValue(1, 0));
            Assert.AreEqual(-45, result.GetValue(1, 1));
            Assert.AreEqual(-54, result.GetValue(1, 2));
        }

        [TestMethod]
        public void SubtractDoubleSingleValues()
        {
            INode<double> left = Flow.Constant(43.5);
            INode<double> right = Flow.Constant(1.5);

            var add = Flow.Subtract(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(42.0, result.GetValue());
        }

        [TestMethod]
        public void SubtractDoubleVectors()
        {
            INode<double> left = Flow.Constant(new double[] { 1.5, 2.4, 3.3 });
            INode<double> right = Flow.Constant(new double[] { 0.5, 0.4, 0.3 });

            var add = Flow.Subtract(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(1.0, result.GetValue(0));
            Assert.AreEqual(2.0, result.GetValue(1));
            Assert.AreEqual(3.0, result.GetValue(2));
        }

        [TestMethod]
        public void SubtractDoubleMatrices()
        {
            INode<double> left = Flow.Constant(new double[][] { new double[] { 1.5, 2.4, 3.3 }, new double[] { 4.5, 5.5, 6.5 } });
            INode<double> right = Flow.Constant(new double[][] { new double[] { 0.5, 0.4, 0.3 }, new double[] { 4.0, 5.0, 6.0 } });

            var add = Flow.Subtract(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));

            Assert.AreEqual(1.0, result.GetValue(0, 0));
            Assert.AreEqual(2.0, result.GetValue(0, 1));
            Assert.AreEqual(3.0, result.GetValue(0, 2));

            Assert.AreEqual(0.5, result.GetValue(1, 0));
            Assert.AreEqual(0.5, result.GetValue(1, 1));
            Assert.AreEqual(0.5, result.GetValue(1, 2));
        }

        [TestMethod]
        public void MultiplyIntegerSingleValues()
        {
            INode<int> left = Flow.Constant(2);
            INode<int> right = Flow.Constant(21);

            var multiply = Flow.Multiply(left, right);

            Assert.AreEqual(left.Rank, multiply.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = multiply.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void MultiplyIntegerVectors()
        {
            INode<int> left = Flow.Constant(new int[] { 1, 2, 3 });
            INode<int> right = Flow.Constant(new int[] { 4, 5, 6 });

            var multiply = Flow.Multiply(left, right);

            Assert.AreEqual(left.Rank, multiply.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = multiply.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(4, result.GetValue(0));
            Assert.AreEqual(10, result.GetValue(1));
            Assert.AreEqual(18, result.GetValue(2));
        }

        [TestMethod]
        public void MultiplyIntegerMatrices()
        {
            INode<int> left = Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });
            INode<int> right = Flow.Constant(new int[][] { new int[] { 10, 20, 30 }, new int[] { 40, 50, 60 } });

            var multiply = Flow.Multiply(left, right);

            Assert.AreEqual(left.Rank, multiply.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = multiply.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));

            Assert.AreEqual(10, result.GetValue(0, 0));
            Assert.AreEqual(40, result.GetValue(0, 1));
            Assert.AreEqual(90, result.GetValue(0, 2));

            Assert.AreEqual(160, result.GetValue(1, 0));
            Assert.AreEqual(250, result.GetValue(1, 1));
            Assert.AreEqual(360, result.GetValue(1, 2));
        }

        [TestMethod]
        public void DivideIntegerSingleValues()
        {
            INode<int> left = Flow.Constant(84);
            INode<int> right = Flow.Constant(2);

            var divide = Flow.Divide(left, right);

            Assert.AreEqual(left.Rank, divide.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = divide.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void DivideIntegerVectors()
        {
            INode<int> left = Flow.Constant(new int[] { 4, 5, 6 });
            INode<int> right = Flow.Constant(new int[] { 1, 2, 3 });

            var divide = Flow.Divide(left, right);

            Assert.AreEqual(left.Rank, divide.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = divide.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(4, result.GetValue(0));
            Assert.AreEqual(2, result.GetValue(1));
            Assert.AreEqual(2, result.GetValue(2));
        }

        [TestMethod]
        public void DivideIntegerMatrices()
        {
            INode<int> left = Flow.Constant(new int[][] { new int[] { 10, 20, 30 }, new int[] { 40, 50, 60 } });
            INode<int> right = Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });

            var divide = Flow.Divide(left, right);

            Assert.AreEqual(left.Rank, divide.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = divide.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));

            Assert.AreEqual(10, result.GetValue(0, 0));
            Assert.AreEqual(10, result.GetValue(0, 1));
            Assert.AreEqual(10, result.GetValue(0, 2));

            Assert.AreEqual(10, result.GetValue(1, 0));
            Assert.AreEqual(10, result.GetValue(1, 1));
            Assert.AreEqual(10, result.GetValue(1, 2));
        }

        [TestMethod]
        public void DivideDoubleSingleValues()
        {
            INode<double> left = Flow.Constant(10.0);
            INode<double> right = Flow.Constant(4.0);

            var divide = Flow.Divide(left, right);

            Assert.AreEqual(left.Rank, divide.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = divide.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(2.5, result.GetValue());
        }

        [TestMethod]
        public void DivideDoubleVectors()
        {
            INode<double> left = Flow.Constant(new double[] { 4, 5, 6 });
            INode<double> right = Flow.Constant(new double[] { 1, 2, 3 });

            var divide = Flow.Divide(left, right);

            Assert.AreEqual(left.Rank, divide.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = divide.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(4.0, result.GetValue(0));
            Assert.AreEqual(2.5, result.GetValue(1));
            Assert.AreEqual(2.0, result.GetValue(2));
        }

        [TestMethod]
        public void DivideDoubleMatrices()
        {
            INode<double> left = Flow.Constant(new double[][] { new double[] { 10, 20, 30 }, new double[] { 40, 50, 60 } });
            INode<double> right = Flow.Constant(new double[][] { new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 } });

            var divide = Flow.Divide(left, right);

            Assert.AreEqual(left.Rank, divide.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = divide.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));

            Assert.AreEqual(10, result.GetValue(0, 0));
            Assert.AreEqual(10, result.GetValue(0, 1));
            Assert.AreEqual(10, result.GetValue(0, 2));

            Assert.AreEqual(10, result.GetValue(1, 0));
            Assert.AreEqual(10, result.GetValue(1, 1));
            Assert.AreEqual(10, result.GetValue(1, 2));
        }
    }
}
