using System;
using System.Windows.Forms;

namespace Chess
{
    public partial class GameForm : Form
    {
        private ChessGame game;
        public Board Board { get; set; }
        public MenuStrip mainMenu = new MenuStrip();

        public GameForm()
        {
            InitializeComponent();
            Board = new Board();
            game = new ChessGame();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            CreateMainMenu();
        }

        private void CreateMainMenu()
        {
            ToolStripMenuItem mainMenuItem = new ToolStripMenuItem("Menu");
            mainMenuItem.DropDownItems.Add("Play Human vs Human", null, start_Click);
            mainMenuItem.DropDownItems.Add("Play Human vs Computer", null, start_AiGameClick);
            mainMenuItem.DropDownItems.Add("Exit", null, exit_Click);
            mainMenu.Items.Add(mainMenuItem);
            this.Controls.Add(mainMenu);
        }

        private void gameForm_Resize(object sender, System.EventArgs e)
        {
            game.Resize(this.Width, this.Height);
            this.Refresh();
        }

        private void load_Click(object sender, EventArgs e)
        {
        }

        private void start_AiGameClick(object sender, EventArgs e)
        {
            game.Setup(Board);
            game.Initialize(this);
            game.context.VsAI = true;
            Controls.Add(Board);
            Board.Resize(Width, Height);
            game.Start();
        }

        private void start_Click(object sender, EventArgs e)
        {
            game.Setup(Board);
            game.Initialize(this);
            game.context.VsAI = false;
            Controls.Add(Board);
            Board.Resize(Width, Height);
            game.Start();
            //if (Board.gameOver == true)
            //{
            //    MessageBox.Show(Board.winner.ToString() + " won!");
            //    DialogResult res = MessageBox.Show(Board.winner.ToString() + " won! Do you want to play again?! ", "Game over", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    if (res == DialogResult.Yes)
            //    {
            //        GameForm gameForm = new GameForm();
            //    }
            //    if (res == DialogResult.No)
            //    {
            //        this.Close();
            //    }
            //}
        }

        private void save_Click(object sender, EventArgs e)
        {
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}