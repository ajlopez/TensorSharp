namespace TensorSharp.Tests.Operations
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TensorSharp.Operations;

    [TestClass]
    public class AddDoubleOperationTests
    {
        [TestMethod]
        public void AddSingleValues()
        {
            INode<double> left = new SingleValue<double>(0.5);
            INode<double> right = new SingleValue<double>(41.5);

            var add = new AddDoubleOperation(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(42.0, result.GetValue());
        }

        [TestMethod]
        public void AddVectors()
        {
            INode<double> left = new Vector<double>(new double[] { 1.5, 2.5, 3.5 });
            INode<double> right = new Vector<double>(new double[] { 4, 5, 6 });

            var add = new AddDoubleOperation(left, right);

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
        public void AddVectorsWithDifferentLengths()
        {
            INode<double> left = new Vector<double>(new double[] { 1.5, 2.5, 3.5 });
            INode<double> right = new Vector<double>(new double[] { 4.0, 5.0, 6.0, 7.0 });

            try
            {
                new AddDoubleOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }

        [TestMethod]
        public void AddMatrices()
        {
            INode<double> left = new Matrix<double>(new double[][] { new double[] { 1.5, 2.5, 3.5 }, new double[] { 4.5, 5.5, 6.5 } });
            INode<double> right = new Matrix<double>(new double[][] { new double[] { 10.0, 20.0, 30.0 }, new double[] { 40.0, 50.0, 60.0 } });

            var add = new AddDoubleOperation(left, right);

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
        public void AddMatricesWithDifferentShapes()
        {
            INode<double> left = new Matrix<double>(new double[][] { new double[] { 1.5, 2.5, 3.5 }, new double[] { 4.5, 5.5, 6.5 } });
            INode<double> right = new Matrix<double>(new double[][] { new double[] { 10.0, 20.0 }, new double[] { 40.0, 50.0 } });

            try
            {
                new AddDoubleOperation(left, right);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
