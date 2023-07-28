using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity6
{
    public class Rectangle : Shape
    {
        public double Length { get; protected set; }

        public double Width { get; protected set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public override void CalculateArea()
        {
            if (Length <= 0 || Width <= 0)
            {
                throw new InvalidShapeParameterException("Rectangle dimensions must be positive.");
            }

            Area = Length * Width;
        }

        public void Print()
        {
            Console.WriteLine(Area);
        }
    }
}
