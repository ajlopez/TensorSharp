namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TensorSharp.Nodes;

    public class Session
    {
        public INode<T> Run<T>(INode<T> node)
        {
            return node;
        }
    }
}
