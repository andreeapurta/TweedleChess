using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chess.Pieces
{
    internal sealed class Bishop : Piece
    {
        public Bishop(ColorEnum color, PieceEnum type) : base(color, type)
        {
            Value = 3;
        }

        public override List<Coordinate> GetNextLegalMoves(Coordinate currentPosition, Context gameContext)
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