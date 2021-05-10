using Chess;
using Chess.Interfaces;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess
{
    public abstract class Piece
    {
        public Piece(ColorEnum color, List<string> moves, IGameContext gameContext, Coordinate coordinate)
        {
            Color = color;
            Moves = moves;
            this.gameContext = gameContext;
            Coordinate = coordinate;
        }

        public Piece(ColorEnum color, PieceEnum type)
        {
            Color = color;
            Type = type;
        }

        protected string Position { get; set; }
        public ColorEnum Color { get; set; }
        protected List<string> Moves { get; set; }
        public PieceEnum Type { get; set; }
        protected int Value { get; set; }
        protected Coordinate Coordinate { get; set; }
        protected IGameContext gameContext;

        public virtual List<Coordinate> GetNextLegalMoves(Coordinate currentPosition, IGameContext gameContex)
        {
            throw new NotImplementedException();
        }

        public virtual Bitmap GetImage()
        {
            throw new NotImplementedException();
        }
    }
}