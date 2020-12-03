
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Engine
{
    public class Dealer
    {
        public const int MaxPlayers = 5;
        public const int DealerMinHandValue = 17;

        public DeckOfCards Deck { get; set; }
        public Player DealerPlayer { get; set; }
        public List<Player> Players { get; set; }

        public Dealer()
        {
            Players = new List<Player>();
            Deck = new DeckOfCards();
            DealerPlayer = new Player("Dealer");

            InitDealer();
        }

        public void InitDealer()
        {
            ClearAllHandsForNewGame();
        }

        public void AddPlayer(string name)
        {
            if (Players.Count(p => p.Name == name) != 0)
            {
                throw new PlayerAlreadyExist();
            }

            if (Players.Count >= MaxPlayers)
            {
                throw new MaxPlayers();
            }

            Players.Add(new Player(name));
        }

        public void SetPlayerMoneyTotal(string name, int amount)
        {
            if (Players.Count(p => p.Name == name) == 0)
            {
                throw new PlayerDoesNotExist();
            }

            var player = Players.First(p => p.Name == name);
            player.TotalMoney = amount;
        }

        public int GetPlayerMoneyTotal(string name)
        {
            if (Players.Count(p => p.Name == name) == 0)
            {
                throw new PlayerDoesNotExist();
            }

            var player = Players.First(p => p.Name == name);
            return player.TotalMoney;
        }

        public void StartHand()
        {
            Deck.ShuffleDeck();

            foreach (var player in Players)
            {
                player.GetCard(Deck);
            }

            DealerPlayer.GetCard(Deck);

            foreach (var player in Players)
            {
                player.GetCard(Deck);
            }

            DealerPlayer.GetCard(Deck);
        }

        public void HoldPlayer(string name)
        {
            if (Players.Count(p => p.Name == name) == 0)
            {
                throw new PlayerDoesNotExist();
            }

            var player = Players.First(p => p.Name == name);
            player.HandHeld = true;
        }

        public int PlayerCardCount(string name)
        {
            if (Players.Count(p => p.Name == name) == 0)
            {
                throw new PlayerDoesNotExist();
            }

            var player = Players.First(p => p.Name == name);
            return player.PlayerHand.Cards.Count;
        }

        public int DealerCardCount()
        {
            return DealerPlayer.PlayerHand.Cards.Count;
        }

        public bool PlayerHandHeld(string name)
        {
            if (Players.Count(p => p.Name == name) == 0)
            {
                throw new PlayerDoesNotExist();
            }

            var player = Players.First(p => p.Name == name);
            return player.HandHeld;
        }

        public void SetPlayerBet(string name, int amount)
        {
            if (Players.Count(p => p.Name == name) == 0)
            {
                throw new PlayerDoesNotExist();
            }

            var player = Players.First(p => p.Name == name);
            player.Bet = amount;
        }

        public void ClearAllHandsForNewGame()
        {
            DealerPlayer.ClearHand();
            foreach (var player in Players)
            {
                player.PlayerHand.ClearHand();
            }
        }
    }
}
