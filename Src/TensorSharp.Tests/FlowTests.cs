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
    }
}
