using NUnit.Framework;
using Othello.Engine;

namespace Othello.Tests
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>

    [TestFixture]
    public class NUnitTester
	{
        [Test]
        public void SquareSetGet()
        {
            var square = new Square();
            Assert.AreEqual(0, square.State);

            square.State = 4;
            Assert.AreEqual(4, square.State);
        }

        [Test]
        public void TurnOverSelect()
        {
            var square = new Square();
            Assert.IsFalse(square.TurnOverSelect);

            square.TurnOverSelect = true;
            Assert.IsTrue(square.TurnOverSelect);

            square.TurnOverSelect = false;
            Assert.IsFalse(square.TurnOverSelect);
        }

        [Test]
        public void GetSetSquareState()
        {
            var grid = new Grid();

            for (int row = 0; row < Grid.MaxSide; row++)
            {
                for (int column = 0; column < Grid.MaxSide; column++)
                {
                    Assert.AreEqual(Grid.StateEmpty, grid.GetSquareState(row, column));
                }
            }

            Assert.IsTrue(grid.SetSquareState(2, 2, 5));
            Assert.AreEqual(5, grid.GetSquareState(2, 2));
            Assert.IsFalse(grid.SetSquareState(-1, 2, 5));
            Assert.AreEqual(-1, grid.GetSquareState(-1, 2));
            Assert.IsFalse(grid.SetSquareState(2, -1, 5));
            Assert.AreEqual(-1, grid.GetSquareState(2, -1));
        }

        [Test]
        public void AllSquaresCovered()
        {
            int row, column;
            var grid = new Grid();

            Assert.IsFalse(grid.AllSquaresCovered());
            grid.SetSquareState(2, 2, 5);
            Assert.IsFalse(grid.AllSquaresCovered());

            for (row = 0; row < Grid.MaxSide; row++)
            {
                for (column = 0; column < Grid.MaxSide; column++)
                {
                    grid.SetSquareState(row, column, Grid.StatePlayer1);
                }
            }

            Assert.IsTrue(grid.AllSquaresCovered());

            for (row = 0; row < Grid.MaxSide; row++)
            {
                for (column = 0; column < Grid.MaxSide; column++)
                {
                    grid.SetSquareState(row, column, Grid.StatePlayer2);
                }
            }

            Assert.IsTrue(grid.AllSquaresCovered());

            for (row = 0; row < Grid.MaxSide; row++)
            {
                for (column = 0; column < Grid.MaxSide; column++)
                {
                    grid.SetSquareState(row, column, column % 2 == 0 ?
                        Grid.StatePlayer1 :
                        Grid.StatePlayer2);
                }
            }

            Assert.IsTrue(grid.AllSquaresCovered());
        }

        [Test]
        public void ClearAllSquares()
        {
            int row, column;
            var grid = new Grid();

            for (row = 0; row < Grid.MaxSide; row++)
            {
                for (column = 0; column < Grid.MaxSide; column++)
                {
                    Assert.AreNotEqual(0, grid.GetSquareState(row, column));
                }
            }

            grid.SetSquareState(1, 1, 5);
            grid.SetSquareState(2, 2, 5);
            grid.SetSquareState(3, 3, 5);
            grid.SetSquareState(4, 4, 5);
            grid.ClearAllSquares();

            for (row = 0; row < Grid.MaxSide; row++)
            {
                for (column = 0; column < Grid.MaxSide; column++)
                {
                    Assert.AreEqual(Grid.StateEmpty, grid.GetSquareState(row, column));
                }
            }
        }

        [Test]
        public void CountPlayerOneSquares()
        {
            var grid = new Grid();

            Assert.AreEqual(0, grid.CountPlayerOneSquares());

            grid.SetSquareState(1, 1, Grid.StatePlayer1);
            grid.SetSquareState(2, 2, Grid.StatePlayer1);
            grid.SetSquareState(3, 3, Grid.StatePlayer1);
            grid.SetSquareState(4, 4, Grid.StatePlayer1);

            Assert.AreEqual(4, grid.CountPlayerOneSquares());

            grid.SetSquareState(2, 1, Grid.StatePlayer2);
            grid.SetSquareState(3, 2, Grid.StatePlayer2);
            grid.SetSquareState(4, 3, Grid.StatePlayer2);
            grid.SetSquareState(5, 4, Grid.StatePlayer2);

            Assert.AreEqual(4, grid.CountPlayerOneSquares());
        }

        [Test]
        public void CountPlayerTwoSquares()
        {
            var grid = new Grid();

            Assert.AreEqual(0, grid.CountPlayerTwoSquares());

            grid.SetSquareState(1, 1, Grid.StatePlayer2);
            grid.SetSquareState(2, 2, Grid.StatePlayer2);
            grid.SetSquareState(3, 3, Grid.StatePlayer2);
            grid.SetSquareState(4, 4, Grid.StatePlayer2);

            Assert.AreEqual(4, grid.CountPlayerTwoSquares());

            grid.SetSquareState(2, 1, Grid.StatePlayer1);
            grid.SetSquareState(3, 2, Grid.StatePlayer1);
            grid.SetSquareState(4, 3, Grid.StatePlayer1);
            grid.SetSquareState(5, 4, Grid.StatePlayer1);

            Assert.AreEqual(4, grid.CountPlayerTwoSquares());
        }

        [Test]
        public void InitGame()
        {
            var grid = new Grid();

            grid.SetSquareState(0, 0, 8);
            grid.SetSquareState(1, 1, 8);
            grid.SetSquareState(2, 2, 8);
            grid.SetSquareState(3, 3, 8);
            grid.SetSquareState(4, 4, 8);

            grid.InitGame();

            bool testFail = false;
            for (int row = 0; row < Grid.MaxSide; row++)
            {
                for (int column = 0; column < Grid.MaxSide; column++)
                {
                    int state = grid.GetSquareState(row, column);

                    if ((((row == 3) && (column == 3)) ||
                        ((row == 4) && (column == 4))) &&
                        (state == Grid.StatePlayer1))
                    {
                        continue;
                    }

                    if ((((row == 3) && (column == 4)) ||
                        ((row == 4) && (column == 3))) &&
                        (state == Grid.StatePlayer2))
                    {
                        continue;
                    }

                    if (state != Grid.StateEmpty)
                    {
                        testFail = true;
                        break;
                    }
                }
            }

            Assert.IsFalse(testFail);
        }

        [Test]
        public void IsPlayerOneControl()
        {
            var grid = new Grid();

            Assert.IsFalse(grid.IsPlayerOneControl(1, 1));
            grid.SetSquareState(2, 2, Grid.StatePlayer1);
            Assert.IsTrue(grid.IsPlayerOneControl(2, 2));
            Assert.IsFalse(grid.IsPlayerOneControl(-1, 2));
            Assert.IsFalse(grid.IsPlayerOneControl(1, 12));
        }

        [Test]
        public void IsPlayerTwoControl()
        {
            var grid = new Grid();

            Assert.IsFalse(grid.IsPlayerTwoControl(1, 1));

            grid.SetSquareState(2, 2, Grid.StatePlayer2);
            Assert.IsTrue(grid.IsPlayerTwoControl(2, 2));
            Assert.IsFalse(grid.IsPlayerTwoControl(-1, 2));
            Assert.IsFalse(grid.IsPlayerTwoControl(1, 12));
        }

        [Test]
        public void SquareIsEmpty()
        {
            var grid = new Grid();

            grid.ClearAllSquares();

            for (int row = 0; row < Grid.MaxSide; row++)
            {
                for (int column = 0; column < Grid.MaxSide; column++)
                {
                    Assert.IsTrue(grid.SquareIsEmpty(row, column));
                }
            }
        }

        [Test]
        public void SetSquareEmpty()
        {
            var grid = new Grid();

            grid.SetSquareEmpty(2, 2);
            Assert.IsTrue(grid.SquareIsEmpty(2, 2));
            Assert.IsFalse(grid.SquareIsEmpty(-1, 2));
            Assert.IsFalse(grid.SquareIsEmpty(2, -1));
        }

        [Test]
        public void SetSquareToPlayer()
        {
            var grid = new Grid();

            grid.SetSquareToPlayer(2, 2, true);
            Assert.IsTrue(grid.IsPlayerOneControl(2, 2));
            grid.SetSquareToPlayer(2, 2, false);
            Assert.IsFalse(grid.IsPlayerOneControl(2, 2));
            grid.SetSquareToPlayer(-1, 2, false);
            Assert.IsFalse(grid.IsPlayerOneControl(-1, 2));
            grid.SetSquareToPlayer(2, -1, false);
            Assert.IsFalse(grid.IsPlayerOneControl(2, -1));
        }

        [Test]
        public void SetCanSelect()
        {
            var grid = new Grid();

            Assert.IsTrue(grid.SetCanSelect(1, 1));
            grid.ClearAllSquares();
            Assert.IsTrue(grid.SetCanSelect(2, 2));
            Assert.IsFalse(grid.SetCanSelect(-1, 2));
            Assert.IsFalse(grid.SetCanSelect(2, -1));
        }

        [Test]
        public void IsCanSelect()
        {
            var grid = new Grid();

            Assert.IsFalse(grid.IsCanSelect(1, 1));
            grid.ClearAllSquares();
            grid.SetCanSelect(2, 2);
            Assert.IsTrue(grid.IsCanSelect(2, 2));
        }

        [Test]
        public void ClearAllCanSelectSquares()
        {
            var grid = new Grid();

            grid.ClearAllCanSelectSquares();
            grid.SetCanSelect(1, 2);
            grid.SetCanSelect(2, 3);
            grid.SetCanSelect(3, 4);
            grid.SetCanSelect(4, 5);
            grid.ClearAllCanSelectSquares();

            for (int row = 0; row < Grid.MaxSide; row++)
            {
                for (int column = 0; column < Grid.MaxSide; column++)
                {
                    Assert.IsFalse(grid.IsCanSelect(row, column));
                }
            }
        }

        [Test]
        public void GridTurnOverSelect()
        {
            var grid = new Grid();

            for (int row = 0; row < Grid.MaxSide; row++)
            {
                for (int column = 0; column < Grid.MaxSide; column++)
                {
                    Assert.IsFalse(grid.IsTurnOverSelect(row, column));
                }
            }

            grid.SetTurnOverSelect(2, 2, true);
            Assert.IsTrue(grid.IsTurnOverSelect(2, 2));
            grid.SetTurnOverSelect(2, 2, false);
            Assert.IsFalse(grid.IsTurnOverSelect(2, 2));
        }

        [Test]
        public void TurnOverUpDown()
        {
            int row, column;
            var grid = new Grid();
            var squareList = new SquareList();

            grid.SetSquareToPlayer(0, 5, false);
            grid.SetSquareToPlayer(1, 5, true);
            grid.SetSquareToPlayer(2, 5, true);

            grid.SetSquareToPlayer(4, 5, true);
            grid.SetSquareToPlayer(5, 5, true);
            grid.SetSquareToPlayer(6, 5, false);

            grid.SetSquareEmpty(3, 5);
            grid.SetCanSelect(3, 5);
            Assert.AreNotEqual(0, grid.GetTurnOverList(3, 5, false, ref squareList));

            while (!squareList.AtEndOfList())
            {
                squareList.GetSquare(out row, out column);
                grid.SetTurnOverSelect(row, column, true);
                squareList.GoToNextSquare();
            }

            for (row = 0; row < Grid.MaxSide; row ++)
            {
                for (column = 0; column < Grid.MaxSide; column++)
                {
                    if (((row == 1) && (column == 5)) ||
                        ((row == 2) && (column == 5)) ||
                        ((row == 4) && (column == 5)) ||
                        ((row == 5) && (column == 5)))
                    {
                        Assert.IsTrue(grid.IsTurnOverSelect(row, column));
                    }
                    else
                    {
                        Assert.IsFalse(grid.IsTurnOverSelect(row, column));
                    }
                }
            }
        }

        [Test]
        public void TurnOverLeftRight()
        {
            int row, column;
            var grid = new Grid();
            var squareList = new SquareList();

            grid.SetSquareToPlayer(3, 1, false);
            grid.SetSquareToPlayer(3, 2, true);
            grid.SetSquareToPlayer(3, 3, true);

            grid.SetSquareToPlayer(3, 5, true);
            grid.SetSquareToPlayer(3, 6, true);
            grid.SetSquareToPlayer(3, 7, false);

            grid.SetSquareEmpty(3, 4);
            grid.SetCanSelect(3, 4);
            Assert.AreNotEqual(0, grid.GetTurnOverList(3, 4, false, ref squareList));

            while (!squareList.AtEndOfList())
            {
                squareList.GetSquare(out row, out column);
                grid.SetTurnOverSelect(row, column, true);
                squareList.GoToNextSquare();
            }

            for (row = 0; row < Grid.MaxSide; row ++)
            {
                for (column = 0; column < Grid.MaxSide; column++)
                {
                    if (((row == 3) && (column == 2)) ||
                        ((row == 3) && (column == 3)) ||
                        ((row == 3) && (column == 5)) ||
                        ((row == 3) && (column == 6)))
                    {
                        Assert.IsTrue(grid.IsTurnOverSelect(row, column));
                    }
                    else
                    {
                        Assert.IsFalse(grid.IsTurnOverSelect(row, column));
                    }
                }
            }
        }

        [Test]
        public void TurnOverUpperLeftLowerRight()
        {
            int row, column;
            var grid = new Grid();
            var squareList = new SquareList();

            grid.SetSquareToPlayer(0, 1, false);
            grid.SetSquareToPlayer(1, 2, true);
            grid.SetSquareToPlayer(2, 3, true);

            grid.SetSquareToPlayer(4, 5, true);
            grid.SetSquareToPlayer(5, 6, true);
            grid.SetSquareToPlayer(6, 7, false);

            grid.SetSquareEmpty(3, 4);
            grid.SetCanSelect(3, 4);
            Assert.AreNotEqual(0, grid.GetTurnOverList(3, 4, false, ref squareList));

            while (!squareList.AtEndOfList())
            {
                squareList.GetSquare(out row, out column);
                grid.SetTurnOverSelect(row, column, true);
                squareList.GoToNextSquare();
            }

            for (row = 0; row < Grid.MaxSide; row ++)
            {
                for (column = 0; column < Grid.MaxSide; column++)
                {
                    if (((row == 1) && (column == 2)) ||
                        ((row == 2) && (column == 3)) ||
                        ((row == 4) && (column == 5)) ||
                        ((row == 5) && (column == 6)))
                    {
                        Assert.IsTrue(grid.IsTurnOverSelect(row, column));
                    }
                    else
                    {
                        Assert.IsFalse(grid.IsTurnOverSelect(row, column));
                    }
                }
            }
        }

        [Test]
        public void TurnOverUpperRightLowerLeft()
        {
            int row, column;
            var grid = new Grid();
            var squareList = new SquareList();

            grid.SetSquareToPlayer(0, 7, false);
            grid.SetSquareToPlayer(1, 6, true);
            grid.SetSquareToPlayer(2, 5, true);

            grid.SetSquareToPlayer(4, 3, true);
            grid.SetSquareToPlayer(5, 2, true);
            grid.SetSquareToPlayer(6, 1, false);

            grid.SetSquareEmpty(3, 4);
            grid.SetCanSelect(3, 4);
            Assert.AreNotEqual(0, grid.GetTurnOverList(3, 4, false, ref squareList));

            while (!squareList.AtEndOfList())
            {
                squareList.GetSquare(out row, out column);
                grid.SetTurnOverSelect(row, column, true);
                squareList.GoToNextSquare();
            }

            for (row = 0; row < Grid.MaxSide; row ++)
            {
                for (column = 0; column < Grid.MaxSide; column++)
                {
                    if (((row == 1) && (column == 6)) ||
                        ((row == 2) && (column == 5)) ||
                        ((row == 4) && (column == 3)) ||
                        ((row == 5) && (column == 2)))
                    {
                        Assert.IsTrue(grid.IsTurnOverSelect(row, column));
                    }
                    else
                    {
                        Assert.IsFalse(grid.IsTurnOverSelect(row, column));
                    }
                }
            }
        }

        [Test]
        public void TurnOverWrongState()
        {
            var grid = new Grid();
            var squareList = new SquareList();

            Assert.AreEqual(0, grid.GetTurnOverList(3, 4, false, ref squareList));
        }

        [Test]
        public void SelectSquarePlayerOne()
        {
            var grid = new Grid();

            grid.ClearAllSquares();
            Assert.IsFalse(grid.SelectSquare(3, 4, false));

            grid.SetSquareToPlayer(0, 4, true);
            grid.SetSquareToPlayer(1, 4, false);
            grid.SetSquareToPlayer(2, 4, false);

            grid.SetSquareToPlayer(4, 4, false);
            grid.SetSquareToPlayer(5, 4, false);
            grid.SetSquareToPlayer(6, 4, true);

            grid.SetSquareEmpty(3, 4);
            grid.SetCanSelect(3, 4);
            Assert.IsTrue(grid.SelectSquare(3, 4, true));

            for (var row = 0; row < Grid.MaxSide; row++)
            {
                for (var column = 0; column < Grid.MaxSide; column++)
                {
                    if (((row == 0) && (column == 4)) ||
                        ((row == 1) && (column == 4)) ||
                        ((row == 2) && (column == 4)) ||
                        ((row == 3) && (column == 4)) ||
                        ((row == 4) && (column == 4)) ||
                        ((row == 5) && (column == 4)) ||
                        ((row == 6) && (column == 4))
                        )
                    {
                        Assert.IsTrue(grid.IsPlayerOneControl(row, column));
                    }
                    else
                    {
                        Assert.IsFalse(!grid.SquareIsEmpty(row, column));
                    }
                }
            }
        }

        [Test]
        public void SelectSquarePlayerTwo()
        {
            var grid = new Grid();

            grid.ClearAllSquares();
            Assert.IsFalse(grid.SelectSquare(3, 4, false));

            grid.SetSquareToPlayer(0, 7, false);
            grid.SetSquareToPlayer(1, 6, true);
            grid.SetSquareToPlayer(2, 5, true);

            grid.SetSquareToPlayer(4, 3, true);
            grid.SetSquareToPlayer(5, 2, true);
            grid.SetSquareToPlayer(6, 1, false);

            grid.SetSquareEmpty(3, 4);
            grid.SetCanSelect(3, 4);
            Assert.IsTrue(grid.SelectSquare(3, 4, false));

            for (int row = 0; row < Grid.MaxSide; row++)
            {
                for (int column = 0; column < Grid.MaxSide; column++)
                {
                    if (((row == 0) && (column == 7)) ||
                        ((row == 1) && (column == 6)) ||
                        ((row == 2) && (column == 5)) ||
                        ((row == 3) && (column == 4)) ||
                        ((row == 4) && (column == 3)) ||
                        ((row == 5) && (column == 2)) ||
                        ((row == 6) && (column == 1))
                        )
                    {
                        Assert.IsTrue(grid.IsPlayerTwoControl(row, column));
                    }
                    else
                    {
                        Assert.IsTrue(grid.SquareIsEmpty(row, column));
                    }
                }
            }
        }

        [Test]
        public void MarkAllCanSelect()
        {
            var grid = new Grid();

            grid.ClearAllSquares();

            grid.SetSquareToPlayer(1, 6, true);
            grid.SetSquareToPlayer(2, 5, true);
            grid.SetSquareToPlayer(4, 3, true);
            grid.SetSquareToPlayer(5, 2, true);

            grid.SetSquareToPlayer(1, 2, true);
            grid.SetSquareToPlayer(2, 3, true);
            grid.SetSquareToPlayer(4, 5, true);
            grid.SetSquareToPlayer(5, 6, true);

            grid.SetSquareToPlayer(1, 4, true);
            grid.SetSquareToPlayer(2, 4, true);
            grid.SetSquareToPlayer(4, 4, true);
            grid.SetSquareToPlayer(5, 4, true);

            grid.SetSquareToPlayer(3, 2, true);
            grid.SetSquareToPlayer(3, 3, true);
            grid.SetSquareToPlayer(3, 5, true);
            grid.SetSquareToPlayer(3, 6, true);

            grid.SetSquareToPlayer(3, 4, false);

            grid.MarkAllCanSelect(false);

            for (int row = 0; row < Grid.MaxSide; row++)
            {
                for (int column = 0; column < Grid.MaxSide; column++)
                {
                    if (((row == 1) && (column == 6)) ||
                        ((row == 2) && (column == 5)) ||
                        ((row == 4) && (column == 3)) ||
                        ((row == 5) && (column == 2)) ||
                        ((row == 1) && (column == 2)) ||
                        ((row == 2) && (column == 3)) ||
                        ((row == 4) && (column == 5)) ||
                        ((row == 5) && (column == 6)) ||
                        ((row == 1) && (column == 4)) ||
                        ((row == 2) && (column == 4)) ||
                        ((row == 4) && (column == 4)) ||
                        ((row == 5) && (column == 4)) ||
                        ((row == 3) && (column == 2)) ||
                        ((row == 3) && (column == 3)) ||
                        ((row == 3) && (column == 5)) ||
                        ((row == 3) && (column == 6)) ||
                        ((row == 3) && (column == 4))
                        )
                    {
                        bool retVal = (!grid.IsPlayerOneControl(row, column) &&
                                       !grid.IsPlayerTwoControl(row, column));
                        Assert.IsFalse(retVal);
                    }
                    else if (((row == 0) && (column == 1)) ||
                            ((row == 3) && (column == 1)) ||
                            ((row == 6) && (column == 1)) ||
                            ((row == 6) && (column == 4)) ||
                            ((row == 6) && (column == 7)) ||
                            ((row == 3) && (column == 7)) ||
                            ((row == 0) && (column == 7)) ||
                            ((row == 0) && (column == 4))
                            )
                    {
                        Assert.IsTrue(grid.IsCanSelect(row, column));
                    }
                    else
                    {
                        Assert.IsTrue(grid.SquareIsEmpty(row, column));
                    }
                }
            }
        }

        [Test]
        public void MarkAllCanSelectNoSelect()
        {
            var grid = new Grid();

            grid.ClearAllSquares();

            grid.SetSquareToPlayer(1, 4, true);
            grid.SetSquareToPlayer(2, 4, true);
            grid.SetSquareToPlayer(4, 4, true);
            grid.SetSquareToPlayer(5, 4, true);

            Assert.IsFalse(grid.MarkAllCanSelect(false));
        }

        [Test]
        public void FirstFailureFound()
        {
            var grid = new Grid();

            grid.ClearAllSquares();

            grid.SetSquareToPlayer(3, 2, false);
            grid.SetSquareToPlayer(3, 3, false);
            grid.SetSquareToPlayer(3, 4, false);
            grid.SetSquareToPlayer(3, 6, false);
            grid.SetSquareToPlayer(4, 3, false);

            grid.SetSquareToPlayer(2, 4, true);
            grid.SetSquareToPlayer(2, 5, true);
            grid.SetSquareToPlayer(3, 5, true);
            grid.SetSquareToPlayer(4, 5, true);
            grid.SetSquareToPlayer(5, 5, true);
            grid.SetSquareToPlayer(4, 4, true);
            grid.SetSquareToPlayer(5, 4, true);
            grid.SetSquareToPlayer(6, 4, true);

            grid.MarkAllCanSelect(false);

            for (int row = 0; row < Grid.MaxSide; row++)
            {
                for (int column = 0; column < Grid.MaxSide; column++)
                {
                    if (((row == 3) && (column == 2)) ||
                        ((row == 3) && (column == 3)) ||
                        ((row == 3) && (column == 4)) ||
                        ((row == 3) && (column == 6)) ||
                        ((row == 4) && (column == 3)) ||
                        ((row == 2) && (column == 4)) ||
                        ((row == 2) && (column == 5)) ||
                        ((row == 3) && (column == 5)) ||
                        ((row == 4) && (column == 5)) ||
                        ((row == 5) && (column == 5)) ||
                        ((row == 4) && (column == 4)) ||
                        ((row == 5) && (column == 4)) ||
                        ((row == 6) && (column == 4))
                        )
                    {
                        bool testVal = (!grid.IsPlayerOneControl(row, column) &&
                                       !grid.IsPlayerTwoControl(row, column));
                        Assert.IsFalse(testVal);
                    }
                    else if (((row == 1) && (column == 4)) ||
                            ((row == 1) && (column == 5)) ||
                            ((row == 1) && (column == 6)) ||
                            ((row == 4) && (column == 6)) ||
                            ((row == 5) && (column == 6)) ||
                            ((row == 6) && (column == 3)) ||
                            ((row == 6) && (column == 5)) ||
                            ((row == 6) && (column == 6)) ||
                            ((row == 7) && (column == 4))
                            )
                    {
                        Assert.IsTrue(grid.IsCanSelect(row, column));
                    }
                    else
                    {
                        Assert.IsTrue(grid.SquareIsEmpty(row, column));
                    }
                }
            }
        }

        [Test]
        public void SecondFailureFound()
        {
            int row, column;
            var grid = new Grid();

            grid.ClearAllSquares();

            grid.SetSquareToPlayer(2, 3, false);
            grid.SetSquareToPlayer(3, 3, false);
            grid.SetSquareToPlayer(4, 3, false);
            grid.SetSquareToPlayer(3, 4, false);

            grid.SetSquareToPlayer(4, 4, true);
            grid.SetSquareToPlayer(3, 5, true);

            grid.MarkAllCanSelect(true);

            for (row = 0; row < Grid.MaxSide; row++)
            {
                for (column = 0; column < Grid.MaxSide; column++)
                {
                    if (((row == 2) && (column == 3)) ||
                        ((row == 3) && (column == 3)) ||
                        ((row == 4) && (column == 3)) ||
                        ((row == 3) && (column == 4)) ||
                        ((row == 4) && (column == 4)) ||
                        ((row == 3) && (column == 5))
                        )
                    {
                        bool testVal = !grid.IsPlayerOneControl(row, column) &&
                                       !grid.IsPlayerTwoControl(row, column);
                        Assert.IsFalse(testVal);
                    }
                    else if (((row == 2) && (column == 2)) ||
                            ((row == 3) && (column == 2)) ||
                            ((row == 4) && (column == 2)) ||
                            ((row == 2) && (column == 4))
                            )
                    {
                        Assert.IsTrue(grid.IsCanSelect(row, column));
                    }
                    else
                    {
                        Assert.IsTrue(grid.SquareIsEmpty(row, column));
                    }
                }
            }

            grid.SelectSquare(3, 2, true);
            grid.ClearAllCanSelectSquares();

            for (row = 0; row < Grid.MaxSide; row++)
            {
                for (column = 0; column < Grid.MaxSide; column++)
                {
                    if (((row == 3) && (column == 2)) ||
                        ((row == 3) && (column == 3)) ||
                        ((row == 3) && (column == 4)) ||
                        ((row == 3) && (column == 5)) ||
                        ((row == 4) && (column == 4))
                        )
                    {
                        Assert.IsTrue(grid.IsPlayerOneControl(row, column));
                    }
                    else if (((row == 2) && (column == 3)) ||
                            ((row == 4) && (column == 3)))
                    {
                        Assert.IsTrue(grid.IsPlayerTwoControl(row, column));
                    }
                    else
                    {
                        Assert.IsTrue(grid.SquareIsEmpty(row, column));
                    }
                }
            }
        }

        [Test]
        public void SelectSquarePlayerOneShowTurnOver()
        {
            var grid = new Grid
            {
                ShowTurnOver = true
            };

            grid.ClearAllSquares();
            Assert.IsFalse(grid.SelectSquare(3, 4, false));

            grid.SetSquareToPlayer(0, 4, true);
            grid.SetSquareToPlayer(1, 4, false);
            grid.SetSquareToPlayer(2, 4, false);

            grid.SetSquareToPlayer(4, 4, false);
            grid.SetSquareToPlayer(5, 4, false);
            grid.SetSquareToPlayer(6, 4, true);

            grid.SetSquareEmpty(3, 4);
            grid.SetCanSelect(3, 4);
            Assert.IsTrue(grid.SelectSquare(3, 4, true));

            for (var row = 0; row < Grid.MaxSide; row++)
            {
                for (var column = 0; column < Grid.MaxSide; column++)
                {
                    if (((row == 0) && (column == 4)) ||
                        ((row == 6) && (column == 4))
                        )
                    {
                        Assert.IsTrue(grid.IsPlayerOneControl(row, column));
                    }else if ((row == 3) && (column == 4))
                    {
                        Assert.IsTrue(grid.IsCanSelect(row, column));
                    }
                    else if (((row == 1) && (column == 4)) ||
                             ((row == 2) && (column == 4)) ||
                             ((row == 4) && (column == 4)) ||
                             ((row == 5) && (column == 4))
                            )
                    {
                        Assert.IsTrue(grid.IsShowTurnOver(row, column));
                    }
                }
            }

            grid.ClearTurnOverSquares(true);

            for (var row = 0; row < Grid.MaxSide; row++)
            {
                for (var column = 0; column < Grid.MaxSide; column++)
                {
                    if (((row == 0) && (column == 4)) ||
                        ((row == 6) && (column == 4))
                        )
                    {
                        Assert.IsTrue(grid.IsPlayerOneControl(row, column));
                    }
                    else if ((row == 3) && (column == 4))
                    {
                        Assert.IsTrue(grid.IsCanSelect(row, column));
                    }
                    else if (((row == 1) && (column == 4)) ||
                             ((row == 2) && (column == 4)) ||
                             ((row == 4) && (column == 4)) ||
                             ((row == 5) && (column == 4))
                            )
                    {
                        Assert.IsTrue(grid.IsPlayerTwoControl(row, column));
                    }
                }
            }
        }
    }
}
