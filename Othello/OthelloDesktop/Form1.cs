
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Othello.Engine;

namespace OthelloDesktop
{
    public partial class Othello : Form
    {
        private readonly Color Player1Color = Color.Lime;
        private readonly Color Player2Color = Color.Yellow;
        private readonly Grid m_grid;
        private bool m_playerOne;
        private bool m_gameOver;
        private readonly Button[,] m_squareList;
        private readonly Bitmap m_player1Disc;
        private readonly Bitmap m_player2Disc;
        private readonly Bitmap m_canSelect;
        private readonly Bitmap m_unknown;
        private readonly Bitmap m_hint;

        public Othello()
        {
            InitializeComponent();

            m_grid = new Grid();
            m_squareList = new Button[Grid.MaxSide, Grid.MaxSide];
            m_squareList[0, 0] = button_0_0;
            m_squareList[0, 1] = button_0_1;
            m_squareList[0, 2] = button_0_2;
            m_squareList[0, 3] = button_0_3;
            m_squareList[0, 4] = button_0_4;
            m_squareList[0, 5] = button_0_5;
            m_squareList[0, 6] = button_0_6;
            m_squareList[0, 7] = button_0_7;
            m_squareList[1, 0] = button_1_0;
            m_squareList[1, 1] = button_1_1;
            m_squareList[1, 2] = button_1_2;
            m_squareList[1, 3] = button_1_3;
            m_squareList[1, 4] = button_1_4;
            m_squareList[1, 5] = button_1_5;
            m_squareList[1, 6] = button_1_6;
            m_squareList[1, 7] = button_1_7;
            m_squareList[2, 0] = button_2_0;
            m_squareList[2, 1] = button_2_1;
            m_squareList[2, 2] = button_2_2;
            m_squareList[2, 3] = button_2_3;
            m_squareList[2, 4] = button_2_4;
            m_squareList[2, 5] = button_2_5;
            m_squareList[2, 6] = button_2_6;
            m_squareList[2, 7] = button_2_7;
            m_squareList[3, 0] = button_3_0;
            m_squareList[3, 1] = button_3_1;
            m_squareList[3, 2] = button_3_2;
            m_squareList[3, 3] = button_3_3;
            m_squareList[3, 4] = button_3_4;
            m_squareList[3, 5] = button_3_5;
            m_squareList[3, 6] = button_3_6;
            m_squareList[3, 7] = button_3_7;
            m_squareList[4, 0] = button_4_0;
            m_squareList[4, 1] = button_4_1;
            m_squareList[4, 2] = button_4_2;
            m_squareList[4, 3] = button_4_3;
            m_squareList[4, 4] = button_4_4;
            m_squareList[4, 5] = button_4_5;
            m_squareList[4, 6] = button_4_6;
            m_squareList[4, 7] = button_4_7;
            m_squareList[5, 0] = button_5_0;
            m_squareList[5, 1] = button_5_1;
            m_squareList[5, 2] = button_5_2;
            m_squareList[5, 3] = button_5_3;
            m_squareList[5, 4] = button_5_4;
            m_squareList[5, 5] = button_5_5;
            m_squareList[5, 6] = button_5_6;
            m_squareList[5, 7] = button_5_7;
            m_squareList[6, 0] = button_6_0;
            m_squareList[6, 1] = button_6_1;
            m_squareList[6, 2] = button_6_2;
            m_squareList[6, 3] = button_6_3;
            m_squareList[6, 4] = button_6_4;
            m_squareList[6, 5] = button_6_5;
            m_squareList[6, 6] = button_6_6;
            m_squareList[6, 7] = button_6_7;
            m_squareList[7, 0] = button_7_0;
            m_squareList[7, 1] = button_7_1;
            m_squareList[7, 2] = button_7_2;
            m_squareList[7, 3] = button_7_3;
            m_squareList[7, 4] = button_7_4;
            m_squareList[7, 5] = button_7_5;
            m_squareList[7, 6] = button_7_6;
            m_squareList[7, 7] = button_7_7;

            Player1TotalBox.BackColor = Player1Color;
            Player2TotalBox.BackColor = Player2Color;

            string exeDir = GetExeDir();
            m_player1Disc = new Bitmap($@"{exeDir}\Player1Disc.gif");
            m_player2Disc = new Bitmap($@"{exeDir}\Player2Disc.gif");
            m_canSelect = new Bitmap($@"{exeDir}\CanSelect.gif");
            m_unknown = new Bitmap($@"{exeDir}\Unknown.gif");
            m_hint = new Bitmap($@"{exeDir}\TurnOver.gif");
        }

