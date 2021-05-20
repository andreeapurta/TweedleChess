using Chess;
using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chess.Pieces
{
    internal sealed class King : Piece
    {
        public bool HasMoved = false;

        public King(ColorEnum color, PieceEnum type) : base(color, type)
        {
            Value = 999;
        }

        public override List<Coordinate> GetNextLegalMoves(Coordinate currentPosition, Context gameContext)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            //rocada

            if (this.Color == ColorEnum.White)
            {
                if (!currentPosition.Equals(new Coordinate(3, 9)) || !currentPosition.Equals(new Coordinate(5, 9)))
                {
                    HasMoved = true;
                }
            }
            else
            {
                if (!currentPosition.Equals(new Coordinate(3, 0)) || !currentPosition.Equals(new Coordinate(5, 0)))
                {
                    HasMoved = true;
                }
            }

            //jos
            if ((!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X, currentPosition.Y + 1))) || (currentPosition.Y + 1 < 10) && ((gameContext.Layout[new Coordinate(currentPosition.X, currentPosition.Y + 1)].Color != this.Color)))
            {
                availableMoves.Add(new Coordinate(currentPosition.X, currentPosition.Y + 1));
            }

            //sus
            if ((!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X, currentPosition.Y - 1))) || (currentPosition.Y - 1 >= 0) && ((gameContext.Layout[new Coordinate(currentPosition.X, currentPosition.Y - 1)].Color != this.Color)))
            {
                availableMoves.Add(new Coordinate(currentPosition.X, currentPosition.Y - 1));
            }

            //dreapta
            if ((!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + 1, currentPosition.Y))) || (currentPosition.X + 1 < 10) && ((gameContext.Layout[new Coordinate(currentPosition.X + 1, currentPosition.Y)].Color != this.Color)))
            {
                availableMoves.Add(new Coordinate(currentPosition.X + 1, currentPosition.Y));
            }

            //stanga
            if ((!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - 1, currentPosition.Y))) || (currentPosition.X - 1 >= 0) && ((gameContext.Layout[new Coordinate(currentPosition.X - 1, currentPosition.Y)].Color != this.Color)))
            {
                availableMoves.Add(new Coordinate(currentPosition.X - 1, currentPosition.Y));
            }

            //diagonala-stanga-sus
            if ((!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - 1, currentPosition.Y - 1))) || (currentPosition.X - 1 >= 0) && (currentPosition.Y - 1 >= 0) && ((gameContext.Layout[new Coordinate(currentPosition.X - 1, currentPosition.Y - 1)].Color != this.Color)))
            {
                availableMoves.Add(new Coordinate(currentPosition.X - 1, currentPosition.Y - 1));
            }

            //diagonala-dreapta-sus
            if ((!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + 1, currentPosition.Y - 1))) || (currentPosition.X + 1 < 10) && (currentPosition.Y - 1 >= 0) && ((gameContext.Layout[new Coordinate(currentPosition.X + 1, currentPosition.Y - 1)].Color != this.Color)))
            {
                availableMoves.Add(new Coordinate(currentPosition.X + 1, currentPosition.Y - 1));
            }

            //diagonala-dreapta-jos
            if ((!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + 1, currentPosition.Y + 1))) || (currentPosition.X + 1 < 10) && (currentPosition.Y + 1 < 10) && ((gameContext.Layout[new Coordinate(currentPosition.X + 1, currentPosition.Y + 1)].Color != this.Color)))
            {
                availableMoves.Add(new Coordinate(currentPosition.X + 1, currentPosition.Y + 1));
            }

            //diagonala-stanga-jos
            if ((!gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - 1, currentPosition.Y + 1))) || (currentPosition.X - 1 >= 0) && (currentPosition.Y + 1 < 10) && ((gameContext.Layout[new Coordinate(currentPosition.X - 1, currentPosition.Y + 1)].Color != this.Color)))
            {
                availableMoves.Add(new Coordinate(currentPosition.X - 1, currentPosition.Y + 1));
            }

            if (!HasMoved)
            {
                if ((currentPosition.X - 2 >= 0) && !gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X - 2, currentPosition.Y)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X - 2, currentPosition.Y));
                }

                if ((currentPosition.X + 2 < 10) && !gameContext.Layout.Keys.Contains(new Coordinate(currentPosition.X + 2, currentPosition.Y)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.X + 2, currentPosition.Y));
                }
            }

            return availableMoves;
        }
    }
}