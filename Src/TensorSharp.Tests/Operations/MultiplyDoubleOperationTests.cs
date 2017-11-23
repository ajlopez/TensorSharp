namespace TensorSharp.Tests.Operations
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TensorSharp.Operations;

    [TestClass]
    public class MultiplyDoubleOperationTests
    {
        [TestMethod]
        public void MultiplySingleValues()
        {
            INode<double> left = Flow.Constant(2.0);
            INode<double> right = Flow.Constant(41.5);

            var multiply = new MultiplyDoubleOperation(left, right);

            Assert.AreEqual(left.Rank, multiply.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = multiply.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(83.0, result.GetValue());
        }

        [TestMethod]
        public void MultiplyVectors()
        {
            INode<double> left = Flow.Constant(new double[] { 1.5, 2.5, 3.5 });
            INode<double> right = Flow.Constant(new double[] { 4, 5, 6 });

            var multiply = new MultiplyDoubleOperation(left, right);

            Assert.AreEqual(left.Rank, multiply.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = multiply.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(1.5 * 4, result.GetValue(0));
            Assert.AreEqual(2.5 * 5, result.GetValue(1));
            Assert.AreEqual(3.5 * 6, result.GetValue(2));
        }

        [TestMethod]
        public void MultiplyVectorsWithDifferentLengths()
        {
            INode<double> left = Flow.Constant(new double[] { 1.5, 2.5, 3.5 });
            INode<double> right = Flow.Constant(new double[] { 4.0, 5.0, 6.0, 7.0 });

            try
            {
                new MultiplyDoubleOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }

        [TestMethod]
        public void MultiplyMatrices()
        {
            INode<double> left = Flow.Constant(new double[][] { new double[] { 1.5, 2.5, 3.5 }, new double[] { 4.5, 5.5, 6.5 } });
            INode<double> right = Flow.Constant(new double[][] { new double[] { 10.0, 20.0, 30.0 }, new double[] { 40.0, 50.0, 60.0 } });

            var multiply = new MultiplyDoubleOperation(left, right);

            Assert.AreEqual(left.Rank, multiply.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = multiply.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));

            Assert.AreEqual(1.5 * 10, result.GetValue(0, 0));
            Assert.AreEqual(2.5 * 20, result.GetValue(0, 1));
            Assert.AreEqual(3.5 * 30, result.GetValue(0, 2));

            Assert.AreEqual(4.5 * 40, result.GetValue(1, 0));
            Assert.AreEqual(5.5 * 50, result.GetValue(1, 1));
            Assert.AreEqual(6.5 * 60, result.GetValue(1, 2));
        }

        [TestMethod]
        public void MultiplyMatricesWithDifferentShapes()
        {
            INode<double> left = Flow.Constant(new double[][] { new double[] { 1.5, 2.5, 3.5 }, new double[] { 4.5, 5.5, 6.5 } });
            INode<double> right = Flow.Constant(new double[][] { new double[] { 10.0, 20.0 }, new double[] { 40.0, 50.0 } });

            try
            {
                new MultiplyDoubleOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
