using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class ChessGame
    {
        private Board board;
        private Context context;
        private ChessLayout layout;
        private PieceFactory pieceFactory;
        public Referee referee;

        public void Setup(Board board)
        {
            layout = new ChessLayout();
            pieceFactory = new PieceFactory();
            context = new Context();
            referee = new Referee();
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
            board.Resize(chessWidth, chessHeight);
        }

        public void Start()
        {
            referee.StartGame();
        }
    }
}