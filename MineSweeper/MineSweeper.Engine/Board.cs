
using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper.Engine
{
    public class Board
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int MineCnt { get; private set; }
        public Square[,] Squares { get; set; }
        public bool GameOver { get; private set; }
        public bool Winner { get; private set; }

        public void Init(int width, int height, int mineCnt)
        {
            GameOver = false;
            Winner = false;
            Squares = new Square[width, height];
            Width = width;
            Height = height;
            MineCnt = mineCnt;

            for (var row = 0; row < Width; row++)
            {
                for (var column = 0; column < Height; column++)
                {
                    Squares[row, column] = new Square
                    {
                        Covered = true
                    };
                }
            }
        }

        public void SetMines()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var cnt = 0;

            while (cnt < MineCnt)
            {
                var row = rnd.Next(Width);
                var column = rnd.Next(Height);
                var square = Squares[row, column];
                if (square.HasMine)
                {
                    continue;
                }

                square.HasMine = true;
                cnt ++;
                rnd = new Random(DateTime.Now.Millisecond);
            }
        }

        public void FillInMineCounts()
        {
            for (var row = 0; row < Width; row++)
            {
                for (var column = 0; column < Height; column++)
                {
                    if (Squares[row, column].HasMine)
                    {
                        continue;
                    }

                    var neighbors = GetNeighbors(row, column);
                    var total = neighbors.Count(s => s.HasMine);
                    Squares[row, column].NearByMineCnt = total;
                }
            }
        }

        public void PickSquare(int row, int column)
        {
            if ((row >= Width) || (column >= Height) ||
                (row < 0) || (column < 0))
            {
                return;
            }

            if (Squares[row, column].HasMine)
            {
                GameOver = true;
                ClearAllSquares();
                return;
            }

            if (Squares[row, column].NearByMineCnt != 0)
            {
                Squares[row, column].Covered = false;
            }
            else
            {
                UncoverAdjacentSquares(row, column);
            }

            if (AllSquaresCompleted())
            {
                GameOver = true;
                Winner = true;
            }
        }

        public void MarkSquare(int row, int column)
        {
            if ((row >= Width) || (column >= Height) ||
                (row < 0) || (column < 0))
            {
                return;
            }

            if (Squares[row, column].Covered)
            {
                Squares[row, column].Marked = true;
            }

            if (AllSquaresCompleted())
            {
                GameOver = true;
                Winner = true;
            }
        }

        public void ClearMarkSquare(int row, int column)
        {
            if ((row >= Width) || (column >= Height) ||
                (row < 0) || (column < 0))
            {
                return;
            }

            if (Squares[row, column].Covered)
            {
                Squares[row, column].Marked = false;
            }
        }

        private IEnumerable<Square> GetNeighbors(int row, int column)
        {
            var squareList = new List<Square>();
            if ((row - 1 >= 0) && (column >= 0))
            {
                squareList.Add(Squares[row -1, column]);
            }

            if ((row + 1 < Width) && (column >= 0))
            {
                squareList.Add(Squares[row + 1, column]);
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                squareList.Add(Squares[row - 1, column - 1]);
            }

            if ((row + 1 < Width) && (column - 1 >= 0))
            {
                squareList.Add(Squares[row + 1, column - 1]);
            }

            if ((row + 1 < Width) && (column + 1 < Width))
            {
                squareList.Add(Squares[row + 1, column + 1]);
            }

            if ((row >= 0) && (column - 1 > 0))
            {
                squareList.Add(Squares[row, column - 1]);
            }

            if ((row >= 0) && (column + 1 < Width))
            {
                squareList.Add(Squares[row, column + 1]);
            }

            if ((row - 1 >= 0) && (column + 1 < Width))
            {
                squareList.Add(Squares[row - 1, column + 1]);
            }

            return squareList;
        }

        private void UncoverAdjacentSquares(int row, int column)
        {
            if ((row >= Width) || (column >= Height) ||
                (row < 0) || (column < 0))
            {
                return;
            }

            if (Squares[row, column].NearByMineCnt > 0)
            {
                Squares[row, column].Covered = false;
            }
            else if (Squares[row, column].Covered)
            {
                Squares[row, column].Covered = false;

                PickSquare(row + 1, column);
                PickSquare(row + 1, column + 1);
                PickSquare(row, column + 1);
                PickSquare(row - 1, column + 1);
                PickSquare(row - 1, column);
                PickSquare(row - 1, column - 1);
                PickSquare(row, column - 1);
                PickSquare(row + 1, column - 1);
            }
        }

        private void ClearAllSquares()
        {
            for (var row = 0; row < Width; row++)
            {
                for (var column = 0; column < Height; column++)
                {
                    Squares[row, column].Covered = false;
                }
            }
        }

        private bool AllSquaresCompleted()
        {
            for (var row = 0; row < Width; row++)
            {
                for (var column = 0; column < Height; column++)
                {
                    if (Squares[row, column].Covered && !Squares[row, column].Marked)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
