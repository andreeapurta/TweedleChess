using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sah
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }

  

        private void GameForm_Load(object sender, EventArgs e)
        {
            CreateMainMenu();
           
        }

        private void CreateMainMenu()
        {
            MenuStrip mainMenu = new MenuStrip();
            ToolStripMenuItem mainMenuItem = new ToolStripMenuItem("Menu");
            mainMenuItem.DropDownItems.Add("Start",null, start_Click);
            mainMenuItem.DropDownItems.Add("Resume", null, resume_Click);
            mainMenuItem.DropDownItems.Add("Save", null, save_Click);
            mainMenuItem.DropDownItems.Add("Exit", null, exit_Click);
            mainMenu.Items.Add(mainMenuItem);
            this.Controls.Add(mainMenu);
        }


        private void resume_Click(object sender, EventArgs e)
        {
        
        }

        private void start_Click(object sender, EventArgs e)
        {
            Board board = new Board();
            Controls.Add(board);
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
