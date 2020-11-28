
using MineSweeper.Engine;
using NUnit.Framework;

namespace MineSweeper.Tests
{
    public class TestBoard
    {
        [Test]
        public void TestMineSetup()
        {
            var board = new Board();
            board.Init(10, 10, 10);
            board.SetMines();
            var mineCnt = CountMines(board);
            Assert.AreEqual(10, mineCnt);

            board.Init(10, 10, 3);
            board.SetMines();
            mineCnt = CountMines(board);
            Assert.AreEqual(3, mineCnt);
        }

        [Test]
        public void TestMineCounts()
        {
            var board = new Board();
            board.Init(10, 10, 10);

            board.Squares[6, 7].HasMine = true;
            board.Squares[8, 6].HasMine = true;
            board.Squares[8, 8].HasMine = true;
            board.FillInMineCounts();

            Assert.AreEqual(0, board.Squares[4, 7].NearByMineCnt);
            Assert.AreEqual(0, board.Squares[4, 8].NearByMineCnt);
            Assert.AreEqual(0, board.Squares[4, 9].NearByMineCnt);
            Assert.AreEqual(0, board.Squares[5, 5].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[5, 6].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[5, 7].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[5, 8].NearByMineCnt);
            Assert.AreEqual(0, board.Squares[5, 9].NearByMineCnt);
            Assert.AreEqual(0, board.Squares[6, 5].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[6, 6].NearByMineCnt);
            Assert.AreEqual(0, board.Squares[6, 7].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[6, 8].NearByMineCnt);
            Assert.AreEqual(0, board.Squares[6, 9].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[7, 5].NearByMineCnt);
            Assert.AreEqual(2, board.Squares[7, 6].NearByMineCnt);
            Assert.AreEqual(3, board.Squares[7, 7].NearByMineCnt);
            Assert.AreEqual(2, board.Squares[7, 8].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[7, 9].NearByMineCnt);
            Assert.AreEqual(0, board.Squares[8, 4].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[8, 5].NearByMineCnt);
            Assert.AreEqual(0, board.Squares[8, 6].NearByMineCnt);
            Assert.AreEqual(2, board.Squares[8, 7].NearByMineCnt);
            Assert.AreEqual(0, board.Squares[8, 8].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[8, 9].NearByMineCnt);
            Assert.AreEqual(0, board.Squares[9, 4].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[9, 5].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[9, 6].NearByMineCnt);
            Assert.AreEqual(2, board.Squares[9, 7].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[9, 8].NearByMineCnt);
            Assert.AreEqual(1, board.Squares[9, 9].NearByMineCnt);
        }

        [Test]
        public void TestPickClear()
        {
            var board = new Board();
            board.Init(10, 10, 10);

            board.Squares[6, 7].HasMine = true;
            board.Squares[8, 6].HasMine = true;
            board.Squares[8, 8].HasMine = true;
            board.FillInMineCounts();
            board.PickSquare(4, 4);

            for (var row = 0; row < 4; row++)
            {
                for (var column = 0; column < 10; column++)
                {
                    Assert.IsFalse(board.Squares[row, column].Covered);
                }
            }

            for (var row = 4; row < 10; row++)
            {
                for (var column = 0; column < 5; column++)
                {
                    Assert.IsFalse(board.Squares[row, column].Covered);
                }
            }

            Assert.IsFalse(board.Squares[4, 5].Covered);
            Assert.IsFalse(board.Squares[4, 6].Covered);
            Assert.IsFalse(board.Squares[4, 7].Covered);
            Assert.IsFalse(board.Squares[5, 5].Covered);
            Assert.IsFalse(board.Squares[6, 5].Covered);
        }

        [Test]
        public void TestWinner()
        {
            var board = new Board();
            board.Init(10, 10, 10);

            board.Squares[6, 7].HasMine = true;
            board.FillInMineCounts();
            board.PickSquare(4, 4);
            board.MarkSquare(6, 7);
            Assert.IsTrue(board.Winner);
        }

        [Test]
        public void TestMarkClearMark()
        {
            var board = new Board();
            board.Init(10, 10, 10);

            Assert.IsFalse(board.Squares[6, 7].Marked);
            board.MarkSquare(6, 7);
            Assert.IsTrue(board.Squares[6, 7].Marked);
            board.ClearMarkSquare(6, 7);
            Assert.IsFalse(board.Squares[6, 7].Marked);
        }

        private static int CountMines(Board board)
        {
            var mineCnt = 0;
            for (var row = 0; row < board.Width; row++)
            {
                for (var column = 0; column < board.Height; column++)
                {
                    if (board.Squares[row, column].HasMine)
                    {
                        mineCnt ++;
                    }
                }
            }

            return mineCnt;
        }
    }
}
