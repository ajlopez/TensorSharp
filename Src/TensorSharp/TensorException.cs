namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TensorException : Exception
    {
        public TensorException(string msg)
            : base(msg)
        {
        }
    }
}
