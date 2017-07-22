namespace TensorSharp.Tests.Operations
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TensorSharp.Operations;

    [TestClass]
    public class AddIntegerOperationTests
    {
        [TestMethod]
        public void AddSingleValues()
        {
            IValue<int> left = new SingleValue<int>(1);
            IValue<int> right = new SingleValue<int>(41);

            var add = new AddIntegerOperation(left, right);

            Assert.AreEqual(left.Rank, add.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(right.Shape));

            var result = add.Evaluate();

            Assert.IsNotNull(result);
            Assert.AreEqual(left.Rank, result.Rank);
            Assert.IsTrue(left.Shape.SequenceEqual(result.Shape));
            Assert.AreEqual(42, result.GetValue());
        }
    }
}
