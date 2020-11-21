using System;

namespace Merlin.Engine
{
	/// <summary>
	/// Summary description for ToggleItem.
	/// </summary>

    [Serializable]
	public class ToggleItem
	{
        private int m_numSquares;
        private readonly int []m_squareList;

        public ToggleItem()
		{
            m_squareList = new int[Grid.MaxSquares];
            m_numSquares = -1;
        }

        public void SetNumSquares(int P_num)
        {
            m_numSquares = P_num;
        }


        public int GetNumSquares()
        {
            return(m_numSquares);
        }

        public void SetList(int P_numSquares, ref int []P_numList)
        {
            int cnt;

            m_numSquares = P_numSquares;
            if (m_numSquares <= 0)
            {
                return;
            }

            for (cnt = 0; cnt < m_numSquares; cnt ++)
            {
                m_squareList[cnt] = P_numList[cnt];
            }
        }

        public void GetList(ref int P_numSquares, ref int []P_list)
        {
            P_numSquares = m_numSquares;
            if (m_numSquares <= 0)
            {
                return;
            }

            P_list = m_squareList;
        }	
    }
}
