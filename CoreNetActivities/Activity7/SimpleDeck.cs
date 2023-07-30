using Activity5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity7
{
    public class SimpleDeck : CardDeck
    {
        public SimpleCard[] Cards => cards.OfType<SimpleCard>().ToArray();

        public SimpleDeck(int number)
        {
        }

        public SimpleDeck()
        {
        }

        public override void InitializeDeck()
        {
            for (int i = 0; i < 20; i++)
            {
                cards.Add(new SimpleCard());
            }
        }
    }
}
