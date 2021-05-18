using Chess;
using Chess.Events;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Chess
{
    public class Referee
    {
        private Context Context { get; set; }

        public event EventHandler<ContexChangeEventArgs> ContextChange;

        private PieceFactory PieceFactory { get; set; }

        public void Initialize(Context context, PieceFactory pieceFactory)
        {
            Context = context;

            PieceFactory = pieceFactory;
        }

        public Referee()
        {
        }

        public void EvaluateMove(object sender, MoveProposeEventArgs e)
        {
            try
            {
                Piece piece;
                if (Context.Layout.ContainsKey(e.Move.StartPosition))
                {
                    piece = PieceFactory.CreatePiece(Context.Layout[e.Move.StartPosition].Type, Context.Layout[e.Move.StartPosition].Color);
                }
                else
                {
                    piece = PieceFactory.CreatePiece(PieceEnum.None, Context.CurrentPlayer);
                }

                List<Coordinate> availableMoves = piece.GetNextLegalMoves(e.Move.StartPosition, Context);

                if (availableMoves.Contains(e.Move.EndPosition))
                {
                    Context.Update(e.Move);
                    Context.ToggleCurrentPlayer();
                    Context.Moves.Add(new Move() { StartPosition = e.Move.StartPosition, EndPosition = e.Move.EndPosition });

                    ContexChangeEventArgs args = new ContexChangeEventArgs() { Contex = Context.Clone() };
                    ContextChange?.Invoke(this, args);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while evaluating a move.",
                   "Evaluate Move Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        public Context ContextClone()
        {
            return Context.Clone();
        }

        public void ChangeContext(Context newContext)
        {
            Context = newContext;
            ContexChangeEventArgs args = new ContexChangeEventArgs() { Contex = Context.Clone() };
            ContextChange?.Invoke(this, args);
        }

        public void StartGame()
        {
            Context.Layout.Clear();
            Context.InitializeStartingBoard();
            ContexChangeEventArgs args = new ContexChangeEventArgs() { Contex = Context.Clone() };
            ContextChange?.Invoke(this, args);
        }

        public void Dispose()
        {
            Context = null;
        }
    }
}