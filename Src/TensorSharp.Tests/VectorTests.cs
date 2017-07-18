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

        [TestMethod]
        public void SetAndGetValues()
        {
            var vector = new Vector<int>(3);

            vector.SetValue(1, 0);
            vector.SetValue(2, 1);
            vector.SetValue(3, 2);

            Assert.AreEqual(1, vector.GetValue(0));
            Assert.AreEqual(2, vector.GetValue(1));
            Assert.AreEqual(3, vector.GetValue(2));
        }
    }
}
