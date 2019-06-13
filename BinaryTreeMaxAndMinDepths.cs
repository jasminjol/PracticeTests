using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeMaxAndMinDepths
{
    public class Node
    {
        public Node left, right = null;
        public int data;

        public Node(int value)
        {
            this.data = value;
        }
    }

    public class BinaryTree
    {
        public int MaxDepth(Node node)
        {
            if (node == null)
                return 0;

            int leftMax = node.left == null ? 0 : MaxDepth(node.left);
            int rightMax = node.right == null ? 0 : MaxDepth(node.right);

            return (1 + Math.Max(leftMax, rightMax));
        }

        public int MinDepth(Node root)
        {
            return MinDepth(root, 0);
        }

        private int MinDepth(Node root, int level)
        {

            if (root == null)
                return level;
            level++;

            return Math.Min(MinDepth(root.left, level),
                    MinDepth(root.right, level));
        }
    }
        class Program
        {
        static void Main(string[] args)
        {
            /* Input: Balanced Tree
              10
            /     \
            2         3
          /   \    /    \
         7     8  12     15
                        /
                      14 
                      /
                    18
        */

            Node root = new Node(10);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(7);
            root.left.right = new Node(8);
            root.right.right = new Node(15);
            root.right.left = new Node(12);
            root.right.right.left = new Node(14);
            root.right.right.left.left = new Node(18);

            BinaryTree tree = new BinaryTree();

            Console.WriteLine("BT Max Depth is : " + tree.MaxDepth(root).ToString());
            Console.WriteLine("BT Min Depth is : " + tree.MinDepth(root).ToString());
            Console.ReadKey();
        }
    }
}
