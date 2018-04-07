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
            Assert.AreEqual(42, result.GetValue(0));
        }

        [TestMethod]
        public void SessionRunManyTimes()
        {
            var constant = Flow.Constant(1);
            var placeholder = Flow.PlaceHolder<int>("number", new int[0]);
            var operation = Flow.Add(placeholder, Flow.Constant(1));

            Context context = new Context();
            context.SetNode("number", constant);
            Session session = new Session();

            var result = session.Run(operation, context);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.GetValue(0));
            
            context.SetNode("number", result);

            result = session.Run(operation, context);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.GetValue(0));

            context.SetNode("number", result);

            result = session.Run(operation, context);

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.GetValue(0));
        }
    }
}
