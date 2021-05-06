using Chess;
using System.Collections.Generic;

namespace Sah.Pieces
{
    public interface IGameContext
    {
        Dictionary<Coordinate, Piece> CurrentLayout { get; set; }
    }
}