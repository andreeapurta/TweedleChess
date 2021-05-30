using System.Collections.Generic;
using System.Linq;

namespace Chess.Pieces
{
    internal sealed class Knight : Piece
    {
        public Knight(ColorEnum color, PieceEnum type) : base(color, type)
        {
            Value = 3;
        }

        public override List<Coordinate> GetNextLegalMoves(Coordinate currentPosition, Context gameContext)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();
            if ((currentPosition.X + 1 < 10) && (currentPosition.Y - 2 >= 0))
            {
                if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + 1, currentPosition.Y - 2)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X + 1, currentPosition.Y - 2));
                }
                else if (gameContext.Layout[new Coordinate(currentPosition.X + 1, currentPosition.Y - 2)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.X + 1, currentPosition.Y - 2));
                }
            }
            if ((currentPosition.X + 2 < 10) && (currentPosition.Y - 1 >= 0))
            {
                if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + 2, currentPosition.Y - 1)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X + 2, currentPosition.Y - 1));
                }
                else if (gameContext.Layout[new Coordinate(currentPosition.X + 2, currentPosition.Y - 1)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.X + 2, currentPosition.Y - 1));
                }
            }
            if ((currentPosition.X + 2 < 10) && (currentPosition.Y + 1 < 10))
            {
                if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + 2, currentPosition.Y + 1)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X + 2, currentPosition.Y + 1));
                }
                else if (gameContext.Layout[new Coordinate(currentPosition.X + 2, currentPosition.Y + 1)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.X + 2, currentPosition.Y + 1));
                }
            }
            if ((currentPosition.X + 1 < 10) && (currentPosition.Y + 2 < 10))
            {
                if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + 1, currentPosition.Y + 2)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X + 1, currentPosition.Y + 2));
                }
                else if (gameContext.Layout[new Coordinate(currentPosition.X + 1, currentPosition.Y + 2)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.X + 1, currentPosition.Y + 2));
                }
            }
            if ((currentPosition.X - 1 >= 0) && (currentPosition.Y + 2 < 10))
            {
                if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - 1, currentPosition.Y + 2)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X - 1, currentPosition.Y + 2));
                }
                else if (gameContext.Layout[new Coordinate(currentPosition.X - 1, currentPosition.Y + 2)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.X - 1, currentPosition.Y + 2));
                }
            }
            if ((currentPosition.X - 2 >= 0) && (currentPosition.Y + 1 < 10))
            {
                if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - 2, currentPosition.Y + 1)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X - 2, currentPosition.Y + 1));
                }
                else if (gameContext.Layout[new Coordinate(currentPosition.X - 2, currentPosition.Y + 1)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.X - 2, currentPosition.Y + 1));
                }
            }
            if ((currentPosition.X - 2 >= 0) && (currentPosition.Y - 1 >= 0))
            {
                if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - 2, currentPosition.Y - 1)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X - 2, currentPosition.Y - 1));
                }
                else if (gameContext.Layout[new Coordinate(currentPosition.X - 2, currentPosition.Y - 1)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.X - 2, currentPosition.Y - 1));
                }
            }
            if ((currentPosition.X - 1 >= 0) && (currentPosition.Y - 2 >= 0))
            {
                if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - 1, currentPosition.Y - 2)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X - 1, currentPosition.Y - 2));
                }
                else if (gameContext.Layout[new Coordinate(currentPosition.X - 1, currentPosition.Y - 2)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.X - 1, currentPosition.Y - 2));
                }
            }
            return availableMoves;
        }
    }
}