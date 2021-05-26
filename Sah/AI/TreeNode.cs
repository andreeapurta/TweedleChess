using System.Collections.Generic;

namespace Chess
{
    public class TreeNode<T>
    {
        public List<TreeNode<T>> Children = new List<TreeNode<T>>();

        public T Value { get; set; }

        public TreeNode(T nodeValue)
        {
            Value = nodeValue;
        }

        public TreeNode<T> AddChild(T nodeValue)
        {
            TreeNode<T> nodeItem = new TreeNode<T>(nodeValue);
            Children.Add(nodeItem);
            return nodeItem;
        }
    }
}