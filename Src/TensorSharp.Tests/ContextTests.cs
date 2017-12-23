namespace TensorSharp.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TensorSharp.Nodes;

    [TestClass]
    public class ContextTests
    {
        [TestMethod]
        public void GetUnknowIntegerNode()
        {
            Context context = new Context();

            Assert.IsNull(context.GetNode<int>("x"));
        }

        [TestMethod]
        public void GetUnknowDoubleNode()
        {
            Context context = new Context();

            Assert.IsNull(context.GetNode<double>("y"));
        }

        [TestMethod]
        public void SetAndGetIntegerNode()
        {
            Context context = new Context();

            INode<int> node = Flow.Constant<int>(42);

            context.SetNode("x", node);

            var result = context.GetNode<int>("x");

            Assert.IsNotNull(result);
            Assert.AreSame(node, result);

            Assert.IsNull(context.GetNode<double>("x"));
        }

        [TestMethod]
        public void SetAndGetDoubleNode()
        {
            Context context = new Context();

            INode<double> node = Flow.Constant<double>(3.14159);

            context.SetNode("x", node);

            var result = context.GetNode<double>("x");

            Assert.IsNotNull(result);
            Assert.AreSame(node, result);

            Assert.IsNull(context.GetNode<int>("x"));
        }
    }
}
