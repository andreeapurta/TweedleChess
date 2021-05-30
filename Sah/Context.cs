using System.Collections.Generic;

namespace Chess
{
    public class Context
    {
        public Layout Layout { get; set; }
        public List<Move> Moves { get; set; }
        public ColorEnum CurrentPlayer { get; set; }
        public bool VsAI { get; set; }

        public Context()
        {
        }

        public bool CheckMating()
        {
            int numberOfWhiteKings = 0;
            int numberOfBlackKings = 0;
            foreach (KeyValuePair<Coordinate, Piece> piece in Layout)
            {
                if (((piece.Value.Type == PieceEnum.LeftKing) && (piece.Value.Color == ColorEnum.White)) || ((piece.Value.Type == PieceEnum.RightKing) && (piece.Value.Color == ColorEnum.White)))
                {
                    numberOfWhiteKings++;
                }

                if (((piece.Value.Type == PieceEnum.LeftKing) && (piece.Value.Color == ColorEnum.Black)) || ((piece.Value.Type == PieceEnum.RightKing) && (piece.Value.Color == ColorEnum.Black)))
                {
                    numberOfBlackKings++;
                }
            }

            if (numberOfBlackKings == 1 || numberOfWhiteKings == 1)
            {
                return true;
            }
            else return false;
        }

        public bool AlertCheck()
        {
            Dictionary<Coordinate, Piece> KingsPositions = new Dictionary<Coordinate, Piece>();
            foreach (KeyValuePair<Coordinate, Piece> piece in Layout)
            {
                if ((piece.Value.Type == PieceEnum.LeftKing) || (piece.Value.Type == PieceEnum.RightKing))
                {
                    KingsPositions.Add(piece.Key, piece.Value);
                }
            }
            foreach (KeyValuePair<Coordinate, Piece> piece in Layout)
            {
                foreach (var king in KingsPositions)
                {
                    if (piece.Value.GetNextLegalMoves(piece.Key, this).Contains(king.Key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Initialize(Layout layout)
        {
            Layout = layout;
            Moves = new List<Move>();
            CurrentPlayer = ColorEnum.White;
        }

        public void InitializeStartingBoard()
        {
            Layout.Initialize();
        }

        public Context Clone()
        {
            Context cloneContext = new Context();
            cloneContext.CurrentPlayer = CurrentPlayer;
            cloneContext.Moves = new List<Move>(Moves);
            cloneContext.Layout = Layout.Clone();

            return cloneContext;
        }

        public void Update(Move move)
        {
            this.Layout.Update(move);
            ToggleCurrentPlayer();
        }

        public void ToggleCurrentPlayer()
        {
            if (CurrentPlayer == ColorEnum.White)
            {
                CurrentPlayer = ColorEnum.Black;
            }
            else
            {
                CurrentPlayer = ColorEnum.White;
            }
        }
    }
}