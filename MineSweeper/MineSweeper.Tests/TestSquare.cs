using MineSweeper.Engine;
using NUnit.Framework;

namespace MineSweeper.Tests
{
    public class TestSquare
    {
        [Test]
        public void TestBasicSquare()
        {
            var square = new Square();
            Assert.IsFalse(square.HasMine);
            Assert.IsFalse(square.Marked);
            Assert.IsFalse(square.Covered);
            Assert.AreEqual(0, square.NearByMineCnt);

            square.HasMine = true;
            square.Marked = true;
            square.Covered = true;
            square.NearByMineCnt = 2;

            Assert.IsTrue(square.HasMine);
            Assert.IsTrue(square.Marked);
            Assert.IsTrue(square.Covered);
            Assert.AreEqual(2, square.NearByMineCnt);
        }
    }
}