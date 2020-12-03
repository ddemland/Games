
using System.Runtime.InteropServices.ComTypes;
using BlackJack.Engine;
using NUnit.Framework;

namespace BlackJack.Tests
{
    public class NUnitDeck
    {
        [Test]
        public void TestCreateDeck()
        {
            var deck = new DeckOfCards();
            for (var cnt = 0; cnt < DeckOfCards.HighCardValue; cnt ++)
            {
                var card = deck.GetNextCard();
                Assert.AreEqual(Card.Suits.Heart, card.Suit);
                Assert.AreEqual(cnt + 1, card.Value);
            }

            for (var cnt = 0; cnt < DeckOfCards.HighCardValue; cnt++)
            {
                var card = deck.GetNextCard();
                Assert.AreEqual(Card.Suits.Club, card.Suit);
                Assert.AreEqual(cnt + 1, card.Value);
            }

            for (var cnt = 0; cnt < DeckOfCards.HighCardValue; cnt++)
            {
                var card = deck.GetNextCard();
                Assert.AreEqual(Card.Suits.Diamond, card.Suit);
                Assert.AreEqual(cnt + 1, card.Value);
            }

            for (var cnt = 0; cnt < DeckOfCards.HighCardValue; cnt++)
            {
                var card = deck.GetNextCard();
                Assert.AreEqual(Card.Suits.Spade, card.Suit);
                Assert.AreEqual(cnt + 1, card.Value);
            }
        }

        [Test]
        public void TestShuffle()
        {
            var deck = new DeckOfCards();
            var totalNotShuffle = 0;
            var cardsChecked = 0;

            deck.ShuffleDeck();
            var card1 = deck.GetNextCard();
            while (cardsChecked < DeckOfCards.MaxDeck - 1)
            {
                cardsChecked ++;
                var card2 = deck.GetNextCard();

                if ((card1.Suit == card2.Suit) &&
                    (card1.Value == card2.Value))
                {
                    totalNotShuffle ++;
                }

                card1 = card2;
            }

            var percentageNotShuffled = (totalNotShuffle / 52.0M) * 100M;
            Assert.IsFalse(percentageNotShuffled > 10);
        }
    }
}
