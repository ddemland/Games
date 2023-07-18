namespace TicTacToe.GUI
{
    partial class TicTacToeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TicTacToeMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            ComputerFirstMenu = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            TicTacToePanel = new Panel();
            Cell_2_2 = new Button();
            Cell_1_2 = new Button();
            Cell_0_2 = new Button();
            Cell_2_1 = new Button();
            Cell_1_1 = new Button();
            Cell_0_1 = new Button();
            Cell_2_0 = new Button();
            Cell_1_0 = new Button();
            Cell_0_0 = new Button();
            TicTacToeMenu.SuspendLayout();
            TicTacToePanel.SuspendLayout();
            SuspendLayout();
            // 
            // TicTacToeMenu
            // 
            TicTacToeMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            TicTacToeMenu.Location = new Point(0, 0);
            TicTacToeMenu.Name = "TicTacToeMenu";
            TicTacToeMenu.Size = new Size(314, 24);
            TicTacToeMenu.TabIndex = 0;
            TicTacToeMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ComputerFirstMenu, newGameToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // ComputerFirstMenu
            // 
            ComputerFirstMenu.Name = "ComputerFirstMenu";
            ComputerFirstMenu.Size = new Size(153, 22);
            ComputerFirstMenu.Text = "Computer First";
            ComputerFirstMenu.Click += ComputerFirstMenu_Click;
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.Size = new Size(153, 22);
            newGameToolStripMenuItem.Text = "New Game";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(153, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // TicTacToePanel
            // 
            TicTacToePanel.Controls.Add(Cell_2_2);
            TicTacToePanel.Controls.Add(Cell_1_2);
            TicTacToePanel.Controls.Add(Cell_0_2);
            TicTacToePanel.Controls.Add(Cell_2_1);
            TicTacToePanel.Controls.Add(Cell_1_1);
            TicTacToePanel.Controls.Add(Cell_0_1);
            TicTacToePanel.Controls.Add(Cell_2_0);
            TicTacToePanel.Controls.Add(Cell_1_0);
            TicTacToePanel.Controls.Add(Cell_0_0);
            TicTacToePanel.Dock = DockStyle.Fill;
            TicTacToePanel.Location = new Point(0, 24);
            TicTacToePanel.Name = "TicTacToePanel";
            TicTacToePanel.Size = new Size(314, 303);
            TicTacToePanel.TabIndex = 1;
            TicTacToePanel.Paint += TicTacToePanel_Paint;
            // 
            // Cell_2_2
            // 
            Cell_2_2.Font = new Font("Microsoft Sans Serif", 50.25F, FontStyle.Regular, GraphicsUnit.Point);
            Cell_2_2.Location = new Point(217, 211);
            Cell_2_2.Name = "Cell_2_2";
            Cell_2_2.Size = new Size(80, 80);
            Cell_2_2.TabIndex = 36;
            Cell_2_2.UseVisualStyleBackColor = true;
            Cell_2_2.Click += Cell_2_2_Click;
            // 
            // Cell_1_2
            // 
            Cell_1_2.Font = new Font("Microsoft Sans Serif", 50.25F, FontStyle.Regular, GraphicsUnit.Point);
            Cell_1_2.Location = new Point(217, 111);
            Cell_1_2.Name = "Cell_1_2";
            Cell_1_2.Size = new Size(80, 80);
            Cell_1_2.TabIndex = 35;
            Cell_1_2.UseVisualStyleBackColor = true;
            Cell_1_2.Click += Cell_1_2_Click;
            // 
            // Cell_0_2
            // 
            Cell_0_2.Font = new Font("Microsoft Sans Serif", 50.25F, FontStyle.Regular, GraphicsUnit.Point);
            Cell_0_2.Location = new Point(217, 11);
            Cell_0_2.Name = "Cell_0_2";
            Cell_0_2.Size = new Size(80, 80);
            Cell_0_2.TabIndex = 34;
            Cell_0_2.UseVisualStyleBackColor = true;
            Cell_0_2.Click += Cell_0_2_Click;
            // 
            // Cell_2_1
            // 
            Cell_2_1.Font = new Font("Microsoft Sans Serif", 50.25F, FontStyle.Regular, GraphicsUnit.Point);
            Cell_2_1.Location = new Point(117, 211);
            Cell_2_1.Name = "Cell_2_1";
            Cell_2_1.Size = new Size(80, 80);
            Cell_2_1.TabIndex = 33;
            Cell_2_1.UseVisualStyleBackColor = true;
            Cell_2_1.Click += Cell_2_1_Click;
            // 
            // Cell_1_1
            // 
            Cell_1_1.Font = new Font("Microsoft Sans Serif", 50.25F, FontStyle.Regular, GraphicsUnit.Point);
            Cell_1_1.Location = new Point(117, 111);
            Cell_1_1.Name = "Cell_1_1";
            Cell_1_1.Size = new Size(80, 80);
            Cell_1_1.TabIndex = 32;
            Cell_1_1.UseVisualStyleBackColor = true;
            Cell_1_1.Click += Cell_1_1_Click;
            // 
            // Cell_0_1
            // 
            Cell_0_1.Font = new Font("Microsoft Sans Serif", 50.25F, FontStyle.Regular, GraphicsUnit.Point);
            Cell_0_1.Location = new Point(117, 11);
            Cell_0_1.Name = "Cell_0_1";
            Cell_0_1.Size = new Size(80, 80);
            Cell_0_1.TabIndex = 31;
            Cell_0_1.UseVisualStyleBackColor = true;
            Cell_0_1.Click += Cell_0_1_Click;
            // 
            // Cell_2_0
            // 
            Cell_2_0.Font = new Font("Microsoft Sans Serif", 50.25F, FontStyle.Regular, GraphicsUnit.Point);
            Cell_2_0.Location = new Point(17, 211);
            Cell_2_0.Name = "Cell_2_0";
            Cell_2_0.Size = new Size(80, 80);
            Cell_2_0.TabIndex = 30;
            Cell_2_0.UseVisualStyleBackColor = true;
            Cell_2_0.Click += Cell_2_0_Click;
            // 
            // Cell_1_0
            // 
            Cell_1_0.Font = new Font("Microsoft Sans Serif", 50.25F, FontStyle.Regular, GraphicsUnit.Point);
            Cell_1_0.Location = new Point(17, 111);
            Cell_1_0.Name = "Cell_1_0";
            Cell_1_0.Size = new Size(80, 80);
            Cell_1_0.TabIndex = 29;
            Cell_1_0.UseVisualStyleBackColor = true;
            Cell_1_0.Click += Cell_1_0_Click;
            // 
            // Cell_0_0
            // 
            Cell_0_0.Font = new Font("Microsoft Sans Serif", 50.25F, FontStyle.Regular, GraphicsUnit.Point);
            Cell_0_0.Location = new Point(17, 11);
            Cell_0_0.Name = "Cell_0_0";
            Cell_0_0.Size = new Size(80, 80);
            Cell_0_0.TabIndex = 28;
            Cell_0_0.UseVisualStyleBackColor = true;
            Cell_0_0.Click += Cell_0_0_Click;
            // 
            // TicTacToeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 327);
            Controls.Add(TicTacToePanel);
            Controls.Add(TicTacToeMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = TicTacToeMenu;
            Name = "TicTacToeForm";
            Text = "Tic Tac Toe";
            Load += TicTacToeLoad;
            TicTacToeMenu.ResumeLayout(false);
            TicTacToeMenu.PerformLayout();
            TicTacToePanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip TicTacToeMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem ComputerFirstMenu;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private Panel TicTacToePanel;
        private Button Cell_2_2;
        private Button Cell_1_2;
        private Button Cell_0_2;
        private Button Cell_2_1;
        private Button Cell_1_1;
        private Button Cell_0_1;
        private Button Cell_2_0;
        private Button Cell_1_0;
        private Button Cell_0_0;
    }
}