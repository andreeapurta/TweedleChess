using System.Collections.Generic;

namespace Chess
{
    public abstract class Layout : Dictionary<Coordinate, Piece>
    {
        public PieceFactory pieceFactory;

        public abstract void Initialize();

        public abstract void Update(Move move);

        public abstract Layout Clone();
        public abstract void Promote(Coordinate coordinate, ColorEnum color);
    }
}