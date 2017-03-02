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
            Tensor<int> tensor = new Tensor<int>(3, 4, 5);

            Assert.AreEqual(3, tensor.Rank);
        }

        [TestMethod]
        public void GetDimensionLength()
        {
            Tensor<int> tensor = new Tensor<int>(3, 4, 5);

            Assert.AreEqual(3, tensor.GetDimensionLength(0));
            Assert.AreEqual(4, tensor.GetDimensionLength(1));
            Assert.AreEqual(5, tensor.GetDimensionLength(2));
        }

        [TestMethod]
        public void GetDefaultValue()
        {
            Tensor<int> tensor = new Tensor<int>(3, 4, 5);

            Assert.AreEqual(0, tensor.GetValue(1, 2, 3));
        }

        [TestMethod]
        public void NegativeCoordinateInGetValue()
        {
            Tensor<int> tensor = new Tensor<int>(3, 4, 5);

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

        [TestMethod]
        public void NegativeCoordinateInSetValue()
        {
            Tensor<int> tensor = new Tensor<int>(3, 4, 5);

            try
            {
                tensor.SetValue(1, -2, 3);
                Assert.Fail();
            }
            catch (TensorException ex)
            {
                Assert.AreEqual("Invalid coordinate", ex.Message);
            }
        }

        [TestMethod]
        public void SetAndGetValues()
        {
            Tensor<int> tensor = new Tensor<int>(3, 4, 5);

            tensor.SetValue(42, 2, 3, 4);
            tensor.SetValue(1, 1, 0, 0);
            tensor.SetValue(2, 1, 1, 0);
            tensor.SetValue(3, 1, 1, 1);

            Assert.AreEqual(0, tensor.GetValue(1, 2, 3));
            Assert.AreEqual(42, tensor.GetValue(2, 3, 4));
            Assert.AreEqual(1, tensor.GetValue(1, 0, 0));
            Assert.AreEqual(2, tensor.GetValue(1, 1, 0));
            Assert.AreEqual(3, tensor.GetValue(1, 1, 1));
        }
    }
}
