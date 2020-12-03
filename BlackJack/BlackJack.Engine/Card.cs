
namespace BlackJack.Engine
{
    public class Card
    {
        public enum Suits
        {
            Heart,
            Club,
            Diamond,
            Spade
        }

        public const int Ace = 1;
        public const int Jack = 11;
        public const int Queen = 12;
        public const int King = 13;

        public Suits Suit { get; }
        public int Value { get; }

        public Card(Suits suite, int value)
        {
            Suit = suite;
            Value = value;
        }
    }
}
