using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity6
{
    public class Circle : Shape
    {
        public double Radius { get; protected set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override void CalculateArea()
        {
            if (Radius <= 0)
            {
                throw new InvalidShapeParameterException("Circle radius must be positive.");
            }

            Area = Math.PI * Math.Pow(Radius, 2); ;
        }

        public void Print()
        {
            Console.WriteLine(Area);
        }
    }
}
