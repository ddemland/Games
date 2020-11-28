using System;
using MineSweeper.Engine;

namespace MineSweeper.Text
{
    class Program
    {
        enum SelectTypes
        {
            PickSquare,
            MarkSquare,
            ClearMark,
            BadInput
        }

        private const int BoardWidth = 10;
        private const int BoardHeight = 10;
        private const int MinesOnBoard = 10;

        static void Main(string[] args)
        {
            var game = new Board();
            var done = false;

            while (!done)
            {
                game.Init(BoardWidth, BoardHeight, MinesOnBoard);
                game.SetMines();
                game.FillInMineCounts();

                while (!game.GameOver)
                {
                    DisplayGameBoard(game, false);
                    GetPickInput(out var type, out var row, out var column);

                    switch (type)
                    {
                        case SelectTypes.PickSquare:
                            if (game.Squares[row, column].Marked)
                            {
                                Console.WriteLine("Square is Marked, Can Not Step On ...");
                            }
                            else
                            {
                                game.PickSquare(row, column);
                            }
                            break;

                        case SelectTypes.ClearMark:
                            if (game.Squares[row, column].Marked)
                            {
                                game.ClearMarkSquare(row, column);
                            }
                            break;

                        case SelectTypes.MarkSquare:
                            if (game.Squares[row, column].Covered)
                            {
                                game.MarkSquare(row, column);
                            }
                            break;
                    }
                }

                if (game.Winner)
                {
                    Console.WriteLine("You Won!!!!");
                    DisplayGameBoard(game, true);
                }
                else
                {
                    Console.WriteLine("You Lost!");
                    DisplayGameBoard(game, true);
                }

                done = !PlayAgainInput();
            }
        }

        private static void DisplayGameBoard(Board board, bool displayMines)
        {
            var header = "   ";
            for (var cnt = 0; cnt < BoardWidth; cnt++)
            {
                header += $"{cnt}  ";
            }

            Console.WriteLine(header);
            for (var row = 0; row < BoardWidth; row++)
            {
                var line = $"{row}: ";
                for (var column = 0; column < BoardHeight; column++)
                {
                    if (board.Squares[row, column].Covered)
                    {
                        line += board.Squares[row, column].Marked ? "M" : "-";
                    }
                    else
                    {
                        if (displayMines && board.Squares[row, column].HasMine)
                        {
                            line += "*";
                        }
                        else if (board.Squares[row, column].NearByMineCnt == 0)
                        {
                            line += " ";
                        }
                        else
                        {
                            line += board.Squares[row, column].NearByMineCnt.ToString();
                        }
                    }

                    line += "  ";
                }

                Console.WriteLine(line);
            }
        }

        private static void GetPickInput(out SelectTypes type, out int row, out int column)
        {
            type = SelectTypes.BadInput;
            while (type == SelectTypes.BadInput)
            {
                Console.Write("Please Enter (P)ick, (M)ark, or (C)lear: ");
                var ch = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();

                type = ch.ToLower() switch
                {
                    "p" => SelectTypes.PickSquare,
                    "m" => SelectTypes.MarkSquare,
                    "c" => SelectTypes.ClearMark,
                    _ => type
                };

                if (type == SelectTypes.BadInput)
                {
                    Console.WriteLine("Please Enter P, M, or C.");
                }
            }

            row = GetRowColumnInput(true);
            column = GetRowColumnInput(false);
        }

        private static int GetRowColumnInput(bool rowFlag)
        {
            var promptStr = rowFlag ? "Row" : "Column";
            var done = false;
            var value = -1;

            do
            {
                Console.Write($"Please Enter a Value for the {promptStr}: ");
                var ch = Console.ReadKey().KeyChar - '0';
                Console.WriteLine();

                if ((ch < 0) || (ch > 9))
                {
                    Console.WriteLine("Please enter a value between 0 and 9.");
                    continue;
                }

                value = ch;
                done = true;
            } while (!done);

            return value;
        }

        private static bool PlayAgainInput()
        {
            while (true)
            {
                Console.Write("Do you want to play again (y/n)? ");
                var ch = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();

                switch (ch)
                {
                    case "y":
                        return true;

                    case "n":
                        return false;
                }

                Console.WriteLine("Please Enter P, M, or C.");
            }
        }
    }
}
