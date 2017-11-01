namespace TensorSharp.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TensorTests
    {
        [TestMethod]
        public void CreateTensorWithThreeDimensions()
        {
            Tensor<int> tensor = new Tensor<int>(3, 4, 5);

            Assert.AreEqual(3, tensor.Rank);
            Assert.IsNotNull(tensor.Shape);
            Assert.IsTrue(tensor.Shape.SequenceEqual(new int[] { 3, 4, 5 }));
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

        [TestMethod]
        public void CloneTensorWithNewValues()
        {
            Tensor<int> tensor = new Tensor<int>(2, 3);

            Tensor<int> newTensor = tensor.CloneWithNewValues(new int[] { 1, 2, 3, 4, 5, 6 });

            Assert.IsNotNull(newTensor);
            Assert.AreEqual(2, newTensor.Rank);
            Assert.IsTrue(newTensor.Shape.SequenceEqual(new int[] { 2, 3 }));
            Assert.AreEqual(1, newTensor.GetValue(0, 0));
            Assert.AreEqual(2, newTensor.GetValue(1, 0));
            Assert.AreEqual(3, newTensor.GetValue(0, 1));
            Assert.AreEqual(4, newTensor.GetValue(1, 1));
            Assert.AreEqual(5, newTensor.GetValue(0, 2));
            Assert.AreEqual(6, newTensor.GetValue(1, 2));
        }

        [TestMethod]
        public void CreateTensorWithoutDimensions()
        {
            Tensor<int> tensor = new Tensor<int>();

            Assert.AreEqual(0, tensor.Rank);
            Assert.IsTrue(tensor.Shape.SequenceEqual(new int[] { }));
        }

        [TestMethod]
        public void SetGetValueInTensorWithoutDimensions()
        {
            Tensor<int> tensor = new Tensor<int>();

            tensor.SetValue(42);

            Assert.AreEqual(42, tensor.GetValue());
            Assert.IsTrue(tensor.Shape.SequenceEqual(new int[] { }));
        }

        [TestMethod]
        public void SealTensor()
        {
            Tensor<int> tensor = new Tensor<int>(3, 4, 5);

            Assert.IsFalse(tensor.Sealed);
            tensor.Seal();
            Assert.IsTrue(tensor.Sealed);
        }

        [TestMethod]
        public void CannotSetValueInSealedTensor()
        {
            Tensor<int> tensor = new Tensor<int>(3, 4, 5);

            tensor.Seal();

            try
            {
                tensor.SetValue(42, 2, 3, 4);
                Assert.Fail();
            }
            catch (TensorException ex)
            {
                Assert.AreEqual("Tensor is sealed", ex.Message);
            }
        }
    }
}
