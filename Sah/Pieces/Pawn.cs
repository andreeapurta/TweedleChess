using Chess;
using System.Collections.Generic;
using System.Linq;

namespace Sah.Pieces
{
    internal sealed class Pawn : Piece
    {
        public Pawn(ColorEnum color, List<string> moves, IGameContext gameContext, Coordinate coordinate) : base(color, moves, gameContext, coordinate)
        {
            Value = 1;
        }

        public override List<Coordinate> GetNextLegalMoves(Coordinate currentPosition, IGameContext gameContext)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();
            if (Color == ColorEnum.White)
            {
                if ((currentPosition.Line - 1 >= 0) && !gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column, currentPosition.Line - 1)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column, currentPosition.Line - 1));
                    if ((currentPosition.Column == 8) && (currentPosition.Line - 2 >= 0) && !gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column, currentPosition.Line - 2)))
                    {
                        availableMoves.Add(new Coordinate(currentPosition.Column, currentPosition.Line - 2));
                    }
                }
                if ((currentPosition.Column - 1 >= 0 && currentPosition.Line - 1 >= 0) && gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column - 1, currentPosition.Line - 1)) && (gameContext.CurrentLayout[new Coordinate(currentPosition.Column - 1, currentPosition.Line - 1)].Color != this.Color)) //to kill
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column - 1, currentPosition.Line - 1));
                }
                if ((currentPosition.Column + 1 < 10 && currentPosition.Line - 1 >= 0) && gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column + 1, currentPosition.Line - 1)) && (gameContext.CurrentLayout[new Coordinate(currentPosition.Column + 1, currentPosition.Line - 1)].Color != this.Color))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column + 1, currentPosition.Line - 1));
                }
            }
            else
            {
                if ((currentPosition.Line + 1 < 10) && !gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column, currentPosition.Line + 1)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column, currentPosition.Line + 1));
                    if ((currentPosition.Line == 1) && (currentPosition.Line + 2 < 10) && !gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column, currentPosition.Line + 2)))
                    {
                        availableMoves.Add(new Coordinate(currentPosition.Column, currentPosition.Line + 2));
                    }
                }
                if ((currentPosition.Column - 1 >= 0 && currentPosition.Line + 1 < 10) && gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column - 1, currentPosition.Line + 1)) && (gameContext.CurrentLayout[new Coordinate(currentPosition.Column - 1, currentPosition.Line + 1)].Color != this.Color))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column - 1, currentPosition.Line + 1));
                }
                if ((currentPosition.Column + 1 < 10 && currentPosition.Line + 1 < 10) && gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column + 1, currentPosition.Line + 1)) && (gameContext.CurrentLayout[new Coordinate(currentPosition.Column + 1, currentPosition.Line + 1)].Color != this.Color))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column + 1, currentPosition.Line + 1));
                }
            }
            return availableMoves;
        }
    }
}