
using System.Numerics;
using TicTacToe.Library;

namespace TicTacToe.AIPlayer
{
    public class Player
    {
        private const int WinScore = 100;
        private const int LoseScore = -100;
        private const int DrawScore = 0;

        public static AICell GetAIPlacement(Cell[,] board)
        {
            var bestScore = int.MinValue;
            var bestRow = -1;
            var bestCol = -1;

            for (var row = 0; row < Library.TicTacToe.BoardSize; row++)
            {
                for (var column = 0; column < Library.TicTacToe.BoardSize; column++)
                {
                    if (board[row, column].State == Cell.CellStates.Open)
                    {
                        board[row, column].State = Cell.CellStates.Computer;
                        var score = Minimax(board, 0, false);
                        board[row, column].State = Cell.CellStates.Open;

                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestRow = row;
                            bestCol = column;
                        }
                    }
                }
            }

            return new AICell(bestRow, bestCol);
        }

        private static int Minimax(Cell[,] currentBoard, int depth, bool isMaximizing)
        {
            if (IsWinning(currentBoard, Cell.CellStates.Computer))
            {
                return WinScore - depth;
            }

            if (IsWinning(currentBoard, Cell.CellStates.Player1))
            {
                return LoseScore + depth;
            }

            if (Library.TicTacToe.OpenCells(currentBoard) == 0)
            {
                return DrawScore;
            }

            if (isMaximizing)
            {
                var bestScore = int.MinValue;
                for (var row = 0; row < Library.TicTacToe.BoardSize; row ++)
                {
                    for (var column = 0; column < Library.TicTacToe.BoardSize; column ++)
                    {
                        if (currentBoard[row, column].State == Cell.CellStates.Open)
                        {
                            currentBoard[row, column].State = Cell.CellStates.Computer;
                            var score = Minimax(currentBoard, depth + 1, false);
                            currentBoard[row, column].State = Cell.CellStates.Open;
                            bestScore = Math.Max(score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                var bestScore = int.MaxValue;
                for (var row = 0; row < Library.TicTacToe.BoardSize; row++)
                {
                    for (var column = 0; column < Library.TicTacToe.BoardSize; column++)
                    {
                        if (currentBoard[row, column].State == Cell.CellStates.Open)
                        {
                            currentBoard[row, column].State = Cell.CellStates.Player1;
                            var score = Minimax(currentBoard, depth + 1, true);
                            currentBoard[row, column].State = Cell.CellStates.Open;
                            bestScore = Math.Min(score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
        }

        private static bool IsWinning(Cell[,] board, Library.Cell.CellStates player)
        {
            // Check rows
            for (var row = 0; row < Library.TicTacToe.BoardSize; row ++)
            {
                if ((board[row, 0].State == player) &&
                    (board[row, 1].State == player) &&
                    (board[row, 2].State == player))
                {
                    return true;
                }
            }

            // Check columns
            for (var column = 0; column < Library.TicTacToe.BoardSize; column ++)
            {
                if ((board[0, column].State == player) &&
                    (board[1, column].State == player) &&
                    (board[2, column].State == player))
                {
                    return true;
                }
            }

            // Check diagonals
            if ((board[0, 0].State == player) &&
                (board[1, 1].State == player) &&
                (board[2, 2].State == player))
            {
                return true;
            }

            return (board[0, 2].State == player) &&
                   (board[1, 1].State == player) &&
                   (board[2, 0].State == player);
        }
    }
}