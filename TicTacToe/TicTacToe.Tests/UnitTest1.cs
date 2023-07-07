
using TicTacToe.Library;

namespace TicTacToe.Tests
{
    public class Tests
    {
        [Test]
        public void TestCellState()
        {
            var cell = new Cell();
            Assert.AreEqual(Cell.CellStates.Open, cell.State);
            cell.State = Cell.CellStates.Player1;
            Assert.AreEqual(Cell.CellStates.Player1, cell.State);
        }

        [Test]
        public void TestBoardCellState()
        {
            var board = new Library.TicTacToe();
            for (var row = 0; row < Library.TicTacToe.BoardSize; row ++)
            {
                for (var column = 0; column < Library.TicTacToe.BoardSize; column ++)
                {
                    var cell = board.Board[row, column];
                    Assert.AreEqual(Cell.CellStates.Open, cell.State);
                }
            }

            Assert.IsTrue(board.SetCellState(1, 1, Cell.CellStates.Player1));
            Assert.AreEqual(Cell.CellStates.Player1, board.Board[1, 1].State);
            Assert.IsFalse(board.SetCellState(1, 1, Cell.CellStates.Player2));
        }

        [Test]
        public void TestStartOfGameWinStatus()
        {
            var board = new Library.TicTacToe();
            Assert.AreEqual(Library.TicTacToe.WinStatus.NoWinner, board.GetWinStatus());
        }

        [Test]
        public void TestRow1Player1WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 0].State = Cell.CellStates.Player1;
            board.Board[0, 1].State = Cell.CellStates.Player1;
            board.Board[0, 2].State = Cell.CellStates.Player1;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player1, board.GetWinStatus());
        }

        [Test]
        public void TestRow2Player1WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[1, 0].State = Cell.CellStates.Player1;
            board.Board[1, 1].State = Cell.CellStates.Player1;
            board.Board[1, 2].State = Cell.CellStates.Player1;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player1, board.GetWinStatus());
        }

        [Test]
        public void TestRow3Player1WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[2, 0].State = Cell.CellStates.Player1;
            board.Board[2, 1].State = Cell.CellStates.Player1;
            board.Board[2, 2].State = Cell.CellStates.Player1;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player1, board.GetWinStatus());
        }

        [Test]
        public void TestColumn1Player1WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 0].State = Cell.CellStates.Player1;
            board.Board[1, 0].State = Cell.CellStates.Player1;
            board.Board[2, 0].State = Cell.CellStates.Player1;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player1, board.GetWinStatus());
        }

        [Test]
        public void TestColumn2Player1WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 1].State = Cell.CellStates.Player1;
            board.Board[1, 1].State = Cell.CellStates.Player1;
            board.Board[2, 1].State = Cell.CellStates.Player1;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player1, board.GetWinStatus());
        }

        [Test]
        public void TestColumn3Player1WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 2].State = Cell.CellStates.Player1;
            board.Board[1, 2].State = Cell.CellStates.Player1;
            board.Board[2, 2].State = Cell.CellStates.Player1;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player1, board.GetWinStatus());
        }

        [Test]
        public void TestDiagonalPlayer1WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 2].State = Cell.CellStates.Player1;
            board.Board[1, 1].State = Cell.CellStates.Player1;
            board.Board[2, 0].State = Cell.CellStates.Player1;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player1, board.GetWinStatus());
        }

        [Test]
        public void TestRevDiagonalPlayer1WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 0].State = Cell.CellStates.Player1;
            board.Board[1, 1].State = Cell.CellStates.Player1;
            board.Board[2, 2].State = Cell.CellStates.Player1;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player1, board.GetWinStatus());
        }

        [Test]
        public void TestRow1Player2WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 0].State = Cell.CellStates.Player2;
            board.Board[0, 1].State = Cell.CellStates.Player2;
            board.Board[0, 2].State = Cell.CellStates.Player2;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player2, board.GetWinStatus());
        }

        [Test]
        public void TestRow2Player2WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[1, 0].State = Cell.CellStates.Player2;
            board.Board[1, 1].State = Cell.CellStates.Player2;
            board.Board[1, 2].State = Cell.CellStates.Player2;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player2, board.GetWinStatus());
        }

        [Test]
        public void TestRow3Player2WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[2, 0].State = Cell.CellStates.Player2;
            board.Board[2, 1].State = Cell.CellStates.Player2;
            board.Board[2, 2].State = Cell.CellStates.Player2;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player2, board.GetWinStatus());
        }

        [Test]
        public void TestColumn1Player2WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 0].State = Cell.CellStates.Player2;
            board.Board[1, 0].State = Cell.CellStates.Player2;
            board.Board[2, 0].State = Cell.CellStates.Player2;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player2, board.GetWinStatus());
        }

        [Test]
        public void TestColumn2Player2WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 1].State = Cell.CellStates.Player2;
            board.Board[1, 1].State = Cell.CellStates.Player2;
            board.Board[2, 1].State = Cell.CellStates.Player2;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player2, board.GetWinStatus());
        }

        [Test]
        public void TestColumn3Player2WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 2].State = Cell.CellStates.Player2;
            board.Board[1, 2].State = Cell.CellStates.Player2;
            board.Board[2, 2].State = Cell.CellStates.Player2;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player2, board.GetWinStatus());
        }

        [Test]
        public void TestDiagonalPlayer2WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 2].State = Cell.CellStates.Player2;
            board.Board[1, 1].State = Cell.CellStates.Player2;
            board.Board[2, 0].State = Cell.CellStates.Player2;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player2, board.GetWinStatus());
        }

        [Test]
        public void TestRevDiagonalPlayer2WinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 0].State = Cell.CellStates.Player2;
            board.Board[1, 1].State = Cell.CellStates.Player2;
            board.Board[2, 2].State = Cell.CellStates.Player2;
            Assert.AreEqual(Library.TicTacToe.WinStatus.Player2, board.GetWinStatus());
        }

        [Test]
        public void TestOpenCells()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 0].State = Cell.CellStates.Player2;
            Assert.AreEqual(8, board.OpenCells());
            board.Board[0, 1].State = Cell.CellStates.Player1;
            Assert.AreEqual(7, board.OpenCells());
            board.Board[0, 2].State = Cell.CellStates.Player2;
            Assert.AreEqual(6, board.OpenCells());

            board.Board[1, 0].State = Cell.CellStates.Player1;
            Assert.AreEqual(5, board.OpenCells());
            board.Board[1, 1].State = Cell.CellStates.Player2;
            Assert.AreEqual(4, board.OpenCells());
            board.Board[1, 2].State = Cell.CellStates.Player1;
            Assert.AreEqual(3, board.OpenCells());

            board.Board[2, 0].State = Cell.CellStates.Player1;
            Assert.AreEqual(2, board.OpenCells());
            board.Board[2, 1].State = Cell.CellStates.Player2;
            Assert.AreEqual(1, board.OpenCells());
            board.Board[2, 2].State = Cell.CellStates.Player1;
            Assert.AreEqual(0, board.OpenCells());

            Assert.AreEqual(Library.TicTacToe.WinStatus.NoWinner, board.GetWinStatus());
        }

        [Test]
        public void TestIncorrectWinStatus()
        {
            var board = new Library.TicTacToe();
            board.Board[0, 0].State = Cell.CellStates.Player1;
            board.Board[1, 1].State = Cell.CellStates.Player2;
            Assert.AreEqual(Library.TicTacToe.WinStatus.NoWinner, board.GetWinStatus());
        }
    }
}