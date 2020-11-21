using System;
using System.Collections.Generic;

namespace Othello.Engine
{
    [Serializable]
    public class SquareList
    {
        private readonly List<SquareData> m_nextSquare;
        private int m_listIdx;

        public SquareList()
        {
            m_nextSquare = new List<SquareData>();
        }

        public void AddNewSquare(int row, int column)
        {
            var nextSquare = new SquareData {Row = row, Column = column};
            m_nextSquare?.Add(nextSquare);
        }

        public void GetSquare(out int row, out int column)
        {
            row = m_nextSquare[m_listIdx].Row;
            column = m_nextSquare[m_listIdx].Column;
        }

        public void SetSquare(int row, int column)
        {
            m_nextSquare[m_listIdx].Row = row;
            m_nextSquare[m_listIdx].Column = column;
        }

        public void GoToNextSquare()
        {
            m_listIdx ++;
        }

        public void  SetTopOfList()
        {
            m_listIdx = 0;
        }

        public bool AtEndOfList()
        {
            return (m_listIdx >= m_nextSquare.Count);
        }
    }

    [Serializable]
    class SquareData
    {
        public int Row { set; get; }
        public int Column { set; get; }
    }
}
