namespace TensorSharp.Operations
{
    using TensorSharp.Nodes;

    public class DivideIntegerOperation : BinaryOperation<int>
    {
        public DivideIntegerOperation(INode<int> left, INode<int> right)
            : base(left, right)
        {
        }

        public override void Calculate(int[] newvalues, int[] leftvalues, int[] rightvalues)
        {
            int l = newvalues.Length;

            for (int k = 0; k < l; k++)
                newvalues[k] = leftvalues[k] / rightvalues[k];
        }
    }
}
