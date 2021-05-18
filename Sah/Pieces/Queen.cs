using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chess.Pieces
{
    internal sealed class Queen : Piece
    {
        public Queen(ColorEnum color, PieceEnum type) : base(color, type)
        {
            Value = 9;
        }

        public override List<Coordinate> GetNextLegalMoves(Coordinate currentPosition, Context gameContext)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();
            bool canMoveUp = true;
            bool canMoveDown = true;
            bool canMoveLeft = true;
            bool canMoveRight = true;
            bool canMoveTopLeft = true;
            bool canMoveTopRight = true;
            bool canMoveBottomLeft = true;
            bool canMoveBottomRight = true;

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

                if (canMoveTopLeft)
                {
                    if ((currentPosition.X - i >= 0) && (currentPosition.Y - i >= 0))
                    {
                        if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - i, currentPosition.Y - i)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X - i, currentPosition.Y - i));
                        }
                        else if (gameContext.Layout[new Coordinate(currentPosition.X - i, currentPosition.Y - i)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X - i, currentPosition.Y - i));
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
                    if ((currentPosition.X + i < 10) && (currentPosition.Y - i >= 0))
                    {
                        if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + i, currentPosition.Y - i)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X + i, currentPosition.Y - i));
                        }
                        else if (gameContext.Layout[new Coordinate(currentPosition.X + i, currentPosition.Y - i)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X + i, currentPosition.Y - i));
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
                    if ((currentPosition.X - i >= 0) && (currentPosition.Y + i < 10))
                    {
                        if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - i, currentPosition.Y + i)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X - i, currentPosition.Y + i));
                        }
                        else if (gameContext.Layout[new Coordinate(currentPosition.X - i, currentPosition.Y + i)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X - i, currentPosition.Y + i));
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
                    if ((currentPosition.X + i < 10) && (currentPosition.Y + i < 10))
                    {
                        if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + i, currentPosition.Y + i)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X + i, currentPosition.Y + i));
                        }
                        else if (gameContext.Layout[new Coordinate(currentPosition.X + i, currentPosition.Y + i)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.X + i, currentPosition.Y + i));
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