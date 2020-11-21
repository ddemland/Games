using System;

namespace MasterMind.Engine
{
	/// <summary>
	/// Summary description for Game.
	/// </summary>
	public class Game
	{
        public const int MaxHands = 8;

        private readonly Hand []m_gameHands;
        private readonly RoundStatus []m_handStatus;
        private readonly Hand m_computerHand;

		public Game()
		{
            int cnt;

            m_gameHands = new Hand[MaxHands];
            m_handStatus = new RoundStatus[MaxHands];
            m_computerHand = new Hand();

            for (cnt = 0; cnt < MaxHands; cnt ++)
            {
                m_gameHands[cnt] = new Hand();
                m_handStatus[cnt] = new RoundStatus();
            }
		}

        public void StartGame()
        {
            int cnt;

            for (cnt = 0; cnt < MaxHands; cnt ++)
            {
                m_gameHands[cnt].ResetHand();
            }

            RandomizeComputerHand();
        }

        public void RandomizeComputerHand()
        {
            int cnt;
            var colors = new int[MaxHands];
            DateTime currTime = DateTime.Now;

            var rnd = new Random(currTime.Millisecond);
            for (cnt = 0; cnt < Hand.MaxHand; cnt ++)
            {
                colors[cnt] = rnd.Next(Hand.MaxSelectColors) + 1;
            }

            m_computerHand.SetColors(colors);
        }

        public Hand []GetGameHands()
        {
            return(m_gameHands);
        }

        public Hand GetComputerHand()
        {
            return(m_computerHand);
        }

        public RoundStatus []GetHandStatusList()
        {
            return(m_handStatus);
        }
    }
}
