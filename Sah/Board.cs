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
        public bool VsAI { get; set; }
        public bool gameOver = false;
        private bool movement = false;

        public delegate void Reply();  // delegate

        public event Reply OnReplay; // event

        public delegate void Exit();  // delegate

        public event Exit OnExit; // event

        public ColorEnum winner { get; set; }

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

            if (MouseOverCoordinate != null && Context.Layout.ContainsKey(MouseOverCoordinate) && (Context.CurrentPlayer == Context.Layout[MouseOverCoordinate].Color))
            {
                if (movement == false)
                {
                    DrawAvailableMoves(MouseOverCoordinate);
                }
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
            movement = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            CurrentMove.EndPosition = MouseOverCoordinate;
            movement = false;

            if (CurrentMove.piece != null)
            {
                if (Context.CurrentPlayer == CurrentMove.piece.Color)
                {
                    var nextMove = CurrentMove.piece.GetNextLegalMoves(CurrentMove.StartPosition, Context);
                    if (CurrentMove.piece.GetNextLegalMoves(CurrentMove.StartPosition, Context).Contains(CurrentMove.EndPosition))
                    {
                        Context.Update(CurrentMove);
                        this.Refresh();
                        if (CurrentMove.piece.Type == PieceEnum.Pawn && (CurrentMove.EndPosition.Y == 0 || CurrentMove.EndPosition.Y == 9))
                        {
                            Context.Layout.Promote(CurrentMove.EndPosition, CurrentMove.piece.Color);
                            this.Refresh();
                        }
                        Cursor = Cursors.Default;
                        if (VsAI)
                        {
                            AI ai = new AI(Context.Clone());
                            Context.Layout.Update(ai.GetNextMove());
                            Context.ToggleCurrentPlayer();
                            this.Refresh();
                        }
                        if (Context.CheckMating())
                        {
                            winner = CurrentMove.piece.Color;
                            DialogResult res = MessageBox.Show(winner.ToString() + " won! Do you want to play again?! ", "Game over", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (res == DialogResult.Yes)
                            {
                                OnReplay?.Invoke();
                            }
                            else
                            {
                                OnExit?.Invoke();
                            }
                        }
                        if (Context.AlertCheck())
                        {
                            MessageBox.Show("Check! Save your king!");
                            Cursor = Cursors.Default;
                        }
                    }
                    Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Not your turn");
                    Cursor = Cursors.Default;
                }
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
                    g.DrawRectangle(new Pen(Color.Purple, 3), coordinate.X * CellSize, coordinate.Y * CellSize, CellSize, CellSize);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
            DrawPieces(e.Graphics);
        }

        public new void Resize(int availableWidth, int availableHeight)
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

        private void DrawPieces(Graphics g)
        {
            foreach (Coordinate coord in Context.Layout.Keys)
            {
                var getImage = ChessPieceImage.GetInstance(Context.Layout[coord].Type, Context.Layout[coord].Color);
                g.DrawImage(getImage, coord.X * CellSize, coord.Y * CellSize, CellSize, CellSize);
            }
        }
    }
}