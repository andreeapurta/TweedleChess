using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class Board : Panel
    {
       
        private int CellSize { get; set; }

        public Board() : base()
        {
         
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
        }

        public void Resize(int availableWidth, int availableHeight)
        {
            int x, y;
            int newBoardSize;
            availableHeight = availableHeight - 25 - 40;
            availableWidth = availableWidth - 5  ;
            newBoardSize = Math.Min(availableHeight, availableWidth);
            x = (availableWidth - newBoardSize) / 2;
            y = (availableHeight - newBoardSize) / 2 + 25;
            SetBounds(x, y, newBoardSize, newBoardSize);
            CellSize = Math.Min(availableWidth, availableHeight) / 8; //dimensiunea unei patratele minime
        }

        private void DrawBoard(Graphics g)
        {
            for (int column = 0; column < 8; column++)
            {
                for (int line = 0; line < 8; line++)
                {
                    g.FillRectangle((line + column) % 2 == 1 ? Brushes.SaddleBrown : Brushes.White, CellSize * line, CellSize * column, CellSize, CellSize);
                }
            }
        }

        private void DrawPieces(Graphics g)
        {

        }


    }
}
