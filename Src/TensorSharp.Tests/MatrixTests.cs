namespace TensorSharp.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void CreateIntegerMatrix()
        {
            var matrix = new Matrix<int>(2, 3);

            Assert.AreEqual(2, matrix.Rank);
            Assert.IsNotNull(matrix.Shape);
            Assert.IsTrue(matrix.Shape.SequenceEqual(new int[] { 2, 3 }));
        }

        [TestMethod]
        public void CreateIntegerMatrixUsingValues()
        {
            var matrix = new Matrix<int>(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });

            Assert.AreEqual(2, matrix.Rank);
            Assert.IsNotNull(matrix.Shape);
            Assert.IsTrue(matrix.Shape.SequenceEqual(new int[] { 2, 3 }));
        }

        [TestMethod]
        public void SetAndGetValues()
        {
            var matrix = new Matrix<int>(2, 3);

            matrix.SetValue(42, 1, 2);
            Assert.AreEqual(42, matrix.GetValue(1, 2));
        }
    }
}
