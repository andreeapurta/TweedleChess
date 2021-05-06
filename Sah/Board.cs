using Sah;
using Sah.Pieces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public class Board : Panel
    {
        private const int BoardSize = 10;
        private int CellSize { get; set; }
        public Coordinate[,] Grid { get; set; }

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
            availableWidth = availableWidth - 5;
            newBoardSize = Math.Min(availableHeight, availableWidth);
            x = (availableWidth - newBoardSize) / 2;
            y = (availableHeight - newBoardSize) / 2 + 25;
            SetBounds(x, y, newBoardSize, newBoardSize);
            CellSize = Math.Min(availableWidth, availableHeight) / BoardSize; //dimensiunea unei patratele minime
        }

        private void DrawBoard(Graphics g)
        {
            for (int line = 0; line < BoardSize; line++)
            {
                for (int column = 0; column < BoardSize; column++)
                {
                    g.FillRectangle((line + column) % 2 == 1 ? Brushes.SaddleBrown : Brushes.AntiqueWhite, CellSize * line, CellSize * column, CellSize, CellSize);
                    Grid[line, column] = new Coordinate(line, column);
                }
            }
        }

        public void GetNextLegalMoves(Coordinate currentPosition, Piece piece, IGameContext gameContex)
        {
            //ClearAllThePreviousMoves();
            piece.GetNextLegalMoves(currentPosition, gameContex);
        }

        //public void ClearAllThePreviousMoves()
        //{
        //    for (int line = 0; line < BoardSize; line++)
        //    {
        //        for (int column = 0; column < BoardSize; column++)
        //        {
        //            Grid[line, column].LegalNextMove = false;
        //            Grid[line, column].CurrentlyOcuppied = false;
        //        }
        //    }
        //}

        private void DrawPieces(Graphics g, Piece piece)
        {
        }
    }
}