        private void Othello_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            m_playerOne = true;
            m_gameOver = false;

            m_grid.InitGame();
            DisplayCurrentPlayer();
            m_grid.MarkAllCanSelect(m_playerOne);
            DisplayGrid();
        }

        private void DisplayCurrentPlayer()
        {
            CurrentPlayerStatus.Text = m_playerOne ? "Player 1" : "Player 2";
            CurrentPlayerStatus.BackColor = m_playerOne ? Player1Color : Player2Color;
        }

        private void DisplayGrid()
        {
            for (var row = 0; row < Grid.MaxSide; row++)
            {
                for (var column = 0; column < Grid.MaxSide; column++)
                {
                    var state = m_grid.GetSquareState(row, column);

                    if ((state != Grid.StateCanSelect) || (showHintsMenuItem.Checked))
                    {
                        var image = GetButtonImage(state);
                        m_squareList[row, column].Image = image;
                    }
                    else
                    {
                        m_squareList[row, column].Image = null;
                    }
                }
            }

            DisplayPlayerTotals();
        }

        private Bitmap GetButtonImage(int state)
        {
            Bitmap retGraphic;

            switch (state)
            {
                case Grid.StateEmpty:
                    return null;

                case Grid.StatePlayer1:
                    retGraphic = m_player1Disc;
                    break;

                case Grid.StatePlayer2:
                    retGraphic = m_player2Disc;
                    break;

                case Grid.StateCanSelect:
                    retGraphic = m_canSelect;
                    break;

                case Grid.StateTurnOver:
                    retGraphic = m_hint;
                    break;

                default:
                    retGraphic = m_unknown;
                    break;
            }

            return retGraphic;
        }

        private void DisplayPlayerTotals()
        {
            var playerOne = m_grid.CountPlayerOneSquares();
            var playerTwo = m_grid.CountPlayerTwoSquares();

            Player1TotalBox.Text = playerOne.ToString();
            Player2TotalBox.Text = playerTwo.ToString();
        }

        private static string GetExeDir()
        {
            var currProcess = Process.GetCurrentProcess();
            var processMod = currProcess.MainModule;
            if (processMod != null)
            {
                var fullName = Path.GetFullPath(processMod.ModuleName);
                var retVal = Path.GetDirectoryName(fullName);

                return retVal;
            }

            return "";
        }

        private void showHintsMenuItem_Click(object sender, EventArgs e)
        {
            DisplayGrid();
        }

        private void DoSquareSelect(int row, int column)
        {
            if (!m_grid.IsCanSelect(row, column))
            {
                return;
            }

            GameMessageBox.Text = "";
            m_grid.SelectSquare(row, column, m_playerOne);
            DisplayGrid();

            if (!ShowTurnOverBox.Checked)
            {
                m_playerOne ^= true;
                DisplayCurrentPlayer();
                m_grid.ClearAllCanSelectSquares();

                var none2Select = m_grid.MarkAllCanSelect(m_playerOne);

                DisplayGrid();

                if (m_grid.AllSquaresCovered())
                {
                    var playerOne = m_grid.CountPlayerOneSquares();
                    var playerTwo = m_grid.CountPlayerTwoSquares();
                    var winningPlayer = playerOne > playerTwo ? "1" : "2";
                    GameMessageBox.Text = $@"Player {winningPlayer} Wins";

                    m_gameOver = true;
                    DisplayGrid();
                    return;
                }

                if (!none2Select)
                {
                    string playerStr, nextPlayerStr;
                    DisplayGrid();

                    if (m_playerOne)
                    {
                        playerStr = "One";
                        nextPlayerStr = "Two";
                    }
                    else
                    {
                        playerStr = "Two";
                        nextPlayerStr = "One";
                    }

                    GameMessageBox.Text = $@"Player {playerStr} has No Play, Turn goes to Player {nextPlayerStr}";

                    m_playerOne ^= true;
                    DisplayCurrentPlayer();
                    if (!m_grid.MarkAllCanSelect(m_playerOne))
                    {
                        m_gameOver = true;
                        GameMessageBox.Text = @"No Plays Left, Game Over.";
                        return;
                    }

                    DisplayGrid();
                }
            }
            else
            {
                m_grid.ClearTurnOverSquares(m_playerOne);
            }
        }

