
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Engine
{
    public class Hand
    {
        public const int MaxCardsInHand = 5;
        public const int BlackJackScore = 21;
        public const int HighAceValue = 11;

        public List<Card> Cards { get; private set; }
        public Card LastCardDelt { get; private set; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        public void GetACard(DeckOfCards deck)
        {
            if (Cards.Count >= MaxCardsInHand)
            {
                throw new MaxCardInHand();
            }

            var card = deck.GetNextCard();
            Cards.Add(card);
            LastCardDelt = card;
        }

        public List<Card> GetCards()
        {
            return Cards;
        }

        public int TotalHand()
        {
            if (Cards.Count == 0)
            {
                return 0;
            }

            var handTotal = 0;
            var aceCnt = Cards.Count(c => c.Value == Card.Ace);
            foreach (var card in Cards)
            {
                switch (card.Value)
                {
                    case Card.Ace:
                        continue;

                    case Card.Jack:
                    case Card.Queen:
                    case Card.King:
                        handTotal += 10;
                        break;

                    default:
                        handTotal += card.Value;
                        break;
                }
            }

            if (aceCnt > 1)
            {
                handTotal += aceCnt;
            }
            else if (aceCnt == 1)
            {
                if (handTotal + HighAceValue <= BlackJackScore)
                {
                    handTotal += HighAceValue;
                }
                else
                {
                    handTotal ++;
                }
            }

            return handTotal;
        }

        public void ClearHand()
        {
            Cards.Clear();
        }
    }
}
