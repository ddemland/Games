
using System.Drawing;
using System.Windows.Forms;
using Merlin.Engine;

namespace MerlinDesktop
{
    public partial class GridGUI : Form
    {
        private readonly Grid m_playingGrid;
        private readonly Button[] m_buttonList;

        public GridGUI()
        {
            InitializeComponent();
            m_buttonList = new Button[Grid.MaxSquares];

            m_buttonList[0] = button1;
            m_buttonList[1] = button2;
            m_buttonList[2] = button3;
            m_buttonList[3] = button4;
            m_buttonList[4] = button5;
            m_buttonList[5] = button6;
            m_buttonList[6] = button7;
            m_buttonList[7] = button8;
            m_buttonList[8] = button9;

            m_playingGrid = new Grid();
            StartGame();
        }

        private void StartGame()
        {
            m_playingGrid.InitGrid();
            m_playingGrid.RandomizeStartingGrid();
            DisplayGrid();
        }

        private void DisplayGrid()
        {
            int cnt;

            var currSquare = m_playingGrid.GetGrid();
            for (cnt = 0; cnt < Grid.MaxSquares; cnt++)
            {
                int state = currSquare[cnt].GetState();
                m_buttonList[cnt].BackColor = GetDisplayColor(state);
            }
        }

        private static Color GetDisplayColor(int state)
        {
            Color retVal;

            switch (state)
            {
                case 0:
                    retVal = Color.Red;
                    break;

                case 1:
                    retVal = Color.Green;
                    break;

                default:
                    retVal = SystemColors.Control;
                    break;
            }

            return (retVal);
        }

        private void CheckForWin()
        {
            if (m_playingGrid.GameWon())
            {
                MessageBox.Show("You Won !!!", "Merlin's Magic Squares",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                StartGame();
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ProcessButton(0);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            ProcessButton(1);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            ProcessButton(2);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            ProcessButton(3);
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            ProcessButton(4);
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            ProcessButton(5);
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            ProcessButton(6);
        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            ProcessButton(7);
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            ProcessButton(8);
        }

        private void ProcessButton(int num)
        {
            m_playingGrid.ToggleGrid(num);
            DisplayGrid();
            CheckForWin();
        }
    }
}
