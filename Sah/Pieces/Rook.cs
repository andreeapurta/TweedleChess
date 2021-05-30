using System.Collections.Generic;
using System.Linq;

namespace Chess.Pieces
{
    internal sealed class Rook : Piece
    {
        public Rook(ColorEnum color, PieceEnum type) : base(color, type)
        {
            Value = 5;
        }

        public override List<Coordinate> GetNextLegalMoves(Coordinate currentPosition, Context gameContext)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();
            bool canMoveUp = true;
            bool canMoveDown = true;
            bool canMoveLeft = true;
            bool canMoveRight = true;

            for (int i = 1; i < 10; i++)
            {
                if (canMoveUp)
                {
                    if (currentPosition.Y - i >= 0)
                    {
                        if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X, currentPosition.Y - i)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X, currentPosition.Y - i));
                        }
                        else if (gameContext.Layout[new Coordinate(currentPosition.X, currentPosition.Y - i)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X, currentPosition.Y - i));
                            canMoveUp = false;
                        }
                        else
                        {
                            canMoveUp = false;
                        }
                    }
                    else
                    {
                        canMoveUp = false;
                    }
                }

                if (canMoveDown)
                {
                    if (currentPosition.Y + i < 10)
                    {
                        if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X, currentPosition.Y + i)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X, currentPosition.Y + i));
                        }
                        else if (gameContext.Layout[new Coordinate(currentPosition.X, currentPosition.Y + i)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X, currentPosition.Y + i));
                            canMoveDown = false;
                        }
                        else
                        {
                            canMoveDown = false;
                        }
                    }
                    else
                    {
                        canMoveDown = false;
                    }
                }

                if (canMoveLeft)
                {
                    if (currentPosition.X - i >= 0)
                    {
                        if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - i, currentPosition.Y)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X - i, currentPosition.Y));
                        }
                        else if (gameContext.Layout[new Coordinate(currentPosition.X - i, currentPosition.Y)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X - i, currentPosition.Y));
                            canMoveLeft = false;
                        }
                        else
                        {
                            canMoveLeft = false;
                        }
                    }
                    else
                    {
                        canMoveLeft = false;
                    }
                }

                if (canMoveRight)
                {
                    if (currentPosition.X + i < 10)
                    {
                        if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + i, currentPosition.Y)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X + i, currentPosition.Y));
                        }
                        else if (gameContext.Layout[new Coordinate(currentPosition.X + i, currentPosition.Y)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X + i, currentPosition.Y));
                            canMoveRight = false;
                        }
                        else
                        {
                            canMoveRight = false;
                        }
                    }
                    else
                    {
                        canMoveRight = false;
                    }
                }
            }
            return availableMoves;
        }
    }
}