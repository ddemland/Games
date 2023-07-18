
using TicTacToe.Library;

namespace TicTacToe.GUI
{
    public partial class TicTacToeForm : Form
    {
        private Library.TicTacToe m_game;
        private bool m_playerFirst;

        public TicTacToeForm()
        {
            InitializeComponent();
            m_game = new Library.TicTacToe();
            m_playerFirst = true;
            InitGame();
        }

        private void TicTacToePanel_Paint(object sender, PaintEventArgs e)
        {
            var scaling = SystemScalingHelper.GetSystemScaling();
            var surface = e.Graphics;
            var pen = new Pen(Color.Black, (int)Math.Round(14 * scaling));

            var panelWidth = TicTacToePanel.Width;
            var panelHeight = TicTacToePanel.Height;

            // Original unscaled points
            var points = new Point[]
            {
                new Point((int)Math.Round((0.04 * panelWidth)), (int)Math.Round((0.33 * panelHeight))),
                new Point((int)Math.Round((0.95 * panelWidth)), (int)Math.Round((0.33 * panelHeight))),
                new Point((int)Math.Round((0.04 * panelWidth)), (int)Math.Round((0.66 * panelHeight))),
                new Point((int)Math.Round((0.95 * panelWidth)), (int)Math.Round((0.66 * panelHeight))),
                new Point((int)Math.Round((0.34 * panelWidth)), (int)Math.Round((0.03 * panelHeight))),
                new Point((int)Math.Round((0.34 * panelWidth)), (int)Math.Round((0.97 * panelHeight))),
                new Point((int)Math.Round((0.66 * panelWidth)), (int)Math.Round((0.03 * panelHeight))),
                new Point((int)Math.Round((0.66 * panelWidth)), (int)Math.Round((0.97 * panelHeight)))
            };

            surface.DrawLine(pen, points[0], points[1]);
            surface.DrawLine(pen, points[2], points[3]);
            surface.DrawLine(pen, points[4], points[5]);
            surface.DrawLine(pen, points[6], points[7]);
        }

        private void TicTacToeLoad(object sender, EventArgs e)
        {
        }

        private void ComputerFirstMenu_Click(object sender, EventArgs e)
        {
            m_playerFirst = !m_playerFirst;
            ComputerFirstMenu.Checked = !m_playerFirst;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void InitGame()
        {
            Cell_0_0.Text = "";
            Cell_0_1.Text = "";
            Cell_0_2.Text = "";
            Cell_1_0.Text = "";
            Cell_1_1.Text = "";
            Cell_1_2.Text = "";
            Cell_2_0.Text = "";
            Cell_2_1.Text = "";
            Cell_2_2.Text = "";

            if (!m_playerFirst)
            {
                DoComputerTurn();
            }
        }

        private void SetCellPlayerStatus(int row, int column, Control button)
        {
            if (!m_game.SetCellState(row, column, Cell.CellStates.Player1))
            {
                return;
            }

            button.Text = "X";
            if (GameOver())
            {
                return;
            }

            DoComputerTurn();
            GameOver();
        }

        private void DoComputerTurn()
        {
            var aiCell = AIPlayer.Player.GetAIPlacement(m_game.Board);
            var inputRow = aiCell.Row;
            var inputColumn = aiCell.Column;
            m_game.SetCellState(inputRow, inputColumn, Cell.CellStates.Computer);
            SetComputerCellText(inputRow, inputColumn);
        }

        private bool GameOver()
        {
            var status = m_game.GetWinStatus();
            if ((status == Library.TicTacToe.WinStatus.NoWinner) &&
                (m_game.OpenCells() != 0))
            {
                return false;
            }

            DisplayWinDialog(status);
            m_game = new Library.TicTacToe();
            InitGame();
            return true;

        }

        private void DisplayWinDialog(Library.TicTacToe.WinStatus status)
        {
            string winner;
            if (status == Library.TicTacToe.WinStatus.Player1)
            {
                MessageBox.Show("You Won !!!", "Tic Tac Toe",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (status == Library.TicTacToe.WinStatus.Computer)
            {
                MessageBox.Show("Computer Won!!!", "Tic Tac Toe",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Winner.", "Tic Tac Toe",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetComputerCellText(int row, int column)
        {
            switch (row)
            {
                case 0 when column == 0:
                    Cell_0_0.Text = "O";
                    break;

                case 0 when column == 1:
                    Cell_0_1.Text = "O";
                    break;

                case 0:
                    Cell_0_2.Text = "O";
                    break;

                case 1 when column == 0:
                    Cell_1_0.Text = "O";
                    break;

                case 1 when column == 1:
                    Cell_1_1.Text = "O";
                    break;

                case 1:
                    Cell_1_2.Text = "O";
                    break;

                default:
                    {
                        switch (column)
                        {
                            case 0:
                                Cell_2_0.Text = "O";
                                break;
                            case 1:
                                Cell_2_1.Text = "O";
                                break;
                            default:
                                Cell_2_2.Text = "O";
                                break;
                        }

                        break;
                    }
            }
        }

        private void Cell_0_0_Click(object sender, EventArgs e)
        {
            SetCellPlayerStatus(0, 0, Cell_0_0);
        }

        private void Cell_0_1_Click(object sender, EventArgs e)
        {
            SetCellPlayerStatus(0, 1, Cell_0_1);
        }

        private void Cell_0_2_Click(object sender, EventArgs e)
        {
            SetCellPlayerStatus(0, 2, Cell_0_2);
        }

        private void Cell_1_0_Click(object sender, EventArgs e)
        {
            SetCellPlayerStatus(1, 0, Cell_1_0);
        }

        private void Cell_1_1_Click(object sender, EventArgs e)
        {
            SetCellPlayerStatus(1, 1, Cell_1_1);
        }

        private void Cell_1_2_Click(object sender, EventArgs e)
        {
            SetCellPlayerStatus(1, 2, Cell_1_2);
        }

        private void Cell_2_0_Click(object sender, EventArgs e)
        {
            SetCellPlayerStatus(2, 0, Cell_2_0);
        }

        private void Cell_2_1_Click(object sender, EventArgs e)
        {
            SetCellPlayerStatus(2, 1, Cell_2_1);
        }

        private void Cell_2_2_Click(object sender, EventArgs e)
        {
            SetCellPlayerStatus(2, 2, Cell_2_2);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_game = new Library.TicTacToe();
            InitGame();
        }
    }
}