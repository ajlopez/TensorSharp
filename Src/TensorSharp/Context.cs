namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TensorSharp.Nodes;

    public class Context
    {
        private Dictionary<string, object> nodes = new Dictionary<string, object>();

        public void SetNode<T>(string name, INode<T> node)
        {
            nodes[name] = node;
        }

        public INode<T> GetNode<T>(string name)
        {
            if (!nodes.ContainsKey(name))
                return null;

            return nodes[name] as INode<T>;
        }
    }
}
