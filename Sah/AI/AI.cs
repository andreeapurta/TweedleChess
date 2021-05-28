using Chess;
using System.Collections.Generic;

namespace Chess
{
    public class AI
    {
        //https://www.youtube.com/watch?v=l-hh51ncgDI
        private int depth;

        private bool revMaxPlayer;
        private int nodeMinValue = -999;
        private int nodeMaxValue = 999;
        public Context context;

        public AI(Context context)
        {
            this.context = context;
        }

        public int CalculateValue(Layout chessLayout, Move move)
        {
            return 0;
        }

        public void Init()
        {
            int depth = 4;
            depth = 1;
            depth = 0;
            depth = 4;

            TreeNode<AiNode> rootNode = new TreeNode<AiNode>(new AiNode());
            List<Move> allMoves = new List<Move>();

            foreach (var piece in context.Layout)
            {
                foreach (var destination in piece.Value.GetNextLegalMoves(piece.Key, context))
                {
                    allMoves.Add(new Move(piece.Key, destination, piece.Value));
                }
            }
            foreach (var move in allMoves)
            {
                rootNode.AddChild(new AiNode(move, CalculateValue(context.Layout, move)));
            }
        }

        public Move GetNextMove()
        {
            return new Move();
        }

        //public void AddChildren(TreeNode<int> node, bool maximizingPlayer)
        //{
        //    bool colorToMove = maximizingPlayer;
        //    int heuristicVal;

        //    if (revMaxPlayer)
        //        colorToMove = !colorToMove;

        //    foreach (KeyValuePair<string, List<string>> pieceMoves in board.GetAllMove(colorToMove))
        //    {
        //        foreach (string move in pieceMoves.Value)
        //        {
        //            board.LoadBoardWithFen(node.Edge);
        //            board.SetPieceCoord(pieceMoves.Key, move);
        //            board.UpdateFen();

        //            if (revMaxPlayer)
        //                heuristicVal = board.GetHeuristicValue() * (-1);
        //            else
        //                heuristicVal = board.GetHeuristicValue();

        //            node.AddChild(heuristicVal, board.GetFen());
        //        }
        //    }
        //}

        public int Minimax(TreeNode<int> node, int depth, int alpha, int beta, bool maximizingPlayer)
        {
            //AddChildren(node, maximizingPlayer);

            if (depth == 0 || node.Children.Count == 0)
                return node.Value;

            if (maximizingPlayer)
            {
                node.Value = nodeMinValue;

                foreach (TreeNode<int> childNode in node.Children)
                {
                    childNode.Value = Minimax(childNode, depth - 1, alpha, beta, !maximizingPlayer);

                    if (childNode.Value > node.Value)
                        node.Value = childNode.Value;

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

                foreach (TreeNode<int> childNode in node.Children)
                {
                    childNode.Value = Minimax(childNode, depth - 1, alpha, beta, !maximizingPlayer);

                    if (childNode.Value < node.Value)
                        node.Value = childNode.Value;

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