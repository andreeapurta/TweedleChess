using System;

namespace Chess.Events
{
    public class MoveProposeEventArgs : EventArgs
    {
        public Move Move { get; set; }

        public MoveProposeEventArgs()
        {
        }
    }
}