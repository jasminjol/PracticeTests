using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeChildSumProperty
{
    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int value)
        {
            this.data = value;
            left = right = null;
        }
    }

    public class BinaryTree
    {
        public Node root { get; set; }

        public bool CheckForChildSumProperty(Node node)
        {
            if (node == null || (node.left == null && node.right == null))
                return true;

            int leftdata = 0;
            int rightdata = 0;

            if (node.left != null)
                leftdata = node.left.data;

            if (node.right != null)
                rightdata = node.right.data;

            if ((node.data == leftdata + rightdata) &&
                CheckForChildSumProperty(node.left) && CheckForChildSumProperty(node.right))
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(10);
            tree.root.left = new Node(8);
            tree.root.right = new Node(2);
            tree.root.left.left = new Node(3);
            tree.root.left.right = new Node(5);
            tree.root.right.right = new Node(2);
         // tree.root.right.left = new Node(1);

            if (tree.CheckForChildSumProperty(tree.root))
                Console.WriteLine("The BST satisfies Child Sum Property");
            else
                Console.WriteLine("The BST does not satisfy Child Sum Property");

            Console.ReadKey();
        }
    }
}
