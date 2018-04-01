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
            PlaceHolderNode<int> node = new PlaceHolderNode<int>("answer");
            INode<int> value = Flow.Constant(42);

            Context context = new Context();

            context.SetNode("answer", value);

            Assert.IsTrue(node.ApplyContext(context));
            Assert.AreEqual(42, node.GetValue(0));
        }
    }
}
