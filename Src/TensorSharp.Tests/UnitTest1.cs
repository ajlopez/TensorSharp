namespace TensorSharp.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SessionTests
    {
        [TestMethod]
        public void SessionRunConstant()
        {
            var constant = Flow.Constant(42);
            Session session = new Session();

            var result = session.Run(constant);

            Assert.IsNotNull(result);
        }
    }
}
