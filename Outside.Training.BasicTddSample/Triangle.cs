using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outside.Training.BasicTddSample
{
    public class Triangle
    {
        public Triangle(double width, double height)
        {
            if (width < 0)
                throw new ArgumentOutOfRangeException("width");

            if (height < 0)
                throw new ArgumentOutOfRangeException("height");

            Width = width;
            Height = height;
        }

        public double Width { get; private set; }
        public double Height { get; private set; }

        public double CalculateArea()
        {
            return Height * Width / 2;
        }
    }
}
