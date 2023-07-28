using Activity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity5
{
    public class CardPlayer : PlayerProfile
    {
        private int v;

        public CardPlayer(string name, char gender, DateTime birthDate) : base(name, gender, birthDate)
        {
        }

        public CardPlayer(string name, char gender, DateTime birthDate, int v) : this(name, gender, birthDate)
        {
            this.v = v;
        }

        public int CardCount { get; set; }
        public int MaxSize { get; set; }

        public bool AddCard(SimpleCard simpleCard)
        {
            throw new NotImplementedException();
        }

        public bool IsFull()
        {
            throw new NotImplementedException();
        }

        public bool RemoveCard(SimpleCard simpleCard)
        {
            throw new NotImplementedException();
        }
    }
}
