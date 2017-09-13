namespace TensorSharp.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FlowTests
    {
        [TestMethod]
        public void CreateConstantSingleValue()
        {
            INode<int> value = Flow.Constant<int>(42);

            Assert.IsNotNull(value);
            Assert.AreEqual(42, value.GetValue());
        }

        [TestMethod]
        public void CreateConstantVector()
        {
            INode<int> value = Flow.Constant<int>(new int[] { 1, 2, 3 });

            Assert.IsNotNull(value);
            Assert.AreEqual(1, value.GetValue(0));
            Assert.AreEqual(2, value.GetValue(1));
            Assert.AreEqual(3, value.GetValue(2));
        }
    }
}
