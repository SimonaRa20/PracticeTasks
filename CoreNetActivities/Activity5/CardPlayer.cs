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
        public int CardCount { get; set; }
        public int MaxSize { get; set; }

        public CardPlayer(string name, char gender, DateTime birthDate, int v) : base(name, gender, birthDate)
        {

        }

        public bool AddCard(SimpleCard simpleCard)
        {
            if (simpleCard == null)
            {
                throw new ArgumentNullException();
            }
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
