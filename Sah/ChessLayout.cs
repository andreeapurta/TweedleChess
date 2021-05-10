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
    internal class ChessLayout : ILayout
    {
        public ChessLayout()
        {
            pieceFactory = new PieceFactory();
        }

        public Piece this[Coordinate key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PieceFactory pieceFactory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<Coordinate> Keys => throw new NotImplementedException();

        public ICollection<Piece> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(Coordinate key, Piece value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<Coordinate, Piece> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<Coordinate, Piece> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(Coordinate key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<Coordinate, Piece>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Coordinate, Piece>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            for (int i = 0; i < 10; i++)
            {
                Add(new Coordinate(i, 1), pieceFactory.CreatePiece(PieceEnum.Pawn, ColorEnum.Black));
                Add(new Coordinate(i, 6), pieceFactory.CreatePiece(PieceEnum.Pawn, ColorEnum.White));
            }

            Add(new Coordinate(0, 0), pieceFactory.CreatePiece(PieceEnum.Rook, ColorEnum.Black));
            Add(new Coordinate(7, 0), pieceFactory.CreatePiece(PieceEnum.Rook, ColorEnum.Black));
            Add(new Coordinate(0, 7), pieceFactory.CreatePiece(PieceEnum.Rook, ColorEnum.White));
            Add(new Coordinate(7, 7), pieceFactory.CreatePiece(PieceEnum.Rook, ColorEnum.White));

            Add(new Coordinate(1, 0), pieceFactory.CreatePiece(PieceEnum.Knight, ColorEnum.Black));
            Add(new Coordinate(6, 0), pieceFactory.CreatePiece(PieceEnum.Knight, ColorEnum.Black));
            Add(new Coordinate(1, 7), pieceFactory.CreatePiece(PieceEnum.Knight, ColorEnum.White));
            Add(new Coordinate(6, 7), pieceFactory.CreatePiece(PieceEnum.Knight, ColorEnum.White));

            Add(new Coordinate(2, 0), pieceFactory.CreatePiece(PieceEnum.Bishop, ColorEnum.Black));
            Add(new Coordinate(5, 0), pieceFactory.CreatePiece(PieceEnum.Bishop, ColorEnum.Black));
            Add(new Coordinate(2, 7), pieceFactory.CreatePiece(PieceEnum.Bishop, ColorEnum.White));
            Add(new Coordinate(5, 7), pieceFactory.CreatePiece(PieceEnum.Bishop, ColorEnum.White));

            Add(new Coordinate(3, 0), pieceFactory.CreatePiece(PieceEnum.LeftQueen, ColorEnum.Black));
            Add(new Coordinate(3, 7), pieceFactory.CreatePiece(PieceEnum.LeftQueen, ColorEnum.White));

            Add(new Coordinate(4, 0), pieceFactory.CreatePiece(PieceEnum.LeftKing, ColorEnum.Black));
            Add(new Coordinate(4, 7), pieceFactory.CreatePiece(PieceEnum.LeftKing, ColorEnum.White));

            Add(new Coordinate(3, 0), pieceFactory.CreatePiece(PieceEnum.RightKing, ColorEnum.Black));
            Add(new Coordinate(3, 7), pieceFactory.CreatePiece(PieceEnum.RightKing, ColorEnum.White));

            Add(new Coordinate(4, 0), pieceFactory.CreatePiece(PieceEnum.RightQueen, ColorEnum.Black));
            Add(new Coordinate(4, 7), pieceFactory.CreatePiece(PieceEnum.RightQueen, ColorEnum.White));
        }

        public bool Remove(Coordinate key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<Coordinate, Piece> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(Coordinate key, out Piece value)
        {
            throw new NotImplementedException();
        }

        public void Update(Move move, ColorEnum movingPlayer)
        {
            Piece piece = pieceFactory.CreatePiece(this[move.StartPosition].Type, this[move.StartPosition].Color);
            Remove(move.StartPosition);

            if (ContainsKey(move.EndPosition))
            {
                Remove(move.EndPosition);
            }

            Add(move.EndPosition, piece);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}