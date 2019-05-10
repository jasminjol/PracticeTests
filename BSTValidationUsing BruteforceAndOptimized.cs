using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateBinarySearchTree
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Data { get; set; }

        public Node(int item)
        {
            Data = item;
        }
    }

    public class BinaryTree
    {
        public Node root { get; set; }
        public bool BruteForceIsBST(Node node)
        {
            if (node == null)
                return true;

            if (node.Left != null && node.Left.Data > node.Data)
                return false;

            if (node.Right != null && node.Right.Data < node.Data)
                return false;

            if (!BruteForceIsBST(node.Left) || !BruteForceIsBST(node.Right))
                return false;

            return true;
        }

        public bool IsBST()
        {
            return CheckIsBST(this.root, Int32.MinValue, Int32.MaxValue);
        }

        public bool CheckIsBST(Node node, int minValue, int maxValue)
        {
            if (node == null)
                return true;

            if (node.Data < minValue || node.Data > maxValue)
                  return false;

            Console.Write(node.Data.ToString() + " -> ");

            return (CheckIsBST(node.Left, minValue, node.Data-1) && CheckIsBST(node.Right, node.Data+1, maxValue));

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree
            {
                root = new Node(5)
            };
            tree.root.Left = new Node(3);
            tree.root.Right = new Node(7);
            tree.root.Left.Left = new Node(2);
            tree.root.Left.Right = new Node(4);
            tree.root.Right.Left = new Node(6);
            tree.root.Right.Right = new Node(8);

            if (tree.IsBST())
            {
                Console.WriteLine("IS BST");
            }
            else
            {
                Console.WriteLine("Not a BST");
            }

            Console.ReadKey();
        }
    }

}
