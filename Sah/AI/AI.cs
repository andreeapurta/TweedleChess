using System;

namespace Chess
{
    public class AI
    {
        //https://www.youtube.com/watch?v=l-hh51ncgDI
        private const int depth = 4;

        private const int nodeMinValue = -999;
        private const int nodeMaxValue = 999;
        public Context context;
        public Tree<AiNode> Tree { get; set; }

        public AI(Context context)
        {
            this.context = context;
            Init();
        }

        public void Init()
        {
            Tree = new Tree<AiNode>(depth, context);
        }

        public Move GetNextMove()
        {
            Move move = new Move(); //best move
            int bestValue = Minimax(Tree.Root, depth, nodeMinValue, nodeMaxValue, true);
            foreach (var child in Tree.Root.Children)
            {
                if (child.Value == bestValue)
                {
                    move = child.Move;
                }
            }
            return move;
        }

        public int Minimax(AiNode node, int depth, int alpha, int beta, bool maximizingPlayer)
        {
            if (depth == 0 || node.Children.Count == 0)
                return node.Value;

            if (maximizingPlayer)
            {
                node.Value = nodeMinValue;

                foreach (var child in node.Children)
                {
                    child.Value = Minimax(child, depth - 1, alpha, beta, !maximizingPlayer);

                    if (child.Value > node.Value)
                        node.Value = child.Value;

                    if (node.Value > alpha)
                        alpha = node.Value;

                    if (alpha >= beta)
                        break;
                }
                return node.Value;
            }
            else
            {
                node.Value = nodeMaxValue;

                foreach (var child in node.Children)
                {
                    child.Value = Minimax(child, depth - 1, alpha, beta, !maximizingPlayer);

                    if (child.Value < node.Value)
                        node.Value = child.Value;

                    if (node.Value < beta)
                        beta = node.Value;

                    if (alpha >= beta)
                        break;
                }

                return node.Value;
            }
        }
    }
}