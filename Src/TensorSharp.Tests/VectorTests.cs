namespace TensorSharp.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void CreateIntegerVector()
        {
            var vector = new Vector<int>(10);

            Assert.AreEqual(1, vector.Rank);
            Assert.IsNotNull(vector.Shape);
            Assert.IsTrue(vector.Shape.SequenceEqual(new int[] { 10 }));
        }
    }
}
