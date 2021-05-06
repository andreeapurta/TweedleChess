using Chess;
using System.Collections.Generic;
using System.Linq;

namespace Sah.Pieces
{
    internal sealed class Bishop : Piece
    {
        public Bishop(ColorEnum color, List<string> moves, IGameContext gameContext, Coordinate coordinate) : base(color, moves, gameContext, coordinate)
        {
            Value = 3;
        }

        public override List<Coordinate> GetNextLegalMoves(Coordinate currentPosition, IGameContext gameContext)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();
            bool canMoveTopLeft = true;
            bool canMoveTopRight = true;
            bool canMoveBottomLeft = true;
            bool canMoveBottomRight = true;

            for (int i = 1; i < 10; i++)
            {
                if (canMoveTopLeft)
                {
                    if ((currentPosition.Column - i >= 0) && (currentPosition.Line - i >= 0))
                    {
                        if (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column - i, currentPosition.Line - i)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column - i, currentPosition.Line - i));
                        }
                        else if (gameContext.CurrentLayout[new Coordinate(currentPosition.Column - i, currentPosition.Line - i)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column - i, currentPosition.Line - i));
                            canMoveTopLeft = false;
                        }
                        else
                        {
                            canMoveTopLeft = false;
                        }
                    }
                    else
                    {
                        canMoveTopLeft = false;
                    }
                }

                if (canMoveTopRight)
                {
                    if ((currentPosition.Column + i < 10) && (currentPosition.Line - i >= 0))
                    {
                        if (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column + i, currentPosition.Line - i)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column + i, currentPosition.Line - i));
                        }
                        else if (gameContext.CurrentLayout[new Coordinate(currentPosition.Column + i, currentPosition.Line - i)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column + i, currentPosition.Line - i));
                            canMoveTopRight = false;
                        }
                        else
                        {
                            canMoveTopRight = false;
                        }
                    }
                    else
                    {
                        canMoveTopRight = false;
                    }
                }

                if (canMoveBottomLeft)
                {
                    if ((currentPosition.Column - i >= 0) && (currentPosition.Line + i < 10))
                    {
                        if (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column - i, currentPosition.Line + i)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column - i, currentPosition.Line + i));
                        }
                        else if (gameContext.CurrentLayout[new Coordinate(currentPosition.Column - i, currentPosition.Line + i)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column - i, currentPosition.Line + i));
                            canMoveBottomLeft = false;
                        }
                        else
                        {
                            canMoveBottomLeft = false;
                        }
                    }
                    else
                    {
                        canMoveBottomLeft = false;
                    }
                }

                if (canMoveBottomRight)
                {
                    if ((currentPosition.Column + i < 10) && (currentPosition.Line + i < 10))
                    {
                        if (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column + i, currentPosition.Line + i)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column + i, currentPosition.Line + i));
                        }
                        else if (gameContext.CurrentLayout[new Coordinate(currentPosition.Column + i, currentPosition.Line + i)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column + i, currentPosition.Line + i));
                            canMoveBottomRight = false;
                        }
                        else
                        {
                            canMoveBottomRight = false;
                        }
                    }
                    else
                    {
                        canMoveBottomRight = false;
                    }
                }
            }
            return availableMoves;
        }
    }
}