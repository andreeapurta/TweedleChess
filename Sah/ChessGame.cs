using System.Drawing;

namespace Chess
{
    public class ChessGame
    {
        private Board board;
        public Context context;
        private ChessLayout layout;
        private PieceFactory pieceFactory;
        public Initializer referee;

        public void Setup(Board board)
        {
            layout = new ChessLayout();
            pieceFactory = new PieceFactory();
            context = new Context();
            referee = new Initializer();
            this.board = board;
        }

        public void Initialize(GameForm gameForm)
        {
            context.Initialize(layout);
            referee.Initialize(context, pieceFactory);

            board.Initialize(gameForm.ClientSize.Height - gameForm.mainMenu.Height, pieceFactory, context, new Brush[2] { Brushes.SandyBrown, Brushes.SaddleBrown });

            board.Invalidate();
        }

        internal void Resize(int chessWidth, int chessHeight)
        {
            if (board != null)
            {
                board.Resize(chessWidth, chessHeight);
            }
        }

        public void Start()
        {
            referee.StartGame();
        }
    }
}