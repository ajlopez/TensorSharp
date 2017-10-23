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
        public void CreateIntegerVectorWithInitialValues()
        {
            var vector = new Vector<int>(new int[] { 1, 2, 3 });

            Assert.AreEqual(1, vector.Rank);
            Assert.IsNotNull(vector.Shape);
            Assert.IsTrue(vector.Shape.SequenceEqual(new int[] { 3 }));

            Assert.AreEqual(1, vector.GetValue(0));
            Assert.AreEqual(2, vector.GetValue(1));
            Assert.AreEqual(3, vector.GetValue(2));
        }
    }
}
