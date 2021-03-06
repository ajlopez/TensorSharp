﻿namespace TensorSharp.Tests.Operations
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TensorSharp.Nodes;
    using TensorSharp.Operations;

    [TestClass]
    public class AddIntegerOperationTests
    {
        [TestMethod]
        public void AddSingleValues()
        {
            INode<int> left = Flow.Constant(1);
            INode<int> right = Flow.Constant(41);

            var add = new AddIntegerOperation(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void AddVectors()
        {
            INode<int> left = Flow.Constant(new int[] { 1, 2, 3 });
            INode<int> right = Flow.Constant(new int[] { 4, 5, 6 });

            var add = new AddIntegerOperation(left, right);

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
        public void AddVectorsWithDifferentLengths()
        {
            INode<int> left = Flow.Constant(new int[] { 1, 2, 3 });
            INode<int> right = Flow.Constant(new int[] { 4, 5, 6, 7 });

            try
            {
                new AddIntegerOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }

        [TestMethod]
        public void AddMatrices()
        {
            INode<int> left = Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });
            INode<int> right = Flow.Constant(new int[][] { new int[] { 10, 20, 30 }, new int[] { 40, 50, 60 } });

            var add = new AddIntegerOperation(left, right);

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
        public void AddMatricesWithDifferentShapes()
        {
            INode<int> left = Flow.Constant(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });
            INode<int> right = Flow.Constant(new int[][] { new int[] { 10, 20 }, new int[] { 40, 50 } });

            try
            {
                new AddIntegerOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
