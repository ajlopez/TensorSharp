namespace TensorSharp.Tests.Operations
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TensorSharp.Operations;

    [TestClass]
    public class DivideDoubleOperationTests
    {
        [TestMethod]
        public void DivideSingleValues()
        {
            INode<double> left = Flow.Constant(10.0);
            INode<double> right = Flow.Constant(4.0);

            var divide = new DivideDoubleOperation(left, right);

            Assert.AreEqual(left.Rank, divide.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = divide.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(2.5, result.GetValue());
        }

        [TestMethod]
        public void DivideVectors()
        {
            INode<double> left = Flow.Constant(new double[] { 4, 5, 6 });
            INode<double> right = Flow.Constant(new double[] { 1, 2, 3 });

            var divide = new DivideDoubleOperation(left, right);

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
        public void DivideVectorsWithDifferentLengths()
        {
            INode<double> left = Flow.Constant(new double[] { 1, 2, 3 });
            INode<double> right = Flow.Constant(new double[] { 4, 5, 6, 7 });

            try
            {
                new DivideDoubleOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }

        [TestMethod]
        public void DivideMatrices()
        {
            INode<double> left = Flow.Constant(new double[][] { new double[] { 10, 20, 30 }, new double[] { 40, 50, 60 } });
            INode<double> right = Flow.Constant(new double[][] { new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 } });

            var divide = new DivideDoubleOperation(left, right);

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
        public void DivideMatricesWithDifferentShapes()
        {
            INode<double> left = Flow.Constant(new double[][] { new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 } });
            INode<double> right = Flow.Constant(new double[][] { new double[] { 10, 20 }, new double[] { 40, 50 } });

            try
            {
                new DivideDoubleOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
