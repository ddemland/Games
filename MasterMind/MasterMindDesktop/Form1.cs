using System;
using System.Drawing;
using System.Windows.Forms;
using MasterMind.Engine;

namespace MasterMindDesktop
{
    public partial class Form1 : Form
    {
        private int m_guess1;
        private int m_guess2;
        private int m_guess3;
        private int m_guess4;
        private int m_currHandCnt;
        private Hand m_computerHand;
        private readonly Hand m_currHand;
        private readonly Game m_game;

        public Form1()
        {
            InitializeComponent();

            m_computerHand = new Hand();
            m_currHand = new Hand();
            m_game = new Game();
            NewGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Row1Col1_Click(object sender, EventArgs e)
        {
            m_guess1 = GetNextColor(m_guess1);
            Row1Col1.BackColor = ConvertHandColor(m_guess1);
        }

        private void Row1Col2_Click(object sender, EventArgs e)
        {
            m_guess2 = GetNextColor(m_guess2);
            Row1Col2.BackColor = ConvertHandColor(m_guess2);
        }

        private void Row1Col3_Click(object sender, EventArgs e)
        {
            m_guess3 = GetNextColor(m_guess3);
            Row1Col3.BackColor = ConvertHandColor(m_guess3);
        }

        private void Row1Col4_Click(object sender, EventArgs e)
        {
            m_guess4 = GetNextColor(m_guess4);
            Row1Col4.BackColor = ConvertHandColor(m_guess4);
        }

        private void Row2Col1_Click(object sender, EventArgs e)
        {
            m_guess1 = GetNextColor(m_guess1);
            Row2Col1.BackColor = ConvertHandColor(m_guess1);
        }

        private void Row2Col2_Click(object sender, EventArgs e)
        {
            m_guess2 = GetNextColor(m_guess2);
            Row2Col2.BackColor = ConvertHandColor(m_guess2);
        }

        private void Row2Col3_Click(object sender, EventArgs e)
        {
            m_guess3 = GetNextColor(m_guess3);
            Row2Col3.BackColor = ConvertHandColor(m_guess3);
        }

        private void Row2Col4_Click(object sender, EventArgs e)
        {
            m_guess4 = GetNextColor(m_guess4);
            Row2Col4.BackColor = ConvertHandColor(m_guess4);
        }

        private void Row3Col1_Click(object sender, EventArgs e)
        {
            m_guess1 = GetNextColor(m_guess1);
            Row3Col1.BackColor = ConvertHandColor(m_guess1);
        }

        private void Row3Col2_Click(object sender, EventArgs e)
        {
            m_guess2 = GetNextColor(m_guess2);
            Row3Col2.BackColor = ConvertHandColor(m_guess2);
        }

        private void Row3Col3_Click(object sender, EventArgs e)
        {
            m_guess3 = GetNextColor(m_guess3);
            Row3Col3.BackColor = ConvertHandColor(m_guess3);
        }

        private void Row3Col4_Click(object sender, EventArgs e)
        {
            m_guess4 = GetNextColor(m_guess4);
            Row3Col4.BackColor = ConvertHandColor(m_guess4);
        }

        private void Row4Col1_Click(object sender, EventArgs e)
        {
            m_guess1 = GetNextColor(m_guess1);
            Row4Col1.BackColor = ConvertHandColor(m_guess1);
        }

        private void Row4Col2_Click(object sender, EventArgs e)
        {
            m_guess2 = GetNextColor(m_guess2);
            Row4Col2.BackColor = ConvertHandColor(m_guess2);
        }

        private void Row4Col3_Click(object sender, EventArgs e)
        {
            m_guess3 = GetNextColor(m_guess3);
            Row4Col3.BackColor = ConvertHandColor(m_guess3);
        }

        private void Row4Col4_Click(object sender, EventArgs e)
        {
            m_guess4 = GetNextColor(m_guess4);
            Row4Col4.BackColor = ConvertHandColor(m_guess4);
        }

        private void Row5Col1_Click(object sender, EventArgs e)
        {
            m_guess1 = GetNextColor(m_guess1);
            Row5Col1.BackColor = ConvertHandColor(m_guess1);
        }

        private void Row5Col2_Click(object sender, EventArgs e)
        {
            m_guess2 = GetNextColor(m_guess2);
            Row5Col2.BackColor = ConvertHandColor(m_guess2);
        }

        private void Row5Col3_Click(object sender, EventArgs e)
        {
            m_guess3 = GetNextColor(m_guess3);
            Row5Col3.BackColor = ConvertHandColor(m_guess3);
        }

        private void Row5Col4_Click(object sender, EventArgs e)
        {
            m_guess4 = GetNextColor(m_guess4);
            Row5Col4.BackColor = ConvertHandColor(m_guess4);
        }

        private void Row6Col1_Click(object sender, EventArgs e)
        {
            m_guess1 = GetNextColor(m_guess1);
            Row6Col1.BackColor = ConvertHandColor(m_guess1);
        }

        private void Row6Col2_Click(object sender, EventArgs e)
        {
            m_guess2 = GetNextColor(m_guess2);
            Row6Col2.BackColor = ConvertHandColor(m_guess2);
        }

        private void Row6Col3_Click(object sender, EventArgs e)
        {
            m_guess3 = GetNextColor(m_guess3);
            Row6Col3.BackColor = ConvertHandColor(m_guess3);
        }

        private void Row6Col4_Click(object sender, EventArgs e)
        {
            m_guess4 = GetNextColor(m_guess4);
            Row6Col4.BackColor = ConvertHandColor(m_guess4);
        }

        private void Row7Col1_Click(object sender, EventArgs e)
        {
            m_guess1 = GetNextColor(m_guess1);
            Row7Col1.BackColor = ConvertHandColor(m_guess1);
        }

        private void Row7Col2_Click(object sender, EventArgs e)
        {
            m_guess2 = GetNextColor(m_guess2);
            Row7Col2.BackColor = ConvertHandColor(m_guess2);
        }

        private void Row7Col3_Click(object sender, EventArgs e)
        {
            m_guess3 = GetNextColor(m_guess3);
            Row7Col3.BackColor = ConvertHandColor(m_guess3);
        }

        private void Row7Col4_Click(object sender, EventArgs e)
        {
            m_guess4 = GetNextColor(m_guess4);
            Row7Col4.BackColor = ConvertHandColor(m_guess4);
        }

        private void Row8Col1_Click(object sender, EventArgs e)
        {
            m_guess1 = GetNextColor(m_guess1);
            Row8Col1.BackColor = ConvertHandColor(m_guess1);
        }

        private void Row8Col2_Click(object sender, EventArgs e)
        {
            m_guess2 = GetNextColor(m_guess2);
            Row8Col2.BackColor = ConvertHandColor(m_guess2);
        }

        private void Row8Col3_Click(object sender, EventArgs e)
        {
            m_guess3 = GetNextColor(m_guess3);
            Row8Col3.BackColor = ConvertHandColor(m_guess3);
        }

        private void Row8Col4_Click(object sender, EventArgs e)
        {
            m_guess4 = GetNextColor(m_guess4);
            Row8Col4.BackColor = ConvertHandColor(m_guess4);
        }

        private static int GetNextColor(int P_currColor)
        {
            int retVal;

            if (P_currColor == Hand.NoColor)
            {
                retVal = Hand.Blue;
            }
            else if (P_currColor == Hand.Blue)
            {
                retVal = Hand.Green;
            }
            else if (P_currColor == Hand.Green)
            {
                retVal = Hand.Orange;
            }
            else if (P_currColor == Hand.Orange)
            {
                retVal = Hand.Purple;
            }
            else if (P_currColor == Hand.Purple)
            {
                retVal = Hand.Red;
            }
            else if (P_currColor == Hand.Red)
            {
                retVal = Hand.Yellow;
            }
            else retVal = P_currColor == Hand.Yellow ? Hand.Blue : Hand.NoColor;

            return (retVal);
        }

        private static Color ConvertHandColor(int P_color)
        {
            Color retVal;

            switch (P_color)
            {
                case Hand.Blue:
                    retVal = Color.Blue;
                    break;

                case Hand.Green:
                    retVal = Color.Green;
                    break;

                case Hand.Orange:
                    retVal = Color.Orange;
                    break;

                case Hand.Purple:
                    retVal = Color.Purple;
                    break;

                case Hand.Red:
                    retVal = Color.Red;
                    break;

                case Hand.Yellow:
                    retVal = Color.Yellow;
                    break;

                case Hand.White:
                    retVal = Color.White;
                    break;

                case Hand.Black:
                    retVal = Color.Black;
                    break;

                default:
                    retVal = Color.Gray;
                    break;
            }

            return (retVal);
        }

        private void Guess_Click(object sender, EventArgs e)
        {
            var guessList = new int[4];
            var statusList = new int[4];

            if (HaveFullGuess() == false)
            {
                return;
            }

            guessList[0] = m_guess1;
            guessList[1] = m_guess2;
            guessList[2] = m_guess3;
            guessList[3] = m_guess4;

            m_currHand.SetColors(guessList);
            m_computerHand.CompareHands(m_currHand, ref statusList);
            UpDateResults(statusList);

            EnableDisableSelectionRow(false);
            m_guess1 = Hand.NoColor;
            m_guess2 = Hand.NoColor;
            m_guess3 = Hand.NoColor;
            m_guess4 = Hand.NoColor;
            m_currHandCnt++;
            EnableDisableSelectionRow(true);

            if (m_computerHand.HandsSame(m_currHand))
            {
                DisplayComputerHand();
                MessageBox.Show("You Win!!!", "MasterMind",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                NewGame();
            }

            if (m_currHandCnt == Game.MaxHands)
            {
                DisplayComputerHand();
                MessageBox.Show("You Lost", "MasterMind",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                NewGame();
            }
        }

        private bool HaveFullGuess()
        {
            var retVal = !((m_guess1 == Hand.NoColor) ||
                            (m_guess2 == Hand.NoColor) ||
                            (m_guess3 == Hand.NoColor) ||
                            (m_guess4 == Hand.NoColor));

            return (retVal);
        }

        private void UpDateResults(int[] P_status)
        {
            switch (m_currHandCnt)
            {
                case 0:
                    Row1Status1.BackColor = ConvertHandColor(P_status[0]);
                    Row1Status2.BackColor = ConvertHandColor(P_status[1]);
                    Row1Status3.BackColor = ConvertHandColor(P_status[2]);
                    Row1Status4.BackColor = ConvertHandColor(P_status[3]);
                    break;

                case 1:
                    Row2Status1.BackColor = ConvertHandColor(P_status[0]);
                    Row2Status2.BackColor = ConvertHandColor(P_status[1]);
                    Row2Status3.BackColor = ConvertHandColor(P_status[2]);
                    Row2Status4.BackColor = ConvertHandColor(P_status[3]);
                    break;

                case 2:
                    Row3Status1.BackColor = ConvertHandColor(P_status[0]);
                    Row3Status2.BackColor = ConvertHandColor(P_status[1]);
                    Row3Status3.BackColor = ConvertHandColor(P_status[2]);
                    Row3Status4.BackColor = ConvertHandColor(P_status[3]);
                    break;

                case 3:
                    Row4Status1.BackColor = ConvertHandColor(P_status[0]);
                    Row4Status2.BackColor = ConvertHandColor(P_status[1]);
                    Row4Status3.BackColor = ConvertHandColor(P_status[2]);
                    Row4Status4.BackColor = ConvertHandColor(P_status[3]);
                    break;

                case 4:
                    Row5Status1.BackColor = ConvertHandColor(P_status[0]);
                    Row5Status2.BackColor = ConvertHandColor(P_status[1]);
                    Row5Status3.BackColor = ConvertHandColor(P_status[2]);
                    Row5Status4.BackColor = ConvertHandColor(P_status[3]);
                    break;

                case 5:
                    Row6Status1.BackColor = ConvertHandColor(P_status[0]);
                    Row6Status2.BackColor = ConvertHandColor(P_status[1]);
                    Row6Status3.BackColor = ConvertHandColor(P_status[2]);
                    Row6Status4.BackColor = ConvertHandColor(P_status[3]);
                    break;

                case 6:
                    Row7Status1.BackColor = ConvertHandColor(P_status[0]);
                    Row7Status2.BackColor = ConvertHandColor(P_status[1]);
                    Row7Status3.BackColor = ConvertHandColor(P_status[2]);
                    Row7Status4.BackColor = ConvertHandColor(P_status[3]);
                    break;

                case 7:
                    Row8Status1.BackColor = ConvertHandColor(P_status[0]);
                    Row8Status2.BackColor = ConvertHandColor(P_status[1]);
                    Row8Status3.BackColor = ConvertHandColor(P_status[2]);
                    Row8Status4.BackColor = ConvertHandColor(P_status[3]);
                    break;

                default:
                    break;
            }
        }

        private void EnableDisableSelectionRow(bool P_status)
        {
            switch (m_currHandCnt)
            {
                case 0:
                    Row1Col1.Enabled = P_status;
                    Row1Col2.Enabled = P_status;
                    Row1Col3.Enabled = P_status;
                    Row1Col4.Enabled = P_status;
                    break;

                case 1:
                    Row2Col1.Enabled = P_status;
                    Row2Col2.Enabled = P_status;
                    Row2Col3.Enabled = P_status;
                    Row2Col4.Enabled = P_status;
                    break;

                case 2:
                    Row3Col1.Enabled = P_status;
                    Row3Col2.Enabled = P_status;
                    Row3Col3.Enabled = P_status;
                    Row3Col4.Enabled = P_status;
                    break;

                case 3:
                    Row4Col1.Enabled = P_status;
                    Row4Col2.Enabled = P_status;
                    Row4Col3.Enabled = P_status;
                    Row4Col4.Enabled = P_status;
                    break;

                case 4:
                    Row5Col1.Enabled = P_status;
                    Row5Col2.Enabled = P_status;
                    Row5Col3.Enabled = P_status;
                    Row5Col4.Enabled = P_status;
                    break;

                case 5:
                    Row6Col1.Enabled = P_status;
                    Row6Col2.Enabled = P_status;
                    Row6Col3.Enabled = P_status;
                    Row6Col4.Enabled = P_status;
                    break;

                case 6:
                    Row7Col1.Enabled = P_status;
                    Row7Col2.Enabled = P_status;
                    Row7Col3.Enabled = P_status;
                    Row7Col4.Enabled = P_status;
                    break;

                case 7:
                    Row8Col1.Enabled = P_status;
                    Row8Col2.Enabled = P_status;
                    Row8Col3.Enabled = P_status;
                    Row8Col4.Enabled = P_status;
                    break;
            }
        }

        private void DisplayComputerHand()
        {
            var colors = new int[4];

            m_computerHand.GetColors(ref colors);

            Computer1.BackColor = ConvertHandColor(colors[0]);
            Computer2.BackColor = ConvertHandColor(colors[1]);
            Computer3.BackColor = ConvertHandColor(colors[2]);
            Computer4.BackColor = ConvertHandColor(colors[3]);
        }

        private void NewGame()
        {
            EnableDisableSelectionRow(false);
            m_currHandCnt = 0;
            m_guess1 = Hand.NoColor;
            m_guess2 = Hand.NoColor;
            m_guess3 = Hand.NoColor;
            m_guess4 = Hand.NoColor;

            m_game.StartGame();
            m_computerHand = m_game.GetComputerHand();
            EnableDisableSelectionRow(true);
            ClearAllButtons();
        }

        private void ClearAllButtons()
        {
            Row1Col1.BackColor =
            Row1Col2.BackColor =
            Row1Col3.BackColor =
            Row1Col4.BackColor =
            Row1Status3.BackColor =
            Row1Status2.BackColor =
            Row1Status1.BackColor =
            Row1Status4.BackColor =
            Computer4.BackColor =
            Computer3.BackColor =
            Computer2.BackColor =
            Computer1.BackColor =
            Row2Col4.BackColor =
            Row2Col3.BackColor =
            Row2Col2.BackColor =
            Row2Col1.BackColor =
            Row3Col4.BackColor =
            Row3Col3.BackColor =
            Row3Col2.BackColor =
            Row3Col1.BackColor =
            Row4Col4.BackColor =
            Row4Col3.BackColor =
            Row4Col2.BackColor =
            Row4Col1.BackColor =
            Row8Col4.BackColor =
            Row8Col3.BackColor =
            Row8Col2.BackColor =
            Row8Col1.BackColor =
            Row7Col4.BackColor =
            Row7Col3.BackColor =
            Row7Col2.BackColor =
            Row7Col1.BackColor =
            Row6Col4.BackColor =
            Row6Col3.BackColor =
            Row6Col2.BackColor =
            Row6Col1.BackColor =
            Row5Col4.BackColor =
            Row5Col3.BackColor =
            Row5Col2.BackColor =
            Row5Col1.BackColor =
            Row2Status1.BackColor =
            Row3Status1.BackColor =
            Row4Status1.BackColor =
            Row2Status4.BackColor =
            Row2Status3.BackColor =
            Row2Status2.BackColor =
            Row3Status4.BackColor =
            Row3Status3.BackColor =
            Row3Status2.BackColor =
            Row4Status4.BackColor =
            Row4Status3.BackColor =
            Row4Status2.BackColor =
            Row8Status4.BackColor =
            Row8Status3.BackColor =
            Row8Status2.BackColor =
            Row8Status1.BackColor =
            Row7Status4.BackColor =
            Row7Status3.BackColor =
            Row7Status2.BackColor =
            Row7Status1.BackColor =
            Row6Status4.BackColor =
            Row6Status3.BackColor =
            Row6Status2.BackColor =
            Row6Status1.BackColor =
            Row5Status4.BackColor =
            Row5Status3.BackColor =
            Row5Status2.BackColor =
            Row5Status1.BackColor = SystemColors.Control;
        }
    }
}
