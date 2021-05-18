using Chess.Interfaces;
using System.Collections.Generic;

namespace Chess
{
    public class Context
    {
        public Layout Layout { get; set; }
        public List<Move> Moves { get; set; }
        public ColorEnum CurrentPlayer { get; set; }

        public Context()
        {
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