        private void button_0_0_Click(object sender, EventArgs e)
        {
            DoSquareSelect(0, 0);
        }

        private void button_0_1_Click(object sender, EventArgs e)
        {
            DoSquareSelect(0, 1);
        }

        private void button_0_2_Click(object sender, EventArgs e)
        {
            DoSquareSelect(0, 2);
        }

        private void button_0_3_Click(object sender, EventArgs e)
        {
            DoSquareSelect(0, 3);
        }

        private void button_0_4_Click(object sender, EventArgs e)
        {
            DoSquareSelect(0, 4);
        }

        private void button_0_5_Click(object sender, EventArgs e)
        {
            DoSquareSelect(0, 5);
        }

        private void button_0_6_Click(object sender, EventArgs e)
        {
            DoSquareSelect(0, 6);
        }

        private void button_0_7_Click(object sender, EventArgs e)
        {
            DoSquareSelect(0, 7);
        }

        private void button_1_0_Click(object sender, EventArgs e)
        {
            DoSquareSelect(1, 0);
        }

        private void button_1_1_Click(object sender, EventArgs e)
        {
            DoSquareSelect(1, 1);
        }

        private void button_1_2_Click(object sender, EventArgs e)
        {
            DoSquareSelect(1, 2);
        }

        private void button_1_3_Click(object sender, EventArgs e)
        {
            DoSquareSelect(1, 3);
        }

        private void button_1_4_Click(object sender, EventArgs e)
        {
            DoSquareSelect(1, 4);
        }

        private void button_1_5_Click(object sender, EventArgs e)
        {
            DoSquareSelect(1, 5);
        }

        private void button_1_6_Click(object sender, EventArgs e)
        {
            DoSquareSelect(1, 6);
        }

        private void button_1_7_Click(object sender, EventArgs e)
        {
            DoSquareSelect(1, 7);
        }

        private void button_2_0_Click(object sender, EventArgs e)
        {
            DoSquareSelect(2, 0);
        }

        private void button_2_1_Click(object sender, EventArgs e)
        {
            DoSquareSelect(2, 1);
        }

        private void button_2_2_Click(object sender, EventArgs e)
        {
            DoSquareSelect(2, 2);
        }

        private void button_2_3_Click(object sender, EventArgs e)
        {
            DoSquareSelect(2, 3);
        }

        private void button_2_4_Click(object sender, EventArgs e)
        {
            DoSquareSelect(2, 4);
        }

        private void button_2_5_Click(object sender, EventArgs e)
        {
            DoSquareSelect(2, 5);
        }

        private void button_2_6_Click(object sender, EventArgs e)
        {
            DoSquareSelect(2, 6);
        }

        private void button_2_7_Click(object sender, EventArgs e)
        {
            DoSquareSelect(2, 7);
        }

        private void button_3_0_Click(object sender, EventArgs e)
        {
            DoSquareSelect(3, 0);
        }

        private void button_3_1_Click(object sender, EventArgs e)
        {
            DoSquareSelect(3, 1);
        }

        private void button_3_2_Click(object sender, EventArgs e)
        {
            DoSquareSelect(3, 2);
        }

        private void button_3_3_Click(object sender, EventArgs e)
        {
            DoSquareSelect(3, 3);
        }

        private void button_3_4_Click(object sender, EventArgs e)
        {
            DoSquareSelect(3, 4);
        }

        private void button_3_5_Click(object sender, EventArgs e)
        {
            DoSquareSelect(3, 5);
        }

        private void button_3_6_Click(object sender, EventArgs e)
        {
            DoSquareSelect(3, 6);
        }

        private void button_3_7_Click(object sender, EventArgs e)
        {
            DoSquareSelect(3, 7);
        }

        private void button_4_0_Click(object sender, EventArgs e)
        {
            DoSquareSelect(4, 0);
        }

        private void button_4_1_Click(object sender, EventArgs e)
        {
            DoSquareSelect(4, 1);
        }

        private void button_4_2_Click(object sender, EventArgs e)
        {
            DoSquareSelect(4, 2);
        }

        private void button_4_3_Click(object sender, EventArgs e)
        {
            DoSquareSelect(4, 3);
        }

        private void button_4_4_Click(object sender, EventArgs e)
        {
            DoSquareSelect(4, 4);
        }

        private void button_4_5_Click(object sender, EventArgs e)
        {
            DoSquareSelect(4, 5);
        }

        private void button_4_6_Click(object sender, EventArgs e)
        {
            DoSquareSelect(4, 6);
        }

        private void button_4_7_Click(object sender, EventArgs e)
        {
            DoSquareSelect(4, 7);
        }

        private void button_5_0_Click(object sender, EventArgs e)
        {
            DoSquareSelect(5, 0);
        }

        private void button_5_1_Click(object sender, EventArgs e)
        {
            DoSquareSelect(5, 1);
        }

        private void button_5_2_Click(object sender, EventArgs e)
        {
            DoSquareSelect(5, 2);
        }

        private void button_5_3_Click(object sender, EventArgs e)
        {
            DoSquareSelect(5, 3);
        }

        private void button_5_4_Click(object sender, EventArgs e)
        {
            DoSquareSelect(5, 4);
        }

        private void button_5_5_Click(object sender, EventArgs e)
        {
            DoSquareSelect(5, 5);
        }

        private void button_5_6_Click(object sender, EventArgs e)
        {
            DoSquareSelect(5, 6);
        }

        private void button_5_7_Click(object sender, EventArgs e)
        {
            DoSquareSelect(5, 7);
        }

        private void button_6_0_Click(object sender, EventArgs e)
        {
            DoSquareSelect(6, 0);
        }

        private void button_6_1_Click(object sender, EventArgs e)
        {
            DoSquareSelect(6, 1);
        }

        private void button_6_2_Click(object sender, EventArgs e)
        {
            DoSquareSelect(6, 2);
        }

        private void button_6_3_Click(object sender, EventArgs e)
        {
            DoSquareSelect(6, 3);
        }

        private void button_6_4_Click(object sender, EventArgs e)
        {
            DoSquareSelect(6, 4);
        }

        private void button_6_5_Click(object sender, EventArgs e)
        {
            DoSquareSelect(6, 5);
        }

        private void button_6_6_Click(object sender, EventArgs e)
        {
            DoSquareSelect(6, 6);
        }

        private void button_6_7_Click(object sender, EventArgs e)
        {
            DoSquareSelect(6, 7);
        }

        private void button_7_0_Click(object sender, EventArgs e)
        {
            DoSquareSelect(7, 0);
        }

        private void button_7_1_Click(object sender, EventArgs e)
        {
            DoSquareSelect(7, 1);
        }

        private void button_7_2_Click(object sender, EventArgs e)
        {
            DoSquareSelect(7, 2);
        }

        private void button_7_3_Click(object sender, EventArgs e)
        {
            DoSquareSelect(7, 3);
        }

        private void button_7_4_Click(object sender, EventArgs e)
        {
            DoSquareSelect(7, 4);
        }

        private void button_7_5_Click(object sender, EventArgs e)
        {
            DoSquareSelect(7, 5);
        }

        private void button_7_6_Click(object sender, EventArgs e)
        {
            DoSquareSelect(7, 6);
        }

        private void button_7_7_Click(object sender, EventArgs e)
        {
            DoSquareSelect(7, 7);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_gameOver)
            {
                StartGame();
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ShowTurnOverBox_CheckedChanged(object sender, EventArgs e)
        {
            m_grid.ShowTurnOver = !m_grid.ShowTurnOver;
        }
    }
}
