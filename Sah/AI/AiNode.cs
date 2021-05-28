namespace Chess
{   //mutare -> da scor asta
    public class AiNode
    {
        public AiNode()
        {
        }

        public AiNode(Move move, int Value)
        {
            Move = move;
            this.Value = Value;
        }

        public Move Move { get; set; }
        public int Value { get; set; }
    }
}