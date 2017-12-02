namespace TensorSharp.Tests.Operations
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TensorSharp.Operations;

    [TestClass]
    public class DivideIntegerOperationTests
    {
        [TestMethod]
        public void DivideSingleValues()
        {
            INode<int> left = Flow.Constant(84);
            INode<int> right = Flow.Constant(2);

            var divide = new DivideIntegerOperation(left, right);

            Assert.AreEqual(left.Rank, divide.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = divide.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void DivideVectors()
        {
            INode<int> left = Flow.Constant(new int[] { 4, 5, 6 });
            INode<int> right = Flow.Constant(new int[] { 1, 2, 3 });

            var divide = new DivideIntegerOperation(left, right);

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
        public void DivideVectorsWithDifferentLengths()
        {
            INode<int> left = Flow.Constant(new int[] { 1, 2, 3 });
            INode<int> right = Flow.Constant(new int[] { 4, 5, 6, 7 });

            try
            {
                new DivideIntegerOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }

        [TestMethod]
        public void DivideMatrices()
        {
            INode<int> left = Flow.Constant(new int[][] { new int[] { 10, 20, 30 }, new int[] { 40, 50, 60 } });
            INode<int> right = Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });

            var Divide = new DivideIntegerOperation(left, right);

            Assert.AreEqual(left.Rank, Divide.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = Divide.Evaluate();

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
            INode<int> left = Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });
            INode<int> right = Flow.Constant(new int[][] { new int[] { 10, 20 }, new int[] { 40, 50 } });

            try
            {
                new DivideIntegerOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
