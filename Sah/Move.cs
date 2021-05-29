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

        public Move(Coordinate StartPosition, Coordinate EndPosition, Piece piece)
        {
            this.StartPosition = StartPosition;
            this.EndPosition = EndPosition;
            this.piece = piece;
        }
    }
}