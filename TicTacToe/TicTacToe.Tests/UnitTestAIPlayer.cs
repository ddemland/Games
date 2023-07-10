
using TicTacToe.Library;

namespace TicTacToe.Tests
{
    public class UnitTestAIPlayer
    {
        [Test]
        public void TestAIPlacement()
        {
            var board = new Library.TicTacToe().Board;
            var aiCell = AIPlayer.Player.GetAIPlacement(board);
            Assert.AreEqual(0, aiCell.Row);
            Assert.AreEqual(0, aiCell.Column);

            board[0, 0].State = Cell.CellStates.Player1;
            aiCell = AIPlayer.Player.GetAIPlacement(board);
            Assert.AreEqual(1, aiCell.Row);
            Assert.AreEqual(1, aiCell.Column);
        }

        [Test]
        public void TestAIGoesFirstPlacement()
        {
            var board = new Library.TicTacToe().Board;
            var aiCell = AIPlayer.Player.GetAIPlacement(board);
            Assert.AreEqual(0, aiCell.Row);
            Assert.AreEqual(0, aiCell.Column);
            board[0, 0].State = Cell.CellStates.Computer;

            board[1, 1].State = Cell.CellStates.Player1;
            aiCell = AIPlayer.Player.GetAIPlacement(board);
            Assert.AreEqual(0, aiCell.Row);
            Assert.AreEqual(1, aiCell.Column);
        }

        [Test]
        public void TestAIWins()
        {
            var board = new Library.TicTacToe().Board;
            board[0, 0].State = Cell.CellStates.Player1;
            board[2, 1].State = Cell.CellStates.Player1;
            board[2, 2].State = Cell.CellStates.Player1;
            board[1, 0].State = Cell.CellStates.Computer;
            board[0, 2].State = Cell.CellStates.Computer;
            board[1, 2].State = Cell.CellStates.Computer;

             var aiCell = AIPlayer.Player.GetAIPlacement(board);
            Assert.AreEqual(1, aiCell.Row);
            Assert.AreEqual(1, aiCell.Column);
        }
    }
}
