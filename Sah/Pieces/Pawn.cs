using System.Collections.Generic;
using System.Linq;

namespace Chess.Pieces
{
    internal sealed class Pawn : Piece
    {
        public Pawn(ColorEnum color, PieceEnum type) : base(color, type)
        {
            Value = 1;
        }

        public override List<Coordinate> GetNextLegalMoves(Coordinate currentPosition, Context gameContext)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();
            if (Color == ColorEnum.White)
            {
                if ((currentPosition.Y - 1 >= 0) && !gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X, currentPosition.Y - 1)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X, currentPosition.Y - 1));
                    if ((currentPosition.Y - 2 >= 0) && !gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X, currentPosition.Y - 2)))
                    {
                        availableMoves.Add(new Coordinate(currentPosition.X, currentPosition.Y - 2));
                    }
                }
                if ((currentPosition.X - 1 >= 0 && currentPosition.Y - 1 >= 0) && gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - 1, currentPosition.Y - 1)) && (gameContext.Layout[new Coordinate(currentPosition.X - 1, currentPosition.Y - 1)].Color != this.Color)) //to kill
                {
                    availableMoves.Add(new Coordinate(currentPosition.X - 1, currentPosition.Y - 1));
                }
                if ((currentPosition.X + 1 < 10 && currentPosition.Y - 1 >= 0) && gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + 1, currentPosition.Y - 1)) && (gameContext.Layout[new Coordinate(currentPosition.X + 1, currentPosition.Y - 1)].Color != this.Color))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X + 1, currentPosition.Y - 1));
                }
            }
            else
            {
                if ((currentPosition.Y + 1 < 10) && !gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X, currentPosition.Y + 1)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X, currentPosition.Y + 1));
                    if ((currentPosition.Y + 2 < 10) && !gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X, currentPosition.Y + 2)))
                    {
                        availableMoves.Add(new Coordinate(currentPosition.X, currentPosition.Y + 2));
                    }
                }
                if ((currentPosition.X - 1 >= 0 && currentPosition.Y + 1 < 10) && gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - 1, currentPosition.Y + 1)) && (gameContext.Layout[new Coordinate(currentPosition.X - 1, currentPosition.Y + 1)].Color != this.Color))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X - 1, currentPosition.Y + 1));
                }
                if ((currentPosition.X + 1 < 10 && currentPosition.Y + 1 < 10) && gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + 1, currentPosition.Y + 1)) && (gameContext.Layout[new Coordinate(currentPosition.X + 1, currentPosition.Y + 1)].Color != this.Color))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X + 1, currentPosition.Y + 1));
                }
            }

            return availableMoves;
        }
    }
}