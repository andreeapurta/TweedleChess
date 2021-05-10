namespace Chess.Interfaces
{
    public interface IPieceFactory
    {
        Piece CreatePiece(PieceEnum type, ColorEnum color);
    }
}