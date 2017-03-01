namespace TensorSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tensor<T>
    {
        private int[] dimensions;
        private T[] values;
        private int size;

        public Tensor(params int[] dimensions)
        {
            this.dimensions = (int[])dimensions.Clone();

            this.size = 1;

            for (int k = 0; k < dimensions.Length; k++)
                this.size *= dimensions[k];
        }

        public int Rank { get { return this.dimensions.Length; } }

        public int GetDimensionLength(int ndim)
        {
            return this.dimensions[ndim];
        }

        public T GetValue(params int[] coordinates)
        {
            if (coordinates.Any(c => c < 0))
                throw new TensorException("Invalid coordinate");

            if (this.values == null)
                return default(T);

            return this.values[this.CalculatePosition(coordinates)];
        }

        public void SetValue(T value, params int[] coordinates)
        {
            if (coordinates.Any(c => c < 0))
                throw new TensorException("Invalid coordinate");

            if (this.values == null)
                this.values = new T[this.size];

            this.values[this.CalculatePosition(coordinates)] = value;
        }

        private int CalculatePosition(int[] coordinates)
        {
            int position = coordinates[0];

            return position;
        }
    }
}
