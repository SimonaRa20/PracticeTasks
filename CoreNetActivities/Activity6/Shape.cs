using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity6
{
    public abstract class Shape
    {
        public double Area { get; protected set; }

        public abstract void CalculateArea();
    }
}
