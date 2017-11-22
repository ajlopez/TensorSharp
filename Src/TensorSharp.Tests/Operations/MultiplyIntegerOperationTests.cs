namespace TensorSharp.Tests.Operations
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TensorSharp.Operations;

    [TestClass]
    public class MultiplyIntegerOperationTests
    {
        [TestMethod]
        public void MultiplySingleValues()
        {
            INode<int> left = Flow.Constant(2);
            INode<int> right = Flow.Constant(21);

            var multiply = new MultiplyIntegerOperation(left, right);

            Assert.AreEqual(left.Rank, multiply.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = multiply.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void MultiplyVectors()
        {
            INode<int> left = Flow.Constant(new int[] { 1, 2, 3 });
            INode<int> right = Flow.Constant(new int[] { 4, 5, 6 });

            var multiply = new MultiplyIntegerOperation(left, right);

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
        public void MultiplyVectorsWithDifferentLengths()
        {
            INode<int> left = Flow.Constant(new int[] { 1, 2, 3 });
            INode<int> right = Flow.Constant(new int[] { 4, 5, 6, 7 });

            try
            {
                new MultiplyIntegerOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }

        [TestMethod]
        public void MultiplyMatrices()
        {
            INode<int> left = Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });
            INode<int> right = Flow.Constant(new int[][] { new int[] { 10, 20, 30 }, new int[] { 40, 50, 60 } });

            var multiply = new MultiplyIntegerOperation(left, right);

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
        public void MultiplyMatricesWithDifferentShapes()
        {
            INode<int> left = Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });
            INode<int> right = Flow.Constant(new int[][] { new int[] { 10, 20 }, new int[] { 40, 50 } });

            try
            {
                new MultiplyIntegerOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
