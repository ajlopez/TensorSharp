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

        [TestMethod]
        public void CloneTensorWithNewValues()
        {
            Tensor<int> tensor = new Tensor<int>(2, 3);

            Tensor<int> newTensor = tensor.CloneWithNewValues(new int[] { 1, 2, 3, 4, 5, 6 });

            Assert.IsNotNull(newTensor);
            Assert.AreEqual(2, newTensor.Rank);
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
        }

        [TestMethod]
        public void SetGetValueInTensorWithoutDimensions()
        {
            Tensor<int> tensor = new Tensor<int>();

            tensor.SetValue(42);

            Assert.AreEqual(42, tensor.GetValue());
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

        [TestMethod]
        public void AddSimpleIntegerValues()
        {
            Tensor<int> t1 = new Tensor<int>();
            Tensor<int> t2 = new Tensor<int>();

            t1.SetValue(1);
            t2.SetValue(41);

            Tensor<int> result = t1.Add<int>(t2);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rank);
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void AddSimpleDoubleValues()
        {
            Tensor<double> t1 = new Tensor<double>();
            Tensor<double> t2 = new Tensor<double>();

            t1.SetValue(1.2);
            t2.SetValue(40.8);

            Tensor<double> result = t1.Add<double>(t2);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rank);
            Assert.AreEqual(42.0, result.GetValue());
        }

        [TestMethod]
        public void SubtractSimpleIntegerValues()
        {
            Tensor<int> t1 = new Tensor<int>();
            Tensor<int> t2 = new Tensor<int>();

            t1.SetValue(43);
            t2.SetValue(1);

            Tensor<int> result = t1.Subtract<int>(t2);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rank);
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void SubtractSimpleDoubleValues()
        {
            Tensor<double> t1 = new Tensor<double>();
            Tensor<double> t2 = new Tensor<double>();

            t1.SetValue(43.2);
            t2.SetValue(1.2);

            Tensor<double> result = t1.Subtract<double>(t2);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rank);
            Assert.AreEqual(42.0, result.GetValue());
        }

        [TestMethod]
        public void MultiplySimpleIntegerValues()
        {
            Tensor<int> t1 = new Tensor<int>();
            Tensor<int> t2 = new Tensor<int>();

            t1.SetValue(21);
            t2.SetValue(2);

            Tensor<int> result = t1.Multiply<int>(t2);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rank);
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void MultiplySimpleDoubleValues()
        {
            Tensor<double> t1 = new Tensor<double>();
            Tensor<double> t2 = new Tensor<double>();

            t1.SetValue(21.0);
            t2.SetValue(2.0);

            Tensor<double> result = t1.Multiply<double>(t2);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rank);
            Assert.AreEqual(42.0, result.GetValue());
        }

        [TestMethod]
        public void DivideSimpleIntegerValues()
        {
            Tensor<int> t1 = new Tensor<int>();
            Tensor<int> t2 = new Tensor<int>();

            t1.SetValue(84);
            t2.SetValue(2);

            Tensor<int> result = t1.Divide<int>(t2);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rank);
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void DivideSimpleDoubleValues()
        {
            Tensor<double> t1 = new Tensor<double>();
            Tensor<double> t2 = new Tensor<double>();

            t1.SetValue(84.0);
            t2.SetValue(2.0);

            Tensor<double> result = t1.Divide<double>(t2);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rank);
            Assert.AreEqual(42.0, result.GetValue());
        }

        [TestMethod]
        public void NegateSimpleIntegerValue()
        {
            Tensor<int> t1 = new Tensor<int>();

            t1.SetValue(-42);

            Tensor<int> result = t1.Negate();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rank);
            Assert.AreEqual(42, result.GetValue());
        }

        [TestMethod]
        public void NegateSimpleDoubleValue()
        {
            Tensor<double> t1 = new Tensor<double>();

            t1.SetValue(-42.0);

            Tensor<double> result = t1.Negate();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rank);
            Assert.AreEqual(42.0, result.GetValue());
        }

        [TestMethod]
        public void NegateIntegersValue()
        {
            Tensor<int> t1 = new Tensor<int>(2, 2);

            t1.SetValue(42, 0, 0);
            t1.SetValue(1, 0, 1);
            t1.SetValue(2, 1, 0);
            t1.SetValue(3, 1, 1);

            Tensor<int> result = t1.Negate();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Rank);
            Assert.AreEqual(-42, result.GetValue(0, 0));
            Assert.AreEqual(-1, result.GetValue(0, 1));
            Assert.AreEqual(-2, result.GetValue(1, 0));
            Assert.AreEqual(-3, result.GetValue(1, 1));
        }
    }
}
