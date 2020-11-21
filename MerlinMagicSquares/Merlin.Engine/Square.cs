using System;

namespace Merlin.Engine
{
	/// <summary>
	/// Summary description for Square.
	/// </summary>

    [Serializable]
    public class Square
	{
        private int m_state;

		public Square()
		{
            m_state = -1;
		}

        public void SetState(int P_state)
        {
            m_state = P_state;
        }

        public int GetState()
        {
            return m_state;
        }
    }
}
