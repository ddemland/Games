
using BlackJack.Engine;
using NUnit.Framework;

namespace BlackJack.Tests
{
    public class NUnitPlayer
    {
        [Test]
        public void TestPlayerCreation()
        {
            var player = new Player("Testing");
            Assert.AreEqual("Testing", player.Name);
            Assert.AreEqual(200, player.TotalMoney);
            Assert.AreEqual(0, player.Bet);
            Assert.IsFalse(player.HandBusted);
            Assert.IsFalse(player.HandHeld);
            Assert.AreEqual(0, player.PlayerHand.Cards.Count);

            player.Bet = 30;
            Assert.AreEqual(30, player.Bet);
        }

        [Test]
        public void TestMoneyTotal()
        {
            var player = new Player("Testing")
            {
                Bet = 10
            };
            player.AdjustMoneyTotal(true);
            Assert.AreEqual(190, player.TotalMoney);

            player.AdjustMoneyTotal(false);
            Assert.AreEqual(200, player.TotalMoney);
        }

        [Test]
        public void TestHitAndClearHand()
        {
            var deck = new DeckOfCards();
            var player = new Player("Player");
            player.DoHit(deck);
            Assert.IsFalse(player.HandBusted);
            Assert.IsFalse(player.HandHeld);
            var card = player.PlayerHand.LastCardDelt;
            Assert.AreEqual(Card.Suits.Heart, card.Suit);
            Assert.AreEqual(1, card.Value);
            player.DoHit(deck);
            card = player.PlayerHand.LastCardDelt;
            Assert.AreEqual(Card.Suits.Heart, card.Suit);
            Assert.AreEqual(2, card.Value);

            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();

            player.DoHit(deck);
            player.DoHit(deck);
            player.DoHit(deck);
            Assert.IsTrue(player.HandBusted);
            Assert.IsTrue(player.HandHeld);

            player.ClearHand();
            Assert.IsFalse(player.HandBusted);
            Assert.IsFalse(player.HandHeld);
            Assert.AreEqual(0, player.Bet);
            Assert.AreEqual(0, player.PlayerHand.Cards.Count);
        }

        [Test]
        public void TestHeldAndBustHand()
        {
            var deck = new DeckOfCards();
            var player = new Player("Testing");

            player.GetCard(deck);
            player.GetCard(deck);
            player.GetCard(deck);
            player.GetCard(deck);
            player.DoHit(deck);
            Assert.IsTrue(player.HandHeld);
            Assert.IsFalse(player.HandBusted);

            player = new Player("Testing");
            player.GetCard(deck);
            player.GetCard(deck);
            player.GetCard(deck);
            player.DoHit(deck);
            Assert.IsTrue(player.HandHeld);
            Assert.IsTrue(player.HandBusted);
        }

        [Test]
        public void TestBlackJack()
        {
            var deck = new DeckOfCards();
            var player = new Player("Testing");
            player.GetCard(deck);
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            player.GetCard(deck);
            Assert.IsTrue(player.HasBackJack());
        }

        [Test]
        public void TestInitPlayer()
        {
            var deck = new DeckOfCards();
            var player = new Player("Testing");
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            player.GetCard(deck);
            player.GetCard(deck);
            player.GetCard(deck);
            Assert.AreEqual(3, player.PlayerHand.Cards.Count);
            Assert.AreEqual(27, player.PlayerHand.TotalHand());
            Assert.IsTrue(player.HandBusted);
            Assert.IsTrue(player.HandHeld);

            player.ClearHand();
            Assert.AreEqual(0, player.PlayerHand.Cards.Count);
            Assert.AreEqual(0, player.PlayerHand.TotalHand());
            Assert.IsFalse(player.HandBusted);
            Assert.IsFalse(player.HandHeld);
        }

        [Test]
        public void TestTotalError()
        {
            var deck = new DeckOfCards();
            var player = new Player("Testing");

            player.GetCard(deck);
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            player.GetCard(deck);
            Assert.AreEqual(19, player.PlayerHand.TotalHand());

            deck = new DeckOfCards();
            player = new Player("Testing");
            deck.GetNextCard();
            player.GetCard(deck);
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            player.GetCard(deck);
            Assert.AreEqual(10, player.PlayerHand.TotalHand());

            deck = new DeckOfCards();
            player = new Player("Testing");
            deck.GetNextCard();
            player.GetCard(deck);
            deck.GetNextCard();
            deck.GetNextCard();
            deck.GetNextCard();
            player.GetCard(deck);
            Assert.AreEqual(8, player.PlayerHand.TotalHand());
        }
    }
}
