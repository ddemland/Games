using System;

namespace Othello.Engine
{
    [Serializable]
    public class Grid
    {
        public const int MaxSide = 8;
        public const int StateEmpty = 1;
        public const int StatePlayer1 = 2;
        public const int StatePlayer2 = 3;
        public const int StateCanSelect = 4;
        public const int StateTurnOver = 5;

        private const int StateUnknown = -1;
        private const int SquareOutOfRangeConst = -1;

        private readonly Square[,] m_grid;
        public bool ShowTurnOver { get; set; }

        public Grid()
        {
            ShowTurnOver = false;
            m_grid = new Square[MaxSide, MaxSide];
            for (var row = 0; row < MaxSide; row++)
            {
                for (var column = 0; column < MaxSide; column++)
                {
                    m_grid[row, column] = new Square {State = StateEmpty};
                }
            }
        }

        public bool AllSquaresCovered()
        {
            for (var row = 0; row < MaxSide; row++)
            {
                for (var column = 0; column < MaxSide; column++)
                {
                    if (!IsPlayerOneControl(row, column) &&
                            !IsPlayerTwoControl(row, column))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int GetSquareState(int row, int column)
        {
            return SquareOutOfRange(row, column) ?
                SquareOutOfRangeConst : m_grid[row, column].State;
        }

        public bool SetSquareState(int row, int column, int state)
        {
            if (SquareOutOfRange(row, column))
            {
                return false;
            }

            m_grid[row, column].State = state;
            return true;
        }

        public void ClearAllSquares()
        {
            for (var row = 0; row < MaxSide; row++)
            {
                for (var column = 0; column < MaxSide; column++)
                {
                    SetSquareEmpty(row, column);
                }
            }
        }

        public void ClearTurnOverSquares(bool currPlayerOne)
        {
            for (var row = 0; row < MaxSide; row++)
            {
                for (var column = 0; column < MaxSide; column++)
                {
                    if (GetSquareState(row, column) == StateTurnOver)
                    {
                        SetSquareToPlayer(row, column, !currPlayerOne);
                    }
                }
            }
        }

        public int CountPlayerOneSquares()
        {
            var cnt = 0;

            for (var row = 0; row < MaxSide; row++)
            {
                for (var column = 0; column < MaxSide; column++)
                {
                    if (IsPlayerOneControl(row, column))
                    {
                        cnt++;
                    }
                }
            }

            return cnt;
        }

        public int CountPlayerTwoSquares()
        {
            var cnt = 0;

            for (var row = 0; row < MaxSide; row++)
            {
                for (var column = 0; column < MaxSide; column++)
                {
                    if (IsPlayerTwoControl(row, column))
                    {
                        cnt++;
                    }
                }
            }

            return cnt;
        }

        public void InitGame()
        {
            ClearAllSquares();
            SetSquareToPlayer(3, 3, true);
            SetSquareToPlayer(4, 4, true);
            SetSquareToPlayer(3, 4, false);
            SetSquareToPlayer(4, 3, false);
        }

        public bool IsPlayerOneControl(int row, int column)
        {
            return GetSquareState(row, column) == StatePlayer1;
        }

        public bool IsPlayerTwoControl(int row, int column)
        {
            return GetSquareState(row, column) == StatePlayer2;
        }

        public bool IsShowTurnOver(int row, int column)
        {
            return GetSquareState(row, column) == StateTurnOver;
        }

        public bool SquareIsEmpty(int row, int column)
        {
            return GetSquareState(row, column) == StateEmpty;
        }

        public void SetSquareEmpty(int row, int column)
        {
            SetSquareState(row, column, StateEmpty);
        }

        public void SetSquareToPlayer(int row, int column, bool playerOne)
        {
            var state = playerOne ? StatePlayer1 : StatePlayer2;

            SetSquareState(row, column, state);
        }

        public bool SetCanSelect(int row, int column)
        {
            if (!SquareIsEmpty(row, column))
            {
                return (false);
            }

            SetSquareState(row, column, StateCanSelect);
            return(true);
        }

        public bool IsCanSelect(int row, int column)
        {
            return GetSquareState(row, column) == StateCanSelect;
        }

        public void ClearAllCanSelectSquares()
        {
            for (var row = 0; row < MaxSide; row++)
            {
                for (var column = 0; column < MaxSide; column++)
                {
                    if (IsCanSelect(row, column))
                    {
                        SetSquareEmpty(row, column);
                    }
                }
            }
        }

        public int GetTurnOverList(int row, int column, bool playerOne,
                                                ref SquareList squareList)
        {
            var totalCnt = 0;

            if (!IsCanSelect(row, column))
            {
                return totalCnt;
            }

            var state = GetOpposingPlayerState(playerOne);

            if (PlayExistUp(row, column, playerOne))
            {
                totalCnt += SearchUp(row, column, state, ref squareList);
            }

            if (PlayExistDown(row, column, playerOne))
            {
                totalCnt += SearchDown(row, column, state, ref squareList);
            }

            if (PlayExistLeft(row, column, playerOne))
            {
                totalCnt += SearchLeft(row, column, state, ref squareList);
            }

            if (PlayExistRight(row, column, playerOne))
            {
                totalCnt += SearchRight(row, column, state, ref squareList);
            }

            if (PlayExistUpLeft(row, column, playerOne))
            {
                totalCnt += SearchUpLeft(row, column, state, ref squareList);
            }

            if (PlayExistDownRight(row, column, playerOne))
            {
                totalCnt += SearchDownRight(row, column, state, ref squareList);
            }

            if (PlayExistUpRight(row, column, playerOne))
            {
                totalCnt += SearchUpRight(row, column, state, ref squareList);
            }

            if (PlayExistDownLeft(row, column, playerOne))
            {
                totalCnt += SearchDownLeft(row, column, state, ref squareList);
            }

            return totalCnt;
        }

        public bool SelectSquare(int row, int column, bool playerOne)
        {
            var squareList = new SquareList();

            if (!IsCanSelect(row, column))
            {
                return false;
            }

            if (GetTurnOverList(row, column, playerOne, ref squareList) == 0)
            {
                return false;
            }

            if (!ShowTurnOver)
            {
                SetSquareToPlayer(row, column, playerOne);
            }

            while (!squareList.AtEndOfList())
            {
                squareList.GetSquare(out var localRow, out var localColumn);
                if (!ShowTurnOver)
                {
                    SetSquareToPlayer(localRow, localColumn, playerOne);
                }
                else
                {
                    if (GetSquareState(localRow, localColumn) != GetCurrentPlayerState(playerOne))
                    {
                        SetSquareState(localRow, localColumn, StateTurnOver);
                    }
                }

                squareList.GoToNextSquare();
            }

            return true;
        }

        public void SetTurnOverSelect(int row, int column, bool state)
        {
            m_grid[row, column].TurnOverSelect = state;
        }

        public bool IsTurnOverSelect(int row, int column)
        {
            return m_grid[row, column].TurnOverSelect;
        }

        public int SearchUp(int row, int column, int state,
                                                ref SquareList squareList)
        {
            int cnt, totalCnt = 0;

            for (cnt = row - 1; cnt >= 0; cnt--)
            {
                if (GetSquareState(cnt, column) == state)
                {
                    squareList.AddNewSquare(cnt, column);
                    totalCnt++;
                }
                else
                {
                    break;
                }
            }

            return totalCnt;
        }

        public int SearchDown(int row, int column, int state,
                                                ref SquareList squareList)
        {
            int cnt, totalCnt = 0;

            for (cnt = row + 1; cnt < MaxSide; cnt++)
            {
                if (GetSquareState(cnt, column) == state)
                {
                    squareList.AddNewSquare(cnt, column);
                    totalCnt++;
                }
                else
                {
                    break;
                }
            }

            return totalCnt;
        }

        public int SearchLeft(int row, int column, int state,
                                                ref SquareList squareList)
        {
            int cnt, totalCnt = 0;

            for (cnt = column - 1; cnt >= 0; cnt--)
            {
                if (GetSquareState(row, cnt) == state)
                {
                    squareList.AddNewSquare(row, cnt);
                    totalCnt++;
                }
                else
                {
                    break;
                }
            }

            return totalCnt;
        }

        public int SearchRight(int row, int column, int state,
                                                ref SquareList squareList)
        {
            int cnt, totalCnt = 0;

            for (cnt = column + 1; cnt < MaxSide; cnt++)
            {
                if (GetSquareState(row, cnt) == state)
                {
                    squareList.AddNewSquare(row, cnt);
                    totalCnt++;
                }
                else
                {
                    break;
                }
            }

            return totalCnt;
        }

        public int SearchUpLeft(int row, int column, int state,
                                                ref SquareList squareList)
        {
            int localRow, localColumn, totalCnt = 0;

            for (localRow = row - 1, localColumn = column - 1; (localRow > 0) && (localColumn > 0);
                            localRow--, localColumn--)
            {
                if (GetSquareState(localRow, localColumn) == state)
                {
                    squareList.AddNewSquare(localRow, localColumn);
                    totalCnt++;
                }
                else
                {
                    break;
                }
            }

            return totalCnt;
        }

        public int SearchDownRight(int row, int column, int state,
                                                ref SquareList squareList)
        {
            int localRow, localColumn, totalCnt = 0;

            for (localRow = row + 1, localColumn = column + 1; (localRow > 0) && (localColumn > 0);
                            localRow++, localColumn++)
            {
                if (GetSquareState(localRow, localColumn) == state)
                {
                    squareList.AddNewSquare(localRow, localColumn);
                    totalCnt++;
                }
                else
                {
                    break;
                }
            }

            return totalCnt;
        }

        public int SearchUpRight(int row, int column, int state,
                                                ref SquareList squareList)
        {
            int localRow, localColumn, totalCnt = 0;

            for (localRow = row - 1, localColumn = column + 1; (localRow > 0) && (localColumn > 0);
                            localRow--, localColumn++)
            {
                if (GetSquareState(localRow, localColumn) == state)
                {
                    squareList.AddNewSquare(localRow, localColumn);
                    totalCnt++;
                }
                else
                {
                    break;
                }
            }

            return totalCnt;
        }

        public int SearchDownLeft(int row, int column, int state,
                                                ref SquareList squareList)
        {
            int localRow, localColumn, totalCnt = 0;

            for (localRow = row + 1, localColumn = column - 1; (localRow > 0) && (localColumn > 0);
                            localRow++, localColumn--)
            {
                if (GetSquareState(localRow, localColumn) == state)
                {
                    squareList.AddNewSquare(localRow, localColumn);
                    totalCnt++;
                }
                else
                {
                    break;
                }
            }

            return totalCnt;
        }

        public bool MarkAllCanSelect(bool playerOne)
        {
            var playExist = false;

            for (var row = 0; row < MaxSide; row ++)
            {
                for (int column = 0; column < MaxSide; column++)
                {
                    if (!SquareIsEmpty(row, column))
                    {
                        continue;
                    }

                    if (!PlayExistUp(row, column, playerOne) &&
                        !PlayExistDown(row, column, playerOne) &&
                        !PlayExistLeft(row, column, playerOne) &&
                        !PlayExistRight(row, column, playerOne) &&
                        !PlayExistUpLeft(row, column, playerOne) &&
                        !PlayExistDownRight(row, column, playerOne) &&
                        !PlayExistUpRight(row, column, playerOne) &&
                        !PlayExistDownLeft(row, column, playerOne))
                    {
                        continue;
                    }

                    SetCanSelect(row, column);
                    playExist = true;
                }
            }

            return playExist;
        }

        public int GetOpposingPlayerState(bool playerOne)
        {
            return playerOne ? StatePlayer2 : StatePlayer1;
        }

        public int GetCurrentPlayerState(bool playerOne)
        {

            return playerOne ? StatePlayer1 : StatePlayer2;
        }

        public bool PlayExistUp(int row, int column, bool playerOne)
        {
            int cnt, state = StateUnknown;

            if (SquareOutOfRange(row, column) || ((row - 1) < 0))
            {
                return false;
            }

            var opposingState = GetOpposingPlayerState(playerOne);

            var oneSquareDone = false;
            for (cnt = row - 1; cnt >= 0; cnt--)
            {
                if ((state = GetSquareState(cnt, column)) != opposingState)
                {
                    break;
                }

                oneSquareDone = true;
            }

            if (!oneSquareDone)
            {
                return false;
            }

            var currentState = GetCurrentPlayerState(playerOne);
            return state == currentState;
        }

        public bool PlayExistDown(int row, int column, bool playerOne)
        {
            int cnt, state = StateUnknown;

            if (SquareOutOfRange(row, column) || ((row + 1) >= MaxSide))
            {
                return(false);
            }

            var opposingState = GetOpposingPlayerState(playerOne);

            var oneSquareDone = false;
            for (cnt = row + 1; cnt < MaxSide; cnt++)
            {
                if ((state = GetSquareState(cnt, column)) != opposingState)
                {
                    break;
                }

                oneSquareDone = true;
            }

            if (!oneSquareDone)
            {
                return false;
            }

            var currentState = GetCurrentPlayerState(playerOne);
            return state == currentState;
        }

        public bool PlayExistLeft(int row, int column, bool playerOne)
        {
            int cnt, state = StateUnknown;

            if (SquareOutOfRange(row, column) || ((column - 1) < 0))
            {
                return(false);
            }

            var opposingState = GetOpposingPlayerState(playerOne);

            var oneSquareDone = false;
            for (cnt = column - 1; cnt >= 0; cnt--)
            {
                if ((state = GetSquareState(row, cnt)) != opposingState)
                {
                    break;
                }

                oneSquareDone = true;
            }

            if (!oneSquareDone)
            {
                return false;
            }

            var currentState = GetCurrentPlayerState(playerOne);
            return state == currentState;
        }

        public bool PlayExistRight(int row, int column, bool playerOne)
        {
            int cnt, state = StateUnknown;

            if (SquareOutOfRange(row, column) || ((column + 1) >= MaxSide))
            {
                return(false);
            }

            var opposingState = GetOpposingPlayerState(playerOne);

            var oneSquareDone = false;
            for (cnt = column + 1; cnt < MaxSide; cnt++)
            {
                if ((state = GetSquareState(row, cnt)) != opposingState)
                {
                    break;
                }

                oneSquareDone = true;
            }

            if (!oneSquareDone)
            {
                return false;
            }

            var currentState = GetCurrentPlayerState(playerOne);
            return state == currentState;
        }

        public bool PlayExistUpLeft(int row, int column, bool playerOne)
        {
            int localRow, localColumn, state = StateUnknown;

            if (SquareOutOfRange(row, column) ||
                    (((column - 1) < 0) ||
                    ((row - 1) < 0)))
            {
                return(false);
            }

            var opposingState = GetOpposingPlayerState(playerOne);

            var oneSquareDone = false;

            for (localRow = row - 1, localColumn = column - 1; (localRow >= 0) && (localColumn >= 0);
                            localRow--, localColumn--)
            {
                if ((state = GetSquareState(localRow, localColumn)) != opposingState)
                {
                    break;
                }

                oneSquareDone = true;
            }

            if (!oneSquareDone)
            {
                return false;
            }

            var currentState = GetCurrentPlayerState(playerOne);
            return state == currentState;
        }

        public bool PlayExistDownRight(int row, int column, bool playerOne)
        {
            int localRow, localColumn, state = StateUnknown;

            if (((column + 1) >= MaxSide) || ((row + 1) >= MaxSide))
            {
                return(false);
            }

            var opposingState = GetOpposingPlayerState(playerOne);

            var oneSquareDone = false;

            for (localRow = row + 1, localColumn = column + 1; (localRow > 0) && (localColumn > 0);
                            localRow++, localColumn++)
            {
                if ((state = GetSquareState(localRow, localColumn)) != opposingState)
                {
                    break;
                }

                oneSquareDone = true;
            }

            if (!oneSquareDone)
            {
                return false;
            }

            var currentState = GetCurrentPlayerState(playerOne);
            return state == currentState;
        }

        public bool PlayExistUpRight(int row, int column, bool playerOne)
        {
            int localRow, localColumn, state = StateUnknown;

            if (SquareOutOfRange(row, column) ||
                    (((column + 1) >= MaxSide) ||
                    ((row - 1) < 0)))
            {
                return(false);
            }

            var opposingState = GetOpposingPlayerState(playerOne);

            var oneSquareDone = false;

            for (localRow = row - 1, localColumn = column + 1; (localRow >= 0) && (localColumn >= 0);
                            localRow--, localColumn++)
            {
                if ((state = GetSquareState(localRow, localColumn)) != opposingState)
                {
                    break;
                }

                oneSquareDone = true;
            }

            if (!oneSquareDone)
            {
                return false;
            }

            var currentState = GetCurrentPlayerState(playerOne);
            return state == currentState;
        }

        public bool PlayExistDownLeft(int row, int column, bool playerOne)
        {
            int localRow, localColumn, state = StateUnknown;

            if (((column - 1) < 0) || ((row + 1) >= MaxSide))
            {
                return false;
            }

            var opposingState = GetOpposingPlayerState(playerOne);

            var oneSquareDone = false;

            for (localRow = row + 1, localColumn = column - 1; (localRow > 0) && (localColumn > 0);
                            localRow++, localColumn--)
            {
                if ((state = GetSquareState(localRow, localColumn)) != opposingState)
                {
                    break;
                }

                oneSquareDone = true;
            }

            if (!oneSquareDone)
            {
                return false;
            }

            var currentState = GetCurrentPlayerState(playerOne);
            return state == currentState;
        }

        private static bool SquareOutOfRange(int row, int column)
        {
            return IndexValueValid(row) || IndexValueValid(column);
        }

        private static bool IndexValueValid(int index)
        {
            return (index >= MaxSide) || (index < 0);
        }
    }
}
