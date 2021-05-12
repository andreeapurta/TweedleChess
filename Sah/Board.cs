using Chess.Events;
using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public class Board : Panel
    {
        private const int BoardSize = 10;
        private int CellSize { get; set; }
        public Coordinate[,] Grid { get; set; }
        private Context Context { get; set; }
        private Move CurrentMove { get; set; }
        private PieceFactory PieceFactory { get; set; }
        private Brush[] BoardBrushes { get; set; }
        private Coordinate MouseOverCoordinate { get; set; }

        public event EventHandler<MoveProposeEventArgs> ProposeMove;

        public Board(Context context)
        {
            Context = context;
        }

        public void Initialize(int Size, PieceFactory pieceFactory, Brush[] brushes)
        {
            PieceFactory = pieceFactory;
            BoardBrushes = brushes;
            Width = Size;
            Height = Size;

            DoubleBuffered = true;

            MouseMove += new MouseEventHandler(this.Board_MouseMove);
            MouseDown += new MouseEventHandler(this.Board_MouseDown);
            MouseUp += new MouseEventHandler(this.Board_MouseUp);
            CurrentMove = new Move();
        }

        private Coordinate TranslateMouseCoordinate(int x, int y)
        {
            int newX, newY;

            newX = x / CellSize;
            newY = y / CellSize;

            if (newX < 0)
            {
                newX = 0;
            }

            if (newX > 9)
            {
                newX = 9;
            }

            if (newY < 0)
            {
                newY = 0;
            }

            if (newY > 9)
            {
                newY = 9;
            }

            return new Coordinate(newX, newY);
        }

        private void Board_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Coordinate newMouseCoordinate = TranslateMouseCoordinate(e.X, e.Y);

                if (MouseOverCoordinate == null || !MouseOverCoordinate.Equals(newMouseCoordinate))
                {
                    Coordinate oldMouseCoordinate = MouseOverCoordinate;
                    MouseOverCoordinate = newMouseCoordinate;
                    DrawAvailableMoves(oldMouseCoordinate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("An error occurred while moving the mouse.",
                   "Mouse move Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void Board_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentMove.StartPosition = MouseOverCoordinate;
                if (Context.Layout.ContainsKey(MouseOverCoordinate))
                {
                    Cursor = new Cursor(Context.Layout[MouseOverCoordinate].GetImage().GetHicon());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while moving down the mouse.",
                   "Mouse move Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void Board_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentMove.EndPosition = MouseOverCoordinate;
                MoveProposeEventArgs args = new MoveProposeEventArgs() { Move = CurrentMove };
                ProposeMove?.Invoke(this, args);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while moving up the mouse.",
                    "Mouse move Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DrawAvailableMoves(Coordinate oldMouseCoordinate)
        {
            if (MouseOverCoordinate == null || oldMouseCoordinate == null)
            {
                return;
            }

            Graphics g = CreateGraphics();
            Piece piece;
            if (Context.Layout.ContainsKey(oldMouseCoordinate))
            {
                piece = PieceFactory.CreatePiece(Context.Layout[oldMouseCoordinate].Type, Context.Layout[oldMouseCoordinate].Color);
            }
            else
            {
                piece = PieceFactory.CreatePiece(PieceEnum.None, Context.CurrentPlayer);
            }

            List<Coordinate> oldAvailableMoves = piece.GetNextLegalMoves(oldMouseCoordinate, Context);
            foreach (Coordinate coordinate in oldAvailableMoves)
            {
                g.DrawRectangle((coordinate.Column + coordinate.Line) % 2 == 0 ? new Pen(BoardBrushes[0]) : new Pen(BoardBrushes[1]), coordinate.Column * CellSize, coordinate.Line * CellSize, CellSize, CellSize);
                g.DrawRectangle(Pens.Black, coordinate.Column * CellSize, coordinate.Line * CellSize, CellSize, CellSize);
            }

            if (Context.Layout.ContainsKey(MouseOverCoordinate))
            {
                piece = PieceFactory.CreatePiece(Context.Layout[MouseOverCoordinate].Type, Context.Layout[MouseOverCoordinate].Color);
            }
            else
            {
                piece = PieceFactory.CreatePiece(PieceEnum.None, Context.CurrentPlayer);
            }

            List<Coordinate> availableMoves = piece.GetNextLegalMoves(MouseOverCoordinate, Context);
            foreach (Coordinate coordinate in availableMoves)
            {
                g.DrawRectangle(Pens.Yellow, coordinate.Column * CellSize, coordinate.Line * CellSize, CellSize, CellSize);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //try
            //{
            DrawBoard(e.Graphics);
            DrawPieces(e.Graphics);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    MessageBox.Show("An error occurred while drawing the board.",
            //       "Board Draw Error",
            //       MessageBoxButtons.OK,
            //       MessageBoxIcon.Error);
            //}
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
                }
            }
        }

        public void LayoutChanged(object sender, ContexChangeEventArgs e)
        {
            Context = e.Contex;
            Invalidate();
        }

        private void DrawPieces(Graphics g)
        {
            foreach (Coordinate coord in Context.Layout.Keys)
            {
                var getImage = ChessPieceImage.GetInstance(Context.Layout[coord].Type, Context.Layout[coord].Color);
                g.DrawImage(getImage, coord.Column * CellSize, coord.Line * CellSize, CellSize, CellSize);
            }
        }
    }
}