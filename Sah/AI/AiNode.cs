using System.Collections.Generic;

namespace Chess
{
    public class AiNode
    {
        public AiNode()
        {
            Children = new List<AiNode>();
        }

        public AiNode(Move move, int Value)
        {
            Move = move;
            this.Value = Value;
        }

        public void AddChild(AiNode nodeValue)
        {
            nodeValue.Parent = this;
            Children.Add(nodeValue);
        }

        public Context CurrentContext { get; set; }

        public List<AiNode> Children { get; set; }
        public Move Move { get; set; }
        public AiNode Parent { get; set; }
        public int Value { get; set; }
    }
}