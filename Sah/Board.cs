using Chess.Events;
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

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Coordinate newMouseCoordinate = TranslateMouseCoordinate(e.X, e.Y);

            if (MouseOverCoordinate == null || !MouseOverCoordinate.Equals(newMouseCoordinate))
            {
                Coordinate oldMouseCoordinate = MouseOverCoordinate;
                MouseOverCoordinate = newMouseCoordinate;
                DrawAvailableMoves(oldMouseCoordinate, PieceFactory);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            CurrentMove = new Move();

            CurrentMove.StartPosition = MouseOverCoordinate;
            if (Context.Layout.ContainsKey(MouseOverCoordinate))
            {
                CurrentMove.piece = Context.Layout[MouseOverCoordinate];
                Cursor = new Cursor(ChessPieceImage.GetInstance(CurrentMove.piece.Type, CurrentMove.piece.Color).GetHicon());
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            CurrentMove.EndPosition = MouseOverCoordinate;
            //+daca e si randul lui
            if (CurrentMove.piece != null)
            {
                var nectMove = CurrentMove.piece.GetNextLegalMoves(CurrentMove.StartPosition, Context);
                if (CurrentMove.piece.GetNextLegalMoves(CurrentMove.StartPosition, Context).Contains(CurrentMove.EndPosition))
                {
                    Context.Layout.Update(CurrentMove);
                    //schimbi randul lui
                    this.Refresh();
                }
                Cursor = Cursors.Default;
            }
        }

        private void DrawAvailableMoves(Coordinate oldMouseCoordinate, PieceFactory pieceFactory)
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
                g.DrawRectangle(Pens.Purple, coordinate.Column * CellSize, coordinate.Line * CellSize, CellSize, CellSize);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
            DrawPieces(e.Graphics);
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
                g.DrawImage(getImage, coord.Line * CellSize, coord.Column * CellSize, CellSize, CellSize);
            }
        }
    }
}