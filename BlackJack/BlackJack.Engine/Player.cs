
namespace BlackJack.Engine
{
    public class Player
    {
        public Hand PlayerHand { get; }
        public int TotalMoney { get; set; }
        public int Bet { get; set; }
        public bool HandHeld { get; set; }
        public bool HandBusted { get; private set; }
        public string Name { get; }

        public Player(string name)
        {
            PlayerHand = new Hand();
            Name = name;
            InitPlayer();
        }

        public void InitPlayer()
        {
            PlayerHand.ClearHand();
            TotalMoney = 200;
            HandHeld = false;
            HandBusted = false;
            Bet = 0;
        }

        public void AdjustMoneyTotal(bool lossFlag)
        {
            if (lossFlag)
            {
                TotalMoney -= Bet;
            }
            else
            {
                TotalMoney += Bet;
            }
        }

        public void DoHit(DeckOfCards deck)
        {
            PlayerHand.GetACard(deck);
            HandOver();
        }

        public void ClearHand()
        {
            HandHeld = false;
            HandBusted = false;
            Bet = 0;
            PlayerHand.ClearHand();
        }

        public void GetCard(DeckOfCards deck)
        {
            if (HandBusted)
            {
                throw new HandBusted();
            }

            if (HandHeld)
            {
                throw new HandHeld();
            }

            PlayerHand.GetACard(deck);
            HandOver();
        }

        public bool HasBackJack()
        {
            return (PlayerHand.Cards.Count == 2) &&
                   PlayerHand.TotalHand() == Hand.BlackJackScore;
        }

        private void HandOver()
        {
            if (PlayerHand.TotalHand() > Hand.BlackJackScore)
            {
                HandBusted = true;
                HandHeld = true;
            }
            else
            {
                if (PlayerHand.Cards.Count == Hand.MaxCardsInHand)
                {
                    HandHeld = true;
                }
            }
        }
    }
}
