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

        private void start_AiGameClick(object sender, EventArgs e)
        {
            Board.VsAI = true;
            game.Setup(Board);
            game.Initialize(this);

            Controls.Add(Board);
            Board.Resize(Width, Height);
            game.Start();
            Board.OnReplay += RestartAiGame;
            Board.OnExit += Exit;
        }

        private void start_Click(object sender, EventArgs e)
        {
            Board.VsAI = false;
            game.Setup(Board);
            game.Initialize(this);
            Controls.Add(Board);
            Board.Resize(Width, Height);
            game.Start();
            Board.OnReplay += RestartHumanGame;
            Board.OnExit += Exit;
        }

        public void RestartHumanGame()
        {
            Board.VsAI = false;
            game.Setup(Board);
            game.Initialize(this);
            Controls.Add(Board);
            Board.Resize(Width, Height);
            game.Start();
        }

        public void RestartAiGame()
        {
            Board.VsAI = true;
            game.Setup(Board);
            game.Initialize(this);
            Controls.Add(Board);
            Board.Resize(Width, Height);
            game.Start();
        }

        private void Exit()
        {
            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}