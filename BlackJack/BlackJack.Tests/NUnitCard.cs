using BlackJack.Engine;
using NUnit.Framework;

namespace BlackJack.Tests
{
    public class NunitCard
    {
        [Test]
        public void CreateCard()
        {
            var card = new Card(Card.Suits.Club, 4);

            Assert.AreEqual(Card.Suits.Club, card.Suit);
            Assert.AreEqual(4, card.Value);
        }
    }
}