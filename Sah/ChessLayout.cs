using Chess;
using Chess.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class ChessLayout : Layout
    {
        public ChessLayout()
        {
            pieceFactory = new PieceFactory();
        }

        public override void Initialize()
        {
            for (int i = 0; i < 10; i++)
            {
                Add(new Coordinate(i, 1), pieceFactory.CreatePiece(PieceEnum.Pawn, ColorEnum.Black));
                Add(new Coordinate(i, 8), pieceFactory.CreatePiece(PieceEnum.Pawn, ColorEnum.White));
            }

            Add(new Coordinate(0, 0), pieceFactory.CreatePiece(PieceEnum.Rook, ColorEnum.Black));
            Add(new Coordinate(9, 0), pieceFactory.CreatePiece(PieceEnum.Rook, ColorEnum.Black));
            Add(new Coordinate(0, 9), pieceFactory.CreatePiece(PieceEnum.Rook, ColorEnum.White));
            Add(new Coordinate(9, 9), pieceFactory.CreatePiece(PieceEnum.Rook, ColorEnum.White));

            Add(new Coordinate(1, 0), pieceFactory.CreatePiece(PieceEnum.Knight, ColorEnum.Black));
            Add(new Coordinate(8, 0), pieceFactory.CreatePiece(PieceEnum.Knight, ColorEnum.Black));
            Add(new Coordinate(1, 9), pieceFactory.CreatePiece(PieceEnum.Knight, ColorEnum.White));
            Add(new Coordinate(8, 9), pieceFactory.CreatePiece(PieceEnum.Knight, ColorEnum.White));

            Add(new Coordinate(2, 0), pieceFactory.CreatePiece(PieceEnum.Bishop, ColorEnum.Black));
            Add(new Coordinate(7, 0), pieceFactory.CreatePiece(PieceEnum.Bishop, ColorEnum.Black));
            Add(new Coordinate(2, 9), pieceFactory.CreatePiece(PieceEnum.Bishop, ColorEnum.White));
            Add(new Coordinate(7, 9), pieceFactory.CreatePiece(PieceEnum.Bishop, ColorEnum.White));

            Add(new Coordinate(3, 0), pieceFactory.CreatePiece(PieceEnum.LeftQueen, ColorEnum.Black));
            Add(new Coordinate(3, 9), pieceFactory.CreatePiece(PieceEnum.LeftQueen, ColorEnum.White));

            Add(new Coordinate(4, 0), pieceFactory.CreatePiece(PieceEnum.LeftKing, ColorEnum.Black));
            Add(new Coordinate(4, 9), pieceFactory.CreatePiece(PieceEnum.LeftKing, ColorEnum.White));

            Add(new Coordinate(6, 0), pieceFactory.CreatePiece(PieceEnum.RightKing, ColorEnum.Black));
            Add(new Coordinate(6, 9), pieceFactory.CreatePiece(PieceEnum.RightKing, ColorEnum.White));

            Add(new Coordinate(5, 0), pieceFactory.CreatePiece(PieceEnum.RightQueen, ColorEnum.Black));
            Add(new Coordinate(5, 9), pieceFactory.CreatePiece(PieceEnum.RightQueen, ColorEnum.White));
        }

        public override void Update(Move move)
        {
            Piece piece = pieceFactory.CreatePiece(this[move.StartPosition].Type, this[move.StartPosition].Color);
            Remove(move.StartPosition);

            if (ContainsKey(move.EndPosition))
            {
                Remove(move.EndPosition);
            }

            Add(move.EndPosition, piece);
        }
    }
}