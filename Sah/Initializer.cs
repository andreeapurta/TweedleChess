using System;

namespace Chess
{
    public class Initializer
    {
        private Context Context { get; set; }

        private PieceFactory PieceFactory { get; set; }

        public void Initialize(Context context, PieceFactory pieceFactory)
        {
            Context = context;

            PieceFactory = pieceFactory;
        }

        public Initializer()
        {
        }

        public void StartGame()
        {
            Context.Layout.Clear();
            Context.InitializeStartingBoard();
        }
    }
}