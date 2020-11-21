
using MasterMind.Engine;
using NUnit.Framework;

namespace MasterMind.Tests
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    [TestFixture]
    public class NUnitTester
	{
        [Test]
        public void HandCreation()
        {
            var checkColorPtr = new int[1];
            int cnt;
            var hand = new Hand();

            hand.GetColors(ref checkColorPtr);
            for (cnt = 0; cnt < Hand.MaxHand; cnt++)
            {
                Assert.AreEqual(Hand.NoColor, checkColorPtr[cnt]);
            }
        }

        [Test]
        public void HandSetColors()
        {
            int[] colors = { Hand.Red, Hand.Blue, Hand.Green, Hand.Yellow };
            var checkColorPtr = new int[1];
            int cnt;
            var hand = new Hand();

            hand.GetColors(ref checkColorPtr);
            hand.SetColors(colors);

            hand.GetColors(ref checkColorPtr);
            for (cnt = 0; cnt < Hand.MaxHand; cnt++)
            {
                Assert.AreEqual(colors[cnt], checkColorPtr[cnt]);
            }
        }

        [Test]
        public void HandCompareInit()
        {
            var answerColorPtr = new int[Hand.MaxHand];
            int cnt;
            int[] colors = { Hand.Red, Hand.Blue, Hand.Green, Hand.Yellow };
            Hand hand1 = new Hand(), hand2 = new Hand();

            hand1.SetColors(colors);
            hand1.CompareHands(hand2, ref answerColorPtr);

            for (cnt = 0; cnt < Hand.MaxHand; cnt++)
            {
                Assert.AreEqual(Hand.NoColor, answerColorPtr[cnt]);
            }
        }

        [Test]
        public void HandCompareOneWrongPlace()
        {
            var answerColorPtr = new int[Hand.MaxHand];
            int[] colors = { Hand.Red, Hand.Blue, Hand.Green, Hand.Yellow };
            int[] colors2 = { Hand.Yellow, Hand.Purple, Hand.Purple, Hand.Purple };
            Hand hand1 = new Hand(), hand2 = new Hand();

            hand1.SetColors(colors);
            hand2.SetColors(colors2);
            hand1.CompareHands(hand2, ref answerColorPtr);

            Assert.AreEqual(Hand.White, answerColorPtr[0]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[1]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[2]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[3]);
        }

        [Test]
        public void HandCompareOneRightPlace()
        {
            var answerColorPtr = new int[Hand.MaxHand];
            int[] colors = { Hand.Red, Hand.Blue, Hand.Green, Hand.Yellow };
            int[] colors3 = { Hand.Red, Hand.Purple, Hand.Purple, Hand.Purple };
            Hand hand1 = new Hand(), hand2 = new Hand();

            hand1.SetColors(colors);
            hand2.SetColors(colors3);
            hand1.CompareHands(hand2, ref answerColorPtr);

            Assert.AreEqual(Hand.Black, answerColorPtr[0]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[1]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[2]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[3]);
        }

        [Test]
        public void HandCompareTwoRightPlaceTwoRight()
        {
            var answerColorPtr = new int[Hand.MaxHand];
            int[] colors = { Hand.Red, Hand.Blue, Hand.Green, Hand.Yellow };
            int[] colors4 = { Hand.Red, Hand.Green, Hand.Blue, Hand.Yellow };
            Hand hand1 = new Hand(), hand2 = new Hand();

            hand1.SetColors(colors);
            hand2.SetColors(colors4);
            hand1.CompareHands(hand2, ref answerColorPtr);

            Assert.AreEqual(Hand.Black, answerColorPtr[0]);
            Assert.AreEqual(Hand.Black, answerColorPtr[1]);
            Assert.AreEqual(Hand.White, answerColorPtr[2]);
            Assert.AreEqual(Hand.White, answerColorPtr[3]);
        }

        [Test]
        public void HandCompareOneRightPlaceOneRight()
        {
            var answerColorPtr = new int[Hand.MaxHand];
            int[] colors5 = { Hand.Red, Hand.Green, Hand.Green, Hand.Yellow };
            int[] colors6 = { Hand.Purple, Hand.Green, Hand.Purple, Hand.Green };
            Hand hand1 = new Hand(), hand2 = new Hand();

            hand1.SetColors(colors5);
            hand2.SetColors(colors6);
            hand1.CompareHands(hand2, ref answerColorPtr);

            Assert.AreEqual(Hand.Black, answerColorPtr[0]);
            Assert.AreEqual(Hand.White, answerColorPtr[1]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[2]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[3]);
        }

        [Test]
        public void HandCompareTwoRightPlace()
        {
            var answerColorPtr = new int[Hand.MaxHand];
            int[] colors7 = { Hand.Green, Hand.Red, Hand.Orange, Hand.Yellow };
            int[] colors8 = { Hand.Red, Hand.Red, Hand.Yellow, Hand.Yellow };
            Hand hand1 = new Hand(), hand2 = new Hand();

            hand1.SetColors(colors7);
            hand2.SetColors(colors8);
            hand1.CompareHands(hand2, ref answerColorPtr);

            Assert.AreEqual(Hand.Black, answerColorPtr[0]);
            Assert.AreEqual(Hand.Black, answerColorPtr[1]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[2]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[3]);
        }

        [Test]
        public void HandCompareTwoRightWrongPlace()
        {
            var answerColorPtr = new int[Hand.MaxHand];
            int[] colors9 = { Hand.Yellow, Hand.Orange, Hand.Blue, Hand.Blue };
            int[] colors10 = { Hand.Blue, Hand.Blue, Hand.Purple, Hand.Purple };
            Hand hand1 = new Hand(), hand2 = new Hand();

            hand1.SetColors(colors9);
            hand2.SetColors(colors10);
            hand1.CompareHands(hand2, ref answerColorPtr);

            Assert.AreEqual(Hand.White, answerColorPtr[0]);
            Assert.AreEqual(Hand.White, answerColorPtr[1]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[2]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[3]);
        }

        [Test]
        public void HandCompareTwoRightOneExtraWrongPlace()
        {
            var answerColorPtr = new int[Hand.MaxHand];
            int[] colors11 = { Hand.Purple, Hand.Yellow, Hand.Orange, Hand.Orange };
            int[] colors12 = { Hand.Purple, Hand.Red, Hand.Orange, Hand.Green };
            Hand hand1 = new Hand(), hand2 = new Hand();

            hand1.SetColors(colors11);
            hand2.SetColors(colors12);
            hand1.CompareHands(hand2, ref answerColorPtr);

            Assert.AreEqual(Hand.Black, answerColorPtr[0]);
            Assert.AreEqual(Hand.Black, answerColorPtr[1]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[2]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[3]);
        }

        [Test]
        public void HandCompareThreeRightOneWrong()
        {
            var answerColorPtr = new int[Hand.MaxHand];
            int[] colors13 = { Hand.Green, Hand.Orange, Hand.Red, Hand.Green };
            int[] colors14 = { Hand.Yellow, Hand.Orange, Hand.Red, Hand.Green };
            Hand hand1 = new Hand(), hand2 = new Hand();

            hand1.SetColors(colors13);
            hand2.SetColors(colors14);
            hand1.CompareHands(hand2, ref answerColorPtr);

            Assert.AreEqual(Hand.Black, answerColorPtr[0]);
            Assert.AreEqual(Hand.Black, answerColorPtr[1]);
            Assert.AreEqual(Hand.Black, answerColorPtr[2]);
            Assert.AreEqual(Hand.NoColor, answerColorPtr[3]);
        }

        [Test]
        public void HandSameMismatched()
        {
            int[] colors = { Hand.Red, Hand.Blue, Hand.Green, Hand.Yellow };
            int[] colors2 = { Hand.Yellow, Hand.Purple, Hand.Purple, Hand.Purple };
            Hand hand1 = new Hand(), hand2 = new Hand();

            hand1.SetColors(colors);
            hand2.SetColors(colors2);

            Assert.IsFalse(hand1.HandsSame(hand2));
        }

        [Test]
        public void HandSameMatched()
        {
            int[] colors3 = { Hand.Red, Hand.Blue, Hand.Green, Hand.Yellow };
            var hand2 = new Hand();

            hand2.SetColors(colors3);
        }
    }
}
