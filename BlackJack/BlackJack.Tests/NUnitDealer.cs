
using BlackJack.Engine;
using NUnit.Framework;

namespace BlackJack.Tests
{
    public class NUnitDealer
    {
        [Test]
        public void TestAddPlayer()
        {
            var dealer = new Dealer();
            dealer.AddPlayer("Testing");
            Assert.Throws<PlayerAlreadyExist>(() => dealer.AddPlayer("Testing"));
            dealer.AddPlayer("Testing 1");
            dealer.AddPlayer("Testing 2");
            dealer.AddPlayer("Testing 3");
            dealer.AddPlayer("Testing 4");
            Assert.Throws<MaxPlayers>(() => dealer.AddPlayer("Testing 5"));
        }

        [Test]
        public void TestPlayerMoneyTotal()
        {
            var dealer = new Dealer();
            dealer.AddPlayer("Testing");
            dealer.AddPlayer("Testing 1");
            var total = dealer.GetPlayerMoneyTotal("Testing");
            Assert.AreEqual(200, total);
            total = dealer.GetPlayerMoneyTotal("Testing 1");
            Assert.AreEqual(200, total);

            dealer.SetPlayerMoneyTotal("Testing", 300);
            total = dealer.GetPlayerMoneyTotal("Testing");
            Assert.AreEqual(300, total);
            total = dealer.GetPlayerMoneyTotal("Testing 1");
            Assert.AreEqual(200, total);

            Assert.Throws<PlayerDoesNotExist>(() => dealer.SetPlayerMoneyTotal("Bad Player", 300));
        }

        [Test]
        public void TestDealerPlay()
        {
            const string playerName = "Testing 1";
            var dealer = new Dealer();
            dealer.AddPlayer(playerName);
            dealer.StartHand();
            var cardCnt = dealer.PlayerCardCount(playerName);
            Assert.AreEqual(2, cardCnt);
            Assert.AreEqual(2, dealer.DealerCardCount());
            Assert.IsFalse(dealer.PlayerHandHeld(playerName));
        }
    }
}
