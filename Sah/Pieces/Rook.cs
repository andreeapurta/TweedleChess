﻿using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                    if (currentPosition.Line - i >= 0)
                    {
                        if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.Column, currentPosition.Line - i)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column, currentPosition.Line - i));
                        }
                        else if (gameContext.Layout[new Coordinate(currentPosition.Column, currentPosition.Line - i)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column, currentPosition.Line - i));
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
                    if (currentPosition.Line + i < 10)
                    {
                        if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.Column, currentPosition.Line + i)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column, currentPosition.Line + i));
                        }
                        else if (gameContext.Layout[new Coordinate(currentPosition.Column, currentPosition.Line + i)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column, currentPosition.Line + i));
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
                    if (currentPosition.Column - i >= 0)
                    {
                        if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.Column - i, currentPosition.Line)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column - i, currentPosition.Line));
                        }
                        else if (gameContext.Layout[new Coordinate(currentPosition.Column - i, currentPosition.Line)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column - i, currentPosition.Line));
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
                    if (currentPosition.Column + i < 10)
                    {
                        if (!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.Column + i, currentPosition.Line)))
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column + i, currentPosition.Line));
                        }
                        else if (gameContext.Layout[new Coordinate(currentPosition.Column + i, currentPosition.Line)].Color != this.Color)
                        {
                            availableMoves.Add(new Coordinate(currentPosition.Column + i, currentPosition.Line));
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