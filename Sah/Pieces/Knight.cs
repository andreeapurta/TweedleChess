using Chess;
using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chess.Pieces
{
    internal sealed class Knight : Piece
    {
        public Knight(ColorEnum color, PieceEnum type) : base(color, type)
        {
        }

        public Knight(ColorEnum color, List<string> moves, IGameContext gameContext, Coordinate coordinate) : base(color, moves, gameContext, coordinate)
        {
            Value = 3;
        }

        public override Bitmap GetImage()
        {
            throw new NotImplementedException();
        }

        public override List<Coordinate> GetNextLegalMoves(Coordinate currentPosition, IGameContext gameContext)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();
            if ((currentPosition.Column + 1 < 10) && (currentPosition.Line - 2 >= 0))
            {
                if (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column + 1, currentPosition.Line - 2)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column + 1, currentPosition.Line - 2));
                }
                else if (gameContext.CurrentLayout[new Coordinate(currentPosition.Column + 1, currentPosition.Line - 2)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column + 1, currentPosition.Line - 2));
                }
            }
            if ((currentPosition.Column + 2 < 10) && (currentPosition.Line - 1 >= 0))
            {
                if (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column + 2, currentPosition.Line - 1)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column + 2, currentPosition.Line - 1));
                }
                else if (gameContext.CurrentLayout[new Coordinate(currentPosition.Column + 2, currentPosition.Line - 1)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column + 2, currentPosition.Line - 1));
                }
            }
            if ((currentPosition.Column + 2 < 10) && (currentPosition.Line + 1 < 10))
            {
                if (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column + 2, currentPosition.Line + 1)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column + 2, currentPosition.Line + 1));
                }
                else if (gameContext.CurrentLayout[new Coordinate(currentPosition.Column + 2, currentPosition.Line + 1)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column + 2, currentPosition.Line + 1));
                }
            }
            if ((currentPosition.Column + 1 < 10) && (currentPosition.Line + 2 < 10))
            {
                if (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column + 1, currentPosition.Line + 2)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column + 1, currentPosition.Line + 2));
                }
                else if (gameContext.CurrentLayout[new Coordinate(currentPosition.Column + 1, currentPosition.Line + 2)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column + 1, currentPosition.Line + 2));
                }
            }
            if ((currentPosition.Column - 1 >= 0) && (currentPosition.Line + 2 < 10))
            {
                if (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column - 1, currentPosition.Line + 2)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column - 1, currentPosition.Line + 2));
                }
                else if (gameContext.CurrentLayout[new Coordinate(currentPosition.Column - 1, currentPosition.Line + 2)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column - 1, currentPosition.Line + 2));
                }
            }
            if ((currentPosition.Column - 2 >= 0) && (currentPosition.Line + 1 < 10))
            {
                if (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column - 2, currentPosition.Line + 1)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column - 2, currentPosition.Line + 1));
                }
                else if (gameContext.CurrentLayout[new Coordinate(currentPosition.Column - 2, currentPosition.Line + 1)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column - 2, currentPosition.Line + 1));
                }
            }
            if ((currentPosition.Column - 2 >= 0) && (currentPosition.Line - 1 >= 0))
            {
                if (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column - 2, currentPosition.Line - 1)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column - 2, currentPosition.Line - 1));
                }
                else if (gameContext.CurrentLayout[new Coordinate(currentPosition.Column - 2, currentPosition.Line - 1)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column - 2, currentPosition.Line - 1));
                }
            }
            if ((currentPosition.Column - 1 >= 0) && (currentPosition.Line - 2 >= 0))
            {
                if (!gameContext.CurrentLayout.Keys.Contains(new Coordinate(currentPosition.Column - 1, currentPosition.Line - 2)))
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column - 1, currentPosition.Line - 2));
                }
                else if (gameContext.CurrentLayout[new Coordinate(currentPosition.Column - 1, currentPosition.Line - 2)].Color != this.Color)
                {
                    availableMoves.Add(new Coordinate(currentPosition.Column - 1, currentPosition.Line - 2));
                }
            }
            return availableMoves;
        }
    }
}