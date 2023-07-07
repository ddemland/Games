
var gameBoard = new TicTacToe.Library.TicTacToe();

var isPlayer1 = true;
do
{
    DisplayBoard(gameBoard);

    while (true)
    {
        var displayStr = isPlayer1 ? "Player 1" : "Player 2";
        var cellStat =
            isPlayer1 ? TicTacToe.Library.Cell.CellStates.Player1 :
                            TicTacToe.Library.Cell.CellStates.Player2;
        GetUserInput(out var inputRow, out var inputColumn, displayStr);
        if (gameBoard.SetCellState(inputRow, inputColumn, cellStat))
        {
            break;
        }

        Console.WriteLine("That cell is already taken.");
    }

    isPlayer1 = !isPlayer1;
} while ((gameBoard.GetWinStatus() == TicTacToe.Library.TicTacToe.WinStatus.NoWinner) &&
         (gameBoard.OpenCells() > 0));

DisplayBoard(gameBoard);
switch (gameBoard.GetWinStatus())
{
    case TicTacToe.Library.TicTacToe.WinStatus.Player1:
        Console.WriteLine("Player 1 Wins!!!!");
        break;

    case TicTacToe.Library.TicTacToe.WinStatus.Player2:
        Console.WriteLine("Player 2 Wins!!!!");
        break;

    case TicTacToe.Library.TicTacToe.WinStatus.NoWinner:
    default:
        Console.WriteLine("Game tied no winner.");
        break;
}

void DisplayBoard(TicTacToe.Library.TicTacToe tttObj)
{
    var board = tttObj.Board;
    Console.WriteLine("     0   1   2");
    Console.WriteLine("   +---+---+---+");
    for (var row = 0; row < TicTacToe.Library.TicTacToe.BoardSize; row++)
    {
        Console.Write($" {row} | ");
        for (var column = 0; column < TicTacToe.Library.TicTacToe.BoardSize; column++)
        {
            var cell = board[row, column];
            Console.Write($"{GetCellOutput(cell)} | ");
        }

        Console.WriteLine();
        Console.WriteLine("   +---+---+---+");
    }
}

string GetCellOutput(TicTacToe.Library.Cell cell)
{
    return cell.State switch
    {
        TicTacToe.Library.Cell.CellStates.Player1 => "X",
        TicTacToe.Library.Cell.CellStates.Player2 => "O",
        _ => " "
    };
}

void GetUserInput(out int row, out int column, string playerStr)
{
    int inRow, inColumn;
    do
    {
        Console.Write($"{playerStr} please enter the row: ");
        inRow = Convert.ToInt32(Console.ReadLine());
        if (inRow is >= 0 and <= 2)
        {
            break;
        }

        Console.WriteLine("Enter a number between 0 and 2.");
    } while (true);

    do
    {
        Console.Write($"{playerStr} Please enter the column: ");
        inColumn = Convert.ToInt32(Console.ReadLine());
        if (inColumn is >= 0 and <= 2)
        {
            break;
        }

        Console.WriteLine("Enter a number between 0 and 2.");
    } while (true);

    row = inRow;
    column = inColumn;
}