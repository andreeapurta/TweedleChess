using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessGame
    {
        private Board board;

        public Board Setup()
        {
            board = new Board();
            return board;
        }

        public void Start()
        {
          
        }

        internal void Resize(int chessWidth, int chessHeight)
        {
            board.Resize(chessWidth, chessHeight);
        }
    }
}
