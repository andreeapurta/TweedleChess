using Chess;

namespace Chess
{
    public class Move
    {
        public Coordinate StartPosition { get; set; }
        public Coordinate EndPosition { get; set; }
        public Piece piece { get; set; }

        public Move()
        {
        }
    }
}