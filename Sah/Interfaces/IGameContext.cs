using Chess;
using System.Collections.Generic;

namespace Chess.Interfaces
{
    public interface IGameContext
    {
        Dictionary<Coordinate, Piece> CurrentLayout { get; set; }
    }
}