namespace TensorSharp.Tests.Operations
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TensorSharp.Nodes;
    using TensorSharp.Operations;

    [TestClass]
    public class SubtractIntegerOperationTests
    {
        [TestMethod]
        public void SubtractSingleValues()
        {
            INode<int> left = Flow.Constant(43);
            INode<int> right = Flow.Constant(1);

            var add = new SubtractIntegerOperation(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void SubtractVectors()
        {
            INode<int> left = Flow.Constant(new int[] { 1, 2, 3 });
            INode<int> right = Flow.Constant(new int[] { 4, 5, 6 });

            var add = new SubtractIntegerOperation(left, right);

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
        public void SubtractVectorsWithDifferentLengths()
        {
            INode<int> left = Flow.Constant(new int[] { 1, 2, 3 });
            INode<int> right = Flow.Constant(new int[] { 4, 5, 6, 7 });

            try
            {
                new SubtractIntegerOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }

        [TestMethod]
        public void SubtractMatrices()
        {
            INode<int> left = Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });
            INode<int> right = Flow.Constant(new int[][] { new int[] { 10, 20, 30 }, new int[] { 40, 50, 60 } });

            var add = new SubtractIntegerOperation(left, right);

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
        public void SubtractMatricesWithDifferentShapes()
        {
            INode<int> left = Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });
            INode<int> right = Flow.Constant(new int[][] { new int[] { 10, 20 }, new int[] { 40, 50 } });

            try
            {
                new SubtractIntegerOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
