using System;
using BlackJack.Engine;

namespace BlackJack.Text
{
    class Program
    {
        static void Main(string[] args)
        {
            var dealer = new Dealer();
            GetPlayers(dealer);

            bool endGame;
            do
            {
                ClearAllHandsForNewGame(dealer);
                PlayHand(dealer);
                endGame = DoYesNoPrompt("Play another hand (y/n)? ");
            } while (endGame);
        }

        private static void PlayHand(Dealer dealer)
        {
            DisplayMoneyTotals(dealer);
            GetPlayerBets(dealer);
            dealer.StartHand();
            DisplayTable(dealer);
            PlayerHitOrHold(dealer);
            DoDealerHand(dealer);
            DisplayTable(dealer, true);
            FindWinners(dealer);
        }

        private static void GetPlayers(Dealer dealer)
        {
            Console.WriteLine("Welcome to BlackJack.");
            var doneWithPlayers = false;

            while (!doneWithPlayers)
            {
                Console.Write("Please Enter Name of Player: ");
                var name = Console.ReadLine();

                try
                {
                    dealer.AddPlayer(name);
                }

                catch (PlayerAlreadyExist)
                {
                    Console.WriteLine($"Player {name} is already in the game.");
                }

                catch (MaxPlayers)
                {
                    Console.WriteLine($"The table only seats 5 players.");
                    break;
                }

                doneWithPlayers = !DoYesNoPrompt("Is there another player (y/n)? ");
            }
        }

        private static void DisplayMoneyTotals(Dealer dealer)
        {
            foreach (var player in dealer.Players)
            {
                Console.WriteLine($"{player.Name} has {player.TotalMoney} dollars.");
            }
        }

        private static void GetPlayerBets(Dealer dealer)
        {
            foreach (var player in dealer.Players)
            {
                Console.Write($"{player.Name} enter your bet: ");
                var betStr = Console.ReadLine();
                var bet = Convert.ToInt32(betStr);
                dealer.SetPlayerBet(player.Name, bet);
            }
        }

        private static void DisplayTable(Dealer dealer, bool showFulDealer = false)
        {
            Console.Write($"{dealer.DealerPlayer.Name, -28}");
            if (!showFulDealer)
            {
                Console.WriteLine($" {GetCardString(dealer.DealerPlayer.PlayerHand.Cards[0])}");
            }
            else
            {
                foreach (var card in dealer.DealerPlayer.PlayerHand.Cards)
                {
                    Console.Write($" {GetCardString(card)} ");
                }

                Console.WriteLine();
            }

            foreach (var player in dealer.Players)
            {
                Console.Write($"{player.Name,-28}");
                foreach (var card in player.PlayerHand.Cards)
                {
                    Console.Write($" {GetCardString(card)} ");
                }

                Console.WriteLine();
            }
        }

        private static void PlayerHitOrHold(Dealer dealer)
        {
            foreach (var player in dealer.Players)
            {
                var done = false;
                while (!done)
                {
                    Console.Write($"{player.Name} do you want another card (y/n)? ");
                    var input = Console.ReadLine();
                    switch (input.ToLower())
                    {
                        case "y":
                            player.DoHit(dealer.Deck);
                            break;

                        case "n":
                            player.HandHeld = true;
                            break;

                        default:
                            Console.Write("Please enter a y or n.");
                            break;
                    }

                    if (player.HandBusted)
                    {
                        Console.WriteLine($"{player.Name} is busted.");
                        done = true;
                    }

                    if (player.HandHeld)
                    {
                        done = true;
                    }

                    DisplayTable(dealer);
                }
            }
        }

        private static void DoDealerHand(Dealer dealer)
        {
            if (dealer.DealerPlayer.PlayerHand.TotalHand() == Hand.BlackJackScore)
            {
                Console.WriteLine("Dealer has BlackJack, everyone losses.");
                HoldAllHands(dealer);
                return;
            }

            Console.WriteLine("Dealer getting cards.");

            while ((!dealer.DealerPlayer.HandBusted && !dealer.DealerPlayer.HandHeld) &&
                   (dealer.DealerPlayer.PlayerHand.TotalHand() < Dealer.DealerMinHandValue))
            {
                dealer.DealerPlayer.DoHit(dealer.Deck);
            }

            if (dealer.DealerPlayer.HandBusted)
            {
                Console.WriteLine("Dealer has busted, everyone wins.");
            }
        }

        private static string GetCardString(Card card)
        {
            var retStr = "";
            if ((card.Value >= 2) && (card.Value <= 10))
            {
                retStr += $"{card.Value, -2} ";
            }
            else
            {
                switch (card.Value)
                {
                    case Card.Ace:
                        retStr += "A  ";
                        break;

                    case Card.Jack:
                        retStr += "J  ";
                        break;

                    case Card.Queen:
                        retStr += "Q  ";
                        break;

                    case Card.King:
                        retStr += "K  ";
                        break;
                }
            }

            switch (card.Suit)
            {
                case Card.Suits.Club:
                    retStr += "Club   ";
                    break;

                case Card.Suits.Heart:
                    retStr += "Heart  ";
                    break;

                case Card.Suits.Spade:
                    retStr += "Spade  ";
                    break;

                case Card.Suits.Diamond:
                    retStr += "Diamond";
                    break;

            }

            return retStr;
        }

        private static void HoldAllHands(Dealer dealer)
        {
            foreach (var player in dealer.Players)
            {
                player.HandHeld = true;
            }
        }

        private static void FindWinners(Dealer dealer)
        {
            foreach (var player in dealer.Players)
            {
                if (dealer.DealerPlayer.HasBackJack())
                {
                    Console.WriteLine($"{player.Name} lost {player.Bet} to Dealer BlackJack.");
                    player.AdjustMoneyTotal(true);
                }
                else if (!player.HandBusted && (player.PlayerHand.Cards.Count == Hand.MaxCardsInHand))
                {
                    Console.WriteLine($"{player.Name} wins with maximum cards, adding {player.Bet} to total.");
                    player.AdjustMoneyTotal(false);
                }
                else if (player.HandBusted)
                {
                    Console.WriteLine($"{player.Name}'s bet of {player.Bet} is lost.");
                    player.AdjustMoneyTotal(true);
                }
                else if (dealer.DealerPlayer.HandBusted ||
                     (player.PlayerHand.TotalHand() > dealer.DealerPlayer.PlayerHand.TotalHand()))
                {
                    Console.WriteLine($"{player.Name} wins, adding {player.Bet} to total.");
                    player.AdjustMoneyTotal(false);
                }
                else if (player.PlayerHand.TotalHand() == dealer.DealerPlayer.PlayerHand.TotalHand())
                {
                    Console.WriteLine($"{player.Name} tied, no winner.");
                }
                else if (player.PlayerHand.TotalHand() < dealer.DealerPlayer.PlayerHand.TotalHand())
                {
                    Console.WriteLine($"Dealer bets {player.Name}'s hand, bet of {player.Bet} is lost.");
                    player.AdjustMoneyTotal(true);
                }
            }
        }

        private static bool DoYesNoPrompt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "y":
                        return true;

                    case "n":
                        return false;

                    default:
                        Console.WriteLine("Please enter a y or n.");
                        break;
                }
            }
        }

        private static void ClearAllHandsForNewGame(Dealer dealer)
        {
            dealer.DealerPlayer.ClearHand();
            foreach (var player in dealer.Players)
            {
                player.ClearHand();
            }
        }
    }
}
