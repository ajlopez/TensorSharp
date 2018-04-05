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

            var result = session.Run(constant, null);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SessionRunPlaceHolderContextWithConstant()
        {
            var constant = Flow.Constant(42);
            var placeholder = Flow.PlaceHolder<int>("answer", new int[0]);

            Context context = new Context();
            context.SetNode("answer", constant);
            Session session = new Session();

            var result = session.Run(placeholder, context);

            Assert.IsNotNull(result);
        }
    }
}
