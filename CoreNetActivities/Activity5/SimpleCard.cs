using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity5
{
    public class SimpleCard : ICard
    {
        public int CardAttribute { get; set; }

        public string GetCardAttribute()
        {
            throw new NotImplementedException();
        }
    }
}
