namespace TensorSharp.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PlaceHolderNode<T> : INode<T>
    {
        private string name;
        private INode<T> node;
        private int[] shape;

        public PlaceHolderNode(string name, int[] shape)
        {
            this.name = name;
            this.shape = shape;
        }

        public string Name { get { return this.name; } }

        public int Rank
        {
            get 
            { 
                return this.shape.Length; 
            }
        }

        public int[] Shape
        {
            get 
            { 
                return this.shape; 
            }
        }

        public T[] Values
        {
            get 
            { 
                return this.node.Values;;
            }
        }

        public T GetValue(params int[] coordinates)
        {
            return this.node.GetValue(coordinates);
        }

        public INode<T> Evaluate()
        {
            return this.node.Evaluate();
        }

        public bool ApplyContext(Context context)
        {
            INode<T> newnode = context.GetNode<T>(this.name);

            if (newnode == null)
                throw new InvalidOperationException(String.Format("Unknown placeholder '{0}'", this.name));

            if (!newnode.Shape.SequenceEqual(this.shape))
                throw new InvalidOperationException(String.Format("Invalid shape for placeholder '{0}'", this.name));
 
            this.node = context.GetNode<T>(this.name);

            return true;
        }
    }
}
