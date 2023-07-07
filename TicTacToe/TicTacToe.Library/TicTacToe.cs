using System.IO.Compression;

namespace TicTacToe.Library
{
    public class TicTacToe
    {
        public enum WinStatus
        {
            NoWinner,
            Player1,
            Player2
        }

        public const int BoardSize = 3;
        public Cell[,] Board { get; set; }

        public TicTacToe()
        {
            Board = new Cell[BoardSize, BoardSize];
            for (var row = 0; row < BoardSize; row ++)
            {
                for (var column = 0; column < BoardSize; column ++)
                {
                    Board[row, column] = new Cell();
                }

            }
        }

        public bool SetCellState(int row, int column, Cell.CellStates cellState)
        {
            if (Board[row, column].State != Cell.CellStates.Open)
            {
                return false;
            }

            Board[row, column].State = cellState;
            return true;
        }

        public WinStatus GetWinStatus()
        {
            //  Row 1
            if (((Board[0, 0].State == Board[0, 1].State) &&
                (Board[0, 1].State == Board[0, 2].State)) &&
                (Board[0, 0].State != Cell.CellStates.Open))
            {
                return ConvertCellStateToWinStatus(Board[0, 0].State);
            }

            //  Row 2
            if (((Board[1, 0].State == Board[1, 1].State) &&
                (Board[1, 1].State == Board[1, 2].State)) &&
                (Board[1, 0].State != Cell.CellStates.Open))
            {
                return ConvertCellStateToWinStatus(Board[1, 0].State);
            }

            //  Row 3
            if (((Board[2, 0].State == Board[2, 1].State) &&
                (Board[2, 1].State == Board[2, 2].State)) &&
                (Board[2, 0].State != Cell.CellStates.Open))
            {
                return ConvertCellStateToWinStatus(Board[2, 0].State);
            }

            //  Column 1
            if (((Board[0, 0].State == Board[1, 0].State) &&
                (Board[1, 0].State == Board[2, 0].State)) &&
                (Board[0, 0].State != Cell.CellStates.Open))
            {
                return ConvertCellStateToWinStatus(Board[0, 0].State);
            }

            //  Column 2
            if (((Board[0, 1].State == Board[1, 1].State) &&
                (Board[1, 1].State == Board[2, 1].State)) &&
                (Board[0, 1].State != Cell.CellStates.Open))
            {
                return ConvertCellStateToWinStatus(Board[0, 1].State);
            }

            //  Column 3
            if (((Board[0, 2].State == Board[1, 2].State) &&
                (Board[1, 2].State == Board[2, 2].State)) &&
                (Board[0, 2].State != Cell.CellStates.Open))
            {
                return ConvertCellStateToWinStatus(Board[0, 2].State);
            }

            //  Diagonal
            if (((Board[2, 0].State == Board[1, 1].State) &&
                (Board[1, 1].State == Board[0, 2].State)) &&
                (Board[2, 0].State != Cell.CellStates.Open))
            {
                return ConvertCellStateToWinStatus(Board[2, 0].State);
            }

            //  Reverse Diagonal
            if (((Board[0, 0].State == Board[1, 1].State) &&
                (Board[1, 1].State == Board[2, 2].State)) &&
                (Board[0, 0].State != Cell.CellStates.Open))
            {
                return ConvertCellStateToWinStatus(Board[0, 0].State);
            }

            return WinStatus.NoWinner;
        }

        public int OpenCells()
        {
            var cnt = 0;
            for (var row = 0; row < TicTacToe.BoardSize; row++)
            {
                for (int column = 0; column < TicTacToe.BoardSize; column++)
                {
                    if (Board[row, column].State == Cell.CellStates.Open)
                    {
                        cnt ++;
                    }
                }
            }

            return cnt;
        }

        private WinStatus ConvertCellStateToWinStatus(Cell.CellStates cellState)
        {
            return cellState switch
            {
                Cell.CellStates.Player1 => WinStatus.Player1,
                Cell.CellStates.Player2 => WinStatus.Player2,
                _ => WinStatus.NoWinner
            };
        }
    }
}