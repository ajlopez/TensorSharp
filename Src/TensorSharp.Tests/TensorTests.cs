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

            Assert.AreEqual(3, tensor.NoDimensions);
        }
    }
}
