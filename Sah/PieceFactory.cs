using Chess.Interfaces;
using Chess.Pieces;
using System;

namespace Chess
{
    public class PieceFactory : IPieceFactory
    {
        public Piece CreatePiece(PieceEnum type, ColorEnum color)
        {
            switch (type)
            {
                case PieceEnum.RightQueen:
                    return new Queen(color, type);

                case PieceEnum.LeftQueen:
                    return new Queen(color, type);

                case PieceEnum.RightKing:
                    return new King(color, type);

                case PieceEnum.LeftKing:
                    return new King(color, type);

                case PieceEnum.Rook:
                    return new Rook(color, type);

                case PieceEnum.Knight:
                    return new Knight(color, type);

                case PieceEnum.Bishop:
                    return new Bishop(color, type);

                case PieceEnum.Pawn:
                    return new Pawn(color, type);

                default:
                    throw new Exception("Unsupported piece type.");
            }
        }
    }
}