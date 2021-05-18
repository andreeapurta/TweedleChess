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

        public Board()
        {
        }

        public void Initialize(int Size, PieceFactory pieceFactory, Context context, Brush[] brushes)
        {
            Context = context;
            PieceFactory = pieceFactory;
            BoardBrushes = brushes;
            Width = Size;
            Height = Size;
            DoubleBuffered = true;
            CurrentMove = new Move();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            MouseOverCoordinate = new Coordinate(e.X / CellSize, e.Y / CellSize);

            if (MouseOverCoordinate != null)
            {
                Console.WriteLine(Context.Layout[MouseOverCoordinate].Type);
                DrawAvailableMoves(MouseOverCoordinate);
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
                    //Context.Layout.Update(CurrentMove, );
                    //schimbi randul lui
                    this.Refresh();
                }
                Cursor = Cursors.Default;
            }
        }

        private void DrawAvailableMoves(Coordinate oldMouseCoordinate)
        {
            Graphics g = CreateGraphics();
            this.Refresh();
            if (Context.Layout.ContainsKey(oldMouseCoordinate))
            {
                Piece piece = Context.Layout[oldMouseCoordinate];
                List<Coordinate> availableMoves = piece.GetNextLegalMoves(oldMouseCoordinate, Context);
                foreach (Coordinate coordinate in availableMoves)
                {
                    g.DrawRectangle(new Pen(Color.Purple, 3), coordinate.Y * CellSize, coordinate.X * CellSize, CellSize, CellSize);
                }
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
            for (int Y = 0; Y < BoardSize; Y++)
            {
                for (int X = 0; X < BoardSize; X++)
                {
                    g.FillRectangle((Y + X) % 2 == 1 ? Brushes.SaddleBrown : Brushes.AntiqueWhite, CellSize * Y, CellSize * X, CellSize, CellSize);
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
                g.DrawImage(getImage, coord.Y * CellSize, coord.X * CellSize, CellSize, CellSize);
            }
        }
    }
}