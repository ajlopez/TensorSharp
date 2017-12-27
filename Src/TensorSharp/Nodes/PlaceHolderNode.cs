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

        public PlaceHolderNode(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }

        public int Rank
        {
            get 
            { 
                return this.node.Rank; 
            }
        }

        public int[] Shape
        {
            get 
            { 
                return this.node.Shape; 
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

        public void ApplyContext(Context context)
        {
            this.node = context.GetNode<T>(this.name);
        }
    }
}
