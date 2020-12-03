
using BlackJack.Engine;
using NUnit.Framework;

namespace BlackJack.Tests
{
    public class NUnitHand
    {
        [Test]
        public void GetCardTest()
        {
            var deck = new DeckOfCards();
            var hand = new Hand();
            var cards = hand.GetCards();
            Assert.AreEqual(0, cards.Count);
            hand.GetACard(deck);
            Assert.AreEqual(1, cards.Count);
            var card = cards[0];
            Assert.AreEqual(Card.Suits.Heart, card.Suit);
            Assert.AreEqual(1, card.Value);

            hand.GetACard(deck);
            Assert.AreEqual(2, cards.Count);
            card = cards[1];
            Assert.AreEqual(Card.Suits.Heart, card.Suit);
            Assert.AreEqual(2, card.Value);

            hand.GetACard(deck);
            Assert.AreEqual(3, cards.Count);
            card = cards[2];
            Assert.AreEqual(Card.Suits.Heart, card.Suit);
            Assert.AreEqual(3, card.Value);

            hand.GetACard(deck);
            Assert.AreEqual(4, cards.Count);
            card = cards[3];
            Assert.AreEqual(Card.Suits.Heart, card.Suit);
            Assert.AreEqual(4, card.Value);

            hand.GetACard(deck);
            Assert.AreEqual(5, cards.Count);
            card = cards[4];
            Assert.AreEqual(Card.Suits.Heart, card.Suit);
            Assert.AreEqual(5, card.Value);

            Assert.Throws<MaxCardInHand>(() => hand.GetACard(deck));
            Assert.AreEqual(5, cards.Count);
        }

        [Test]
        public void TestHandTotal()
        {
            var deck = new DeckOfCards();
            var hand = new Hand();

            hand.GetACard(deck);
            hand.GetACard(deck);
            hand.GetACard(deck);
            hand.GetACard(deck);
            Assert.AreEqual(20, hand.TotalHand());

            hand = new Hand();
            hand.GetACard(deck);
            hand.GetACard(deck);
            hand.GetACard(deck);
            hand.GetACard(deck);
            hand.GetACard(deck);

            hand = new Hand();
            hand.GetACard(deck);
            hand.GetACard(deck);
            hand.GetACard(deck);
            hand.GetACard(deck);
            Assert.AreEqual(40, hand.TotalHand());
        }

        [Test]
        public void TestMoreThanOneAce()
        {
            var deck = new DeckOfCards();
            var hand = new Hand();

            hand.GetACard(deck);

            var trashHand = new Hand();
            trashHand.GetACard(deck);
            trashHand.GetACard(deck);
            trashHand.GetACard(deck);
            trashHand.GetACard(deck);
            trashHand.GetACard(deck);

            hand.GetACard(deck);
            hand.GetACard(deck);

            trashHand = new Hand();
            trashHand.GetACard(deck);
            trashHand.GetACard(deck);
            trashHand.GetACard(deck);
            trashHand.GetACard(deck);
            trashHand.GetACard(deck);

            hand.GetACard(deck);
            Assert.AreEqual(17, hand.TotalHand());
        }

        [Test]
        public void TestLastCardDelt()
        {
            var deck = new DeckOfCards();
            var hand = new Hand();

            hand.GetACard(deck);
            var card = hand.LastCardDelt;
            Assert.AreEqual(Card.Suits.Heart, card.Suit);
            Assert.AreEqual(1, card.Value);

            var trashHand = new Hand();
            trashHand.GetACard(deck);
            trashHand.GetACard(deck);
            trashHand.GetACard(deck);
            trashHand.GetACard(deck);
            trashHand.GetACard(deck);

            card = trashHand.LastCardDelt;
            Assert.AreEqual(Card.Suits.Heart, card.Suit);
            Assert.AreEqual(6, card.Value);
        }

        [Test]
        public void TestClearHand()
        {
            var deck = new DeckOfCards();
            var hand = new Hand();

            Assert.AreEqual(0, hand.Cards.Count);
            hand.GetACard(deck);
            hand.GetACard(deck);
            hand.GetACard(deck);
            Assert.AreEqual(3, hand.Cards.Count);
            hand.ClearHand();
            Assert.AreEqual(0, hand.Cards.Count);
        }
    }
}
