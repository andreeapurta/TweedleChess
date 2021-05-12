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

        public Board Setup()
        {
            layout = new ChessLayout();
            context = new Context(layout);
            board = new Board(context);
            return board;
        }

        public void Initialize(Form gameForm)
        {
            ChessLayout chessLayout = new ChessLayout();
            chessLayout.Initialize();
            pieceFactory = new PieceFactory();
            board.Initialize(gameForm.ClientSize.Height - gameForm.MainMenuStrip.Height, pieceFactory, new Brush[2] { Brushes.SandyBrown, Brushes.SaddleBrown });

            gameForm.Controls.Add(board);
            board.Invalidate();
        }

        internal void Resize(int chessWidth, int chessHeight)
        {
            board.Resize(chessWidth, chessHeight);
        }

        public void Start()
        {
        }
    }
}