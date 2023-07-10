
namespace TicTacToe.Library
{
    public class Cell
    {
        public enum CellStates
        {
            Open,
            Player1,
            Player2,
            Computer
        }

        public CellStates State { get; set; }

        public Cell()
        {
            State = CellStates.Open;
        }

    }
}
