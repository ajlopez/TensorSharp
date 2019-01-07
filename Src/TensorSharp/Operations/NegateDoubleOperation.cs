namespace TensorSharp.Operations
{
    using TensorSharp.Nodes;

    public class NegateDoubleOperation : UnaryOperation<double>
    {
        public NegateDoubleOperation(INode<double> node)
            : base(node)
        {
        }

        public override void Calculate(double[] newvalues, double[] values)
        {
            int l = newvalues.Length;

            for (int k = 0; k < l; k++)
                newvalues[k] = -values[k];
        }
    }
}
