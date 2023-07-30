using Activity5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity7
{
    public abstract class CardDeck
    {
        protected List<ICard> cards;

        public int CardCount => cards.Count;

        public abstract void InitializeDeck();

        public CardDeck()
        {
            cards = new List<ICard>();
            InitializeDeck();
        }

        public bool PutCard(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException();
            }

            cards.Add(card);
            return true;
        }

        public CardDeck(int number) : this()
        {
            while (cards.Count > number)
            {
                cards.RemoveAt(cards.Count - 1);
            }
        }

        public ICard GetCard()
        {
            if (cards.Count == 0)
            {
                return null;
            }

            Random random = new Random();
            int index = random.Next(cards.Count);
            ICard card = cards[index];
            cards.RemoveAt(index);
            return card;
        }


        public ICard GetCard(ICard card)
        {
            if(card == null)
            {
                throw new ArgumentNullException();
            }

            if(cards.Count == 0)
            {
                return null;
            }

            ICard foundCard = cards.FirstOrDefault(c => c.Equals(card));
            if (foundCard == null)
            {
                return null;
            }
            cards.Remove(foundCard);
            return foundCard;
        }

        
    }
}
