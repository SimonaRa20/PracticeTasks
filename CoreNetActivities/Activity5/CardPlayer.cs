using Activity1;
using Activity4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity5
{
    public class CardPlayer : PlayerProfile
    {
        private ICard[] hand;
        private int maxHandSize;
        private int numCards;

        public CardPlayer(string name, char gender, DateTime birthDate, int maxHandSize)
        : base(name, gender, birthDate)
        {
            this.maxHandSize = maxHandSize;
            hand = new ICard[maxHandSize];
            numCards = 0;
        }

        public bool AddCard(ICard card)
        {
            if(card == null)
            {
                throw new ArgumentNullException();
            }

            if (numCards < maxHandSize)
            {
                hand[numCards] = card;
                numCards++;
                return true;
            }
            return false;
        }

        public bool RemoveCard(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < numCards; i++)
            {
                if (hand[i].Equals(card))
                {
                    for (int j = i; j < numCards - 1; j++)
                    {
                        hand[j] = hand[j + 1];
                    }
                    hand[numCards - 1] = null;
                    numCards--;
                    return true;
                }
            }
            return false;
        }

        public bool IsFull()
        {
            return numCards == maxHandSize;
        }

        public ICard GetCard(int index)
        {
            return hand[index];
        }

        public int CardCount
        {
            get { return numCards; }
        }

        public int MaxSize
        {
            get { return maxHandSize; }
        }
    }
}
