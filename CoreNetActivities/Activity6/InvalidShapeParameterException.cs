using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity6
{
    public class InvalidShapeParameterException : Exception
    {
        public InvalidShapeParameterException(string message) : base(message)
        {
        }
    }
}
