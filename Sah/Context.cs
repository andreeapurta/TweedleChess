using Chess.Interfaces;
using System.Collections.Generic;

namespace Chess
{
    public class Context
    {
        public ILayout Layout { get; set; }
        public List<Move> Moves { get; set; }
        public ColorEnum CurrentPlayer { get; set; }

        public void Initialize(ILayout layout)
        {
            Layout = layout;
            Moves = new List<Move>();
            CurrentPlayer = ColorEnum.White;
        }

        public void InitializeStartingBoard()
        {
            Layout.Initialize();
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