using System;

namespace Chess.Events
{
    public class ContexChangeEventArgs : EventArgs
    {
        public Context Contex { get; set; }

        public ContexChangeEventArgs()
        {
        }
    }
}