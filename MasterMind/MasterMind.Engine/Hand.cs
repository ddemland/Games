
namespace MasterMind.Engine
{
	/// <summary>
	/// Summary description for Hand.
	/// </summary>
	public class Hand
	{
        public const int MaxHand = 4;

        public const int NoColor = 0;
        public const int Red = 1;
        public const int Orange = 2;
        public const int Yellow = 3;
        public const int Green = 4;
        public const int Blue = 5;
        public const int Purple = 6;
        public const int Black = 7;
        public const int White = 8;

        public const int MaxSelectColors = 6;

        private readonly int [] m_color;
        private readonly bool [] m_checked;

		public Hand()
		{
            m_color = new int[MaxHand];
            m_checked = new bool[MaxHand];
		}

        public void ResetHand()
        {
            int cnt;

            for (cnt = 0; cnt < MaxHand; cnt ++)
            {
                m_color[cnt] = NoColor;
            }
        }

        public void SetColors(int []P_colorList)
        {
            int cnt;

            for (cnt = 0; cnt < MaxHand; cnt ++)
            {
                m_color[cnt] = P_colorList[cnt];
            }
        }

        public void GetColors(ref int []P_colorList)
        {
            P_colorList = m_color;
        }

        public void CompareHands(Hand P_hand, ref int [] P_answerSet)
        {
            int cnt;
            var checkColorList = new int[1];

            P_hand.GetHand(ref checkColorList);
            P_hand.ClearCheckedStatus();
            bool[] secondHandCheckList = P_hand.GetCheckStatus();
            ClearCheckedStatus();

            int blackCnt = 0;
            for (cnt = 0; cnt < MaxHand; cnt ++)
            {
                if (RightColorRightSpot(checkColorList[cnt], cnt))
                {
                    blackCnt ++;
                    m_checked[cnt] = secondHandCheckList[cnt] = true;
                }
            }

            int whiteCnt = 0;
            for (cnt = 0; cnt < MaxHand; cnt ++)
            {
                if (RightColorWrongSpot(checkColorList[cnt], cnt, secondHandCheckList))
                {
                    whiteCnt ++;
                }
            }

            int retIdx = 0;
            for (cnt = 0; cnt < blackCnt; cnt ++, retIdx ++)
            {
                P_answerSet[retIdx] = Black;
            }

            for (cnt = 0; cnt < whiteCnt; cnt ++, retIdx ++)
            {
                P_answerSet[retIdx] = White;
            }

            for (; retIdx < MaxHand; retIdx ++)
            {
                P_answerSet[retIdx] = NoColor;
            }
        }

        public bool []GetCheckStatus()
        {
            return(m_checked);
        }

        public void GetHand(ref int []P_colorList)
        {
            P_colorList = m_color;
        }

        public bool HandsSame(Hand P_hand)
        {
            int cnt;
            var checkListPtr = new int[1];

            P_hand.GetHand(ref checkListPtr);
            for (cnt = 0; cnt < MaxHand; cnt ++)
            {
                if (m_color[cnt] != checkListPtr[cnt])
                {
                    return(false);
                }
            }

            return(true);
        }

        private void ClearCheckedStatus()
        {
            int cnt;

            for (cnt = 0; cnt < MaxHand; cnt ++)
            {
                m_checked[cnt] = false;
            }
        }

        private bool RightColorRightSpot(int P_color, int P_index)
        {
            return(m_color[P_index] == P_color);
        }

        private bool RightColorWrongSpot(int P_color, int P_lookForIdx, bool[] P_checkList)
        {
            bool rightColorFlag = false;

            if (!P_checkList[P_lookForIdx])
            {
                for (int cnt = 0; cnt < MaxHand; cnt ++)
                {
                    if (cnt == P_lookForIdx)
                    {
                        if (m_color[cnt] == P_color)
                        {
                            break;
                        }

                        continue;
                    }

                    if (m_checked[cnt])
                    {
                        continue;
                    }

                    if (m_color[cnt] == P_color)
                    {
                        rightColorFlag = true;
                        m_checked[cnt] = true;
                        P_checkList[P_lookForIdx] = true;
                        break;
                    }
                }
            }

            return(rightColorFlag);
        }
	}
}
