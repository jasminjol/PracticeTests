using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildTreeFromList
{

    public class Node
    {
        public int? Id { get; set; }
        public string Text { get; set; }
        public int? Parent { get; set; }
        public List<Node> Children { get; set; }

        public Node()
        {
            Children = new List<Node>();
        }
    }

    public static class Tree
    {
        public static Node BuildTree(this List<Node> nodes)
        {
            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }
            return new Node().BuildTree(nodes);
        }

        public static IEnumerable<Node> FetchChildren(this Node root, List<Node> nodes)
        {
            return nodes.Where(n => n.Parent == root.Id);
        }

        private static Node BuildTree(this Node root, List<Node> nodes)
        {
            if (nodes.Count == 0) { return root; }

            var children = root.FetchChildren(nodes).ToList();
            root.Children.AddRange(children);
            root.RemoveChildren(nodes);

            for (int i = 0; i < children.Count; i++)
            {
                children[i] = children[i].BuildTree(nodes);
                if (nodes.Count == 0) { break; }
            }

            return root;
        }

        public static void RemoveChildren(this Node root, List<Node> nodes)
        {
            foreach (var node in root.Children)
            {
                nodes.Remove(node);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
