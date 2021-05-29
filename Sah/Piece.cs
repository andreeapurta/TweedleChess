using System;
using System.Collections.Generic;

namespace Chess
{
    public abstract class Piece
    {
        public Piece(ColorEnum color, PieceEnum type)
        {
            Color = color;
            Type = type;
        }

        public ColorEnum Color { get; set; }
        protected List<string> Moves { get; set; }
        public PieceEnum Type { get; set; }
        protected int Value { get; set; }
        public Coordinate Coordinate { get; set; }
        protected Context gameContext;

        public virtual List<Coordinate> GetNextLegalMoves(Coordinate currentPosition, Context gameContex)
        {
            throw new NotImplementedException();
        }

        public int GetValue()
        {
            return Value;
        }

        public ColorEnum GetColor()
        {
            return Color;
        }
    }
}