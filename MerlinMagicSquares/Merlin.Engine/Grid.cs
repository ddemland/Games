using System;

namespace Merlin.Engine
{
	/// <summary>
	/// Summary description for Grid.
	/// </summary>

    [Serializable]
    public class Grid
	{
        public const int MaxSquares = 9;
        public const int MaxStates = 2;
        public const int MaxSkip = 2;

        private bool m_gridReady;
        private int m_maxStates;
        private readonly int []m_winPattern;
        private readonly Square []m_grid;
        private readonly ToggleItem []m_toggleList;
        private Random m_random;

        public Grid()
		{
            int cnt;
            int []defaultWinPattern = {1, 1, 1, 1, 1, 1, 1, 1, 1};
            int []square0Toggle = {0, 1, 3, 4};
            int []square1Toggle = {0, 1, 2};
            int []square2Toggle = {1, 2, 4, 5};
            int []square3Toggle = {0, 3, 6};
            int []square4Toggle = {1, 4, 7, 3, 5};
            int []square5Toggle = {2, 5, 8};
            int []square6Toggle = {3, 4, 6, 7};
            int []square7Toggle = {6, 7, 8};
            int []square8Toggle = {4, 5, 7, 8};

            m_winPattern = new int[MaxSquares];
            m_grid = new Square[MaxSquares];
            m_toggleList = new ToggleItem[MaxSquares];

            for (cnt = 0; cnt < MaxSquares; cnt ++)
            {
                m_grid[cnt] = new Square();
                m_toggleList[cnt] = new ToggleItem();
            }

            m_gridReady = false;
            m_maxStates = -1;

            SetWinPattern(defaultWinPattern);

            m_toggleList[0].SetList(square0Toggle.Length, ref square0Toggle);
            m_toggleList[1].SetList(square1Toggle.Length, ref square1Toggle);
            m_toggleList[2].SetList(square2Toggle.Length, ref square2Toggle);
            m_toggleList[3].SetList(square3Toggle.Length, ref square3Toggle);
            m_toggleList[4].SetList(square4Toggle.Length, ref square4Toggle);
            m_toggleList[5].SetList(square5Toggle.Length, ref square5Toggle);
            m_toggleList[6].SetList(square6Toggle.Length, ref square6Toggle);
            m_toggleList[7].SetList(square7Toggle.Length, ref square7Toggle);
            m_toggleList[8].SetList(square8Toggle.Length, ref square8Toggle);
		}

        public void InitGrid()
        {
            SetMaxStates(MaxStates);
            m_gridReady = true;
        }

        public void ToggleGrid(int P_toggleIndexList)
        {
            int numSquaresInList = 0, cnt;
            var listPtr = new int[1];

            m_toggleList[P_toggleIndexList].GetList(ref numSquaresInList, ref listPtr);
            for (cnt = 0; cnt < numSquaresInList; cnt ++)
            {
                int currIdx = listPtr[cnt];
                int currState = m_grid[currIdx].GetState();
                currState = (currState + 1) % m_maxStates;
                m_grid[currIdx].SetState(currState);
            }
        }

        public void SetMaxStates(int P_maxStates)
        {
            m_maxStates = P_maxStates;
        }

        public int GetMaxStates()
        {
            return(m_maxStates);
        }

        public bool GridValid()
        {
            return(m_gridReady);
        }

        public int GetRandomizeState()
        {
            int state = m_random.Next(MaxStates);

            return(state);
        }

	    public void RandomizeStartingGrid()
        {
            int cnt;
            Square currSquare;
            DateTime currTime = DateTime.Now;

            m_random = new Random(currTime.Millisecond);
            for(cnt = 0; cnt < MaxSquares; cnt ++)
            {
                int state = GetRandomizeState();
                currSquare = m_grid[cnt];
                currSquare.SetState(state);
            }
        }

        public void SetWinPattern(int []P_winValues)
        {
            int cnt;

            for (cnt = 0; cnt < MaxSquares; cnt ++)
            {
                m_winPattern[cnt] = P_winValues[cnt];
            }
        }

        public int []GetWinPattern()
        {
            return(m_winPattern);
        }

        public bool GameWon()
        {
            int cnt;
            bool rc = true;

            Square[] currSquarePtr = GetGrid();
            for (cnt = 0; cnt < MaxSquares; cnt ++)
            {
                if (currSquarePtr[cnt].GetState() != m_winPattern[cnt])
                {
                    rc = false;
                    break;
                }
            }

            return(rc);
        }

        public Square []GetGrid()
        {
            return(m_grid);
        }

        public ToggleItem GetToggleList(int P_idx)
        {
            return(m_toggleList[P_idx]);
        }
    }
}
