using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_LCA
{
    public class Node
    {
        public Node right, left;
        public int data;

        public Node(int item)
        {
            this.data = item;
            left = right = null;
        }
    }

    public class BinaryTree
    {
        public Node root;

        public Node FindLCA(int n1, int n2)
        {
            return FindLCA(root, n1, n2);
        }
        private Node FindLCA(Node node, int n1, int n2)
        {
            if (node == null)
                return null;

            if (node.data == n1 || node.data == n2)
                return node;

            Node leftLCA = FindLCA(node.left, n1, n2);
            Node rightLCA = FindLCA(node.right, n1, n2);

            if (leftLCA != null && rightLCA != null)
                return node;

            return (leftLCA != null) ? leftLCA : rightLCA;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*              1
             *            /    \ 
             *           2      3
             *          / \     / \
             *         4   5   6   7
             *         
             *   LCA(4,5) -> 2
             *   LCA(4,6) -> 1
             *   LCA(3,4) -> 1
             *   LCA(2,4) -> 2
             */
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(6);
            tree.root.right.right = new Node(7);
            Console.WriteLine("LCA(4, 5) = " +
                                tree.FindLCA(4, 5).data);
            Console.WriteLine("LCA(4, 6) = " +
                                tree.FindLCA(4, 6).data);
            Console.WriteLine("LCA(3, 4) = " +
                                tree.FindLCA(3, 4).data);
            Console.WriteLine("LCA(2, 4) = " +
                                tree.FindLCA(2, 4).data);
            Console.ReadKey();
        }
    }
}
