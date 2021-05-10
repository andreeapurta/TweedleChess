using System.Collections.Generic;

namespace Chess.Interfaces
{
    public interface ILayout : IDictionary<Coordinate, Piece>

    {
        PieceFactory pieceFactory { get; set; }

        void Initialize();

        void Update(Move move, ColorEnum playerColor);
    }
}