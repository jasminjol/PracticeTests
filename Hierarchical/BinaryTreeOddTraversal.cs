using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeOddTraversal
{
    public class Node
    {
        public Node left, right;
        public int data;

        public Node(int value)
        {
            this.data = value;
        }
    }

    public class BinaryTree
    {
        public Node root;
        public void PrintOddNodes(Node root, bool isOdd)
        {
            if (root == null)
                return;

            if (isOdd)
            {
                Console.WriteLine(root.data);
            }

            PrintOddNodes(root.left, !isOdd);
            PrintOddNodes(root.right, !isOdd);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(10);
            tree.root.left = new Node(8);
            tree.root.right = new Node(12);
            tree.root.left.right = new Node(9);
            tree.root.left.left = new Node(7);

            tree.PrintOddNodes(tree.root, true);
            Console.ReadKey();
        }
    }
}
