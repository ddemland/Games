
namespace MasterMind.Engine
{
	/// <summary>
	/// Summary description for RoundStatus.
	/// </summary>
	public class RoundStatus
	{
        private readonly int [] m_handStatus;

		public RoundStatus()
		{
            m_handStatus = new int[Hand.MaxHand];
		}

        public void SetHandStatus(ref int []P_handStatus)
        {
            int cnt;

            for (cnt = 0; cnt < Hand.MaxHand; cnt ++)
            {
                m_handStatus[cnt] = P_handStatus[cnt];
            }
        }

        public int [] GetHandStatus()
        {
            return(m_handStatus);
        }
    }
}
