namespace TensorSharp.Tests.Nodes
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TensorSharp.Nodes;

    [TestClass]
    public class PlaceHolderNodeTests
    {
        [TestMethod]
        public void ApplySimpleValueToPlaceHolder()
        {
            PlaceHolderNode<int> node = new PlaceHolderNode<int>("answer", new int[0]);
            INode<int> value = Flow.Constant(42);

            Context context = new Context();

            context.SetNode("answer", value);

            Assert.IsTrue(node.ApplyContext(context));
            Assert.AreEqual(42, node.GetValue(0));
        }
        
        [TestMethod]
        public void InvalidShape()
        {
            PlaceHolderNode<int> node = new PlaceHolderNode<int>("answer", new int[1]);
            INode<int> value = Flow.Constant(42);

            Context context = new Context();
            context.SetNode("answer", value);

            try
            {
                node.ApplyContext(context);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Invalid shape for placeholder 'answer'", ex.Message);
            }
        }

        [TestMethod]
        public void UnknownPlaceholder()
        {
            PlaceHolderNode<int> node = new PlaceHolderNode<int>("answer", new int[1]);
            INode<int> value = Flow.Constant(42);

            Context context = new Context();

            try
            {
                node.ApplyContext(context);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Unknown placeholder 'answer'", ex.Message);
            }
        }

        [TestMethod]
        public void ApplyContextOnBinaryOperation()
        {
            PlaceHolderNode<int> node = new PlaceHolderNode<int>("answer", new int[0]);
            INode<int> value1 = Flow.Constant(38);
            INode<int> value2 = Flow.Constant(2);
            INode<int> value1b = Flow.Constant(40);

            INode<int> oper = Flow.Add(node, value2);

            Context context = new Context();
            context.SetNode("answer", value1);

            Assert.IsTrue(oper.ApplyContext(context));
            oper.Evaluate();
            Assert.AreEqual(40, oper.GetValue(0));

            context.SetNode("answer", value1b);

            Assert.IsTrue(oper.ApplyContext(context));
            oper.Evaluate();
            Assert.AreEqual(42, oper.GetValue(0));
        }
    }
}
