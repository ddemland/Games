
using System;
using System.Collections.Generic;

namespace BlackJack.Engine
{
    public class DeckOfCards
    {
        public const int HighCardValue = 13;
        public const int MaxDeck = 52;
        private const int MaxShuffle = 300;

        public List<Card> Deck { get; }
        private int TopOfDeck { get; set; }

        public DeckOfCards()
        {
            TopOfDeck = 0;
            Deck = new List<Card>();
            foreach (var suit in Enum.GetValues(typeof(Card.Suits)))
            {
                for (var cnt = 0; cnt < HighCardValue; cnt ++)
                {
                    var card = new Card((Card.Suits)suit, cnt + 1);
                    Deck.Add(card);
                }
            }
        }

        public Card GetNextCard()
        {
            if (TopOfDeck >= MaxDeck)
            {
                throw new NoCards();
            }

            var card = Deck[TopOfDeck ++];
            return card;
        }

        public void ShuffleDeck()
        {
            TopOfDeck = 0;
            var rnd = new Random(DateTime.Now.Millisecond);
            for (var cnt = 0; cnt < MaxShuffle; cnt ++)
            {
                var swapIdx1 = rnd.Next(MaxDeck);
                var swapIdx2 = rnd.Next(MaxDeck);
                var holdCard = Deck[swapIdx1];
                Deck[swapIdx1] = Deck[swapIdx2];
                Deck[swapIdx2] = holdCard;
            }
        }
    }
}
