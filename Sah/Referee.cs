using Chess.Events;
using System;

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

        public void StartGame()
        {
            Context.Layout.Clear();
            Context.InitializeStartingBoard();
            ContexChangeEventArgs args = new ContexChangeEventArgs() { Contex = Context.Clone() };
            ContextChange?.Invoke(this, args);
        }
    }
}