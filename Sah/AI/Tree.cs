using System.Collections.Generic;

namespace Chess
{
    public class Tree<T>
    {
        public AiNode Root { get; set; }

        public Tree(int depth, Context Context)
        {
            Root = new AiNode();
            Root.Move = new Move();
            Root.CurrentContext = Context.Clone(); //Pe o copie a contextului fac miscarea posibila
            AddNodes(Root, depth, ColorEnum.Black); //creaza node ul
        }

        public void AddNodes(AiNode node, int depth, ColorEnum color) // DEPTH TREBE SA FIE PAR CA SA AVEM NODE MAXIMIZANT LA FRUNZE
        {
            //preorder
            if (depth > 0)
            {
                AddChildren(node, color);
                foreach (var child in node.Children)
                {
                    if (color == ColorEnum.White)
                    {
                        AddNodes(child, depth - 1, ColorEnum.Black); //ca ma duc tot in jos
                    }
                    else
                    {
                        AddNodes(child, depth - 1, ColorEnum.White);
                    }
                }
            }
        }

        public int CalculateValue(Layout chessLayout, Move move)
        {
            int value = 0;
            foreach (var piece in chessLayout)
            {
                if (piece.Value.GetColor() == ColorEnum.White)
                {
                    value -= piece.Value.GetValue();
                }
                else
                {
                    value += piece.Value.GetValue();
                }
            }
            return value;
        }

        public void AddChildren(AiNode node, ColorEnum color)
        {
            List<Move> AllMoves = new List<Move>();
            foreach (var piece in node.CurrentContext.Layout)
            {
                if (piece.Value.Color == color)
                {
                    foreach (var destination in piece.Value.GetNextLegalMoves(piece.Key, node.CurrentContext))
                    {
                        if (AllMoves.Count < 10) //prea multe posibilitati si dureaza foarte mult, asa ca reduc la 10 de mutari
                        {
                            AllMoves.Add(new Move(piece.Key, destination, piece.Value));
                        }
                        else break;
                    }
                }
            }
            foreach (var move in AllMoves)
            {
                AiNode child = new AiNode();
                child.CurrentContext = node.CurrentContext.Clone();
                child.CurrentContext.Update(move);
                child.Move = move;
                child.Parent = node;
                child.Value = CalculateValue(child.CurrentContext.Layout, child.Move);
                node.AddChild(child);
            }
        }
    }
}