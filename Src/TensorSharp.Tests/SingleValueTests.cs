namespace TensorSharp.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SingleValueTests
    {
        [TestMethod]
        public void CreateIntegerValue()
        {
            var value = new SingleValue<int>(42);

            Assert.AreEqual(42, value.GetValue());
            Assert.AreEqual(0, value.Rank);
            Assert.AreEqual(0, value.Shape.Length);
        }
    }
}
