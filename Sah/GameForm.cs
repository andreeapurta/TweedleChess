using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            mainMenuItem.DropDownItems.Add("Start", null, start_Click);
            mainMenuItem.DropDownItems.Add("Load", null, load_Click);
            mainMenuItem.DropDownItems.Add("Save", null, save_Click);
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

        private void start_Click(object sender, EventArgs e)
        {
            game.Setup(Board);
            game.Initialize(this);
            Controls.Add(Board);
            Board.Resize(Width, Height);
            game.Start();
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