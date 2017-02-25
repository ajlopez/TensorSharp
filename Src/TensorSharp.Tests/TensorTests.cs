namespace TensorSharp.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TensorTests
    {
        [TestMethod]
        public void CreateTensorWithThreeDimensions()
        {
            Tensor tensor = new Tensor(3, 4, 5);

            Assert.AreEqual(3, tensor.Rank);
        }

        [TestMethod]
        public void GetDimensionLength()
        {
            Tensor tensor = new Tensor(3, 4, 5);

            Assert.AreEqual(3, tensor.GetDimensionLength(0));
            Assert.AreEqual(4, tensor.GetDimensionLength(1));
            Assert.AreEqual(5, tensor.GetDimensionLength(2));
        }

        [TestMethod]
        public void GetDefaultValue()
        {
            Tensor tensor = new Tensor(3, 4, 5);

            Assert.AreEqual(0, tensor.GetValue(1, 2, 3));
        }

        [TestMethod]
        public void NegativeCoordinate()
        {
            Tensor tensor = new Tensor(3, 4, 5);

            try
            {
                Assert.AreEqual(0, tensor.GetValue(1, -2, 3));
                Assert.Fail();
            }
            catch (TensorException ex)
            {
                Assert.AreEqual("Invalid coordinate", ex.Message);
            }
        }
    }
}
