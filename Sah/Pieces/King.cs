using Chess;
using System.Collections.Generic;
using System.Linq;

namespace Sah.Pieces
{
    internal class King : Piece
    {
        public King(ColorEnum color, List<string> moves, IGameContext gameContext, Coordinate coordinate) : base(color, moves, gameContext, coordinate)
        {
            Value = 999;
        }

        public override List<Coordinate> GetNextLegalMoves(Coordinate currentPosition, IGameContext gameContext)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            //sus
            if ((currentPosition.Line + 1 < 10) && ((gameContext.CurrentLayout[new Coordinate(currentPosition.Column, currentPosition.Line + 1)].Color != this.Color) || (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column, currentPosition.Line + 1)))))
            {
                availableMoves.Add(new Coordinate(currentPosition.Column, currentPosition.Line + 1));
            }

            //jos
            if ((currentPosition.Line - 1 >= 0) && ((gameContext.CurrentLayout[new Coordinate(currentPosition.Column, currentPosition.Line - 1)].Color != this.Color) || (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column, currentPosition.Line - 1)))))
            {
                availableMoves.Add(new Coordinate(currentPosition.Column, currentPosition.Line - 1));
            }

            //dreapta
            if ((currentPosition.Column + 1 >= 0) && ((gameContext.CurrentLayout[new Coordinate(currentPosition.Column + 1, currentPosition.Line)].Color != this.Color) || (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column + 1, currentPosition.Line)))))
            {
                availableMoves.Add(new Coordinate(currentPosition.Column + 1, currentPosition.Line));
            }

            //stanga
            if ((currentPosition.Column - 1 >= 0)
                && ((gameContext.CurrentLayout[new Coordinate(currentPosition.Column - 1, currentPosition.Line)].Color != this.Color) || (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column - 1, currentPosition.Line)))))
            {
                availableMoves.Add(new Coordinate(currentPosition.Column - 1, currentPosition.Line));
            }

            //diagonala-stanga-sus
            if ((currentPosition.Column - 1 >= 0) && (currentPosition.Line - 1 >= 0) && ((gameContext.CurrentLayout[new Coordinate(currentPosition.Column - 1, currentPosition.Line - 1)].Color != this.Color) || (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column - 1, currentPosition.Line - 1)))))
            {
                availableMoves.Add(new Coordinate(currentPosition.Column - 1, currentPosition.Line - 1));
            }

            //diagonala-dreapta-sus
            if ((currentPosition.Column + 1 < 10) && (currentPosition.Line - 1 >= 0) && ((gameContext.CurrentLayout[new Coordinate(currentPosition.Column + 1, currentPosition.Line - 1)].Color != this.Color) || (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column + 1, currentPosition.Line - 1)))))
            {
                availableMoves.Add(new Coordinate(currentPosition.Column + 1, currentPosition.Line - 1));
            }

            //diagonala-dreapta-jos
            if ((currentPosition.Column + 1 < 10) && (currentPosition.Line + 1 < 10) && ((gameContext.CurrentLayout[new Coordinate(currentPosition.Column + 1, currentPosition.Line + 1)].Color != this.Color) || (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column + 1, currentPosition.Line + 1)))))
            {
                availableMoves.Add(new Coordinate(currentPosition.Column + 1, currentPosition.Line + 1));
            }

            //diagonala-stanga-jos
            if ((currentPosition.Column - 1 >= 0) && (currentPosition.Line + 1 < 10) && ((gameContext.CurrentLayout[new Coordinate(currentPosition.Column - 1, currentPosition.Line + 1)].Color != this.Color) || (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column - 1, currentPosition.Line + 1)))))
            {
                availableMoves.Add(new Coordinate(currentPosition.Column - 1, currentPosition.Line + 1));
            }

            return availableMoves;
        }
    }
}