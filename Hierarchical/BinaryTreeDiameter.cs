using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeDiameter
{
    public class Node
    {
        public Node left, right;
        public int data;

        public Node(int value)
        {
            this.data = value;
            left = right = null;
        }
    }

    public class Tree
    {
        private int GetHeight(Node root)
        {
            if (root == null)
                return 0;

            return (Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1);
        }

        public int FindDiameter(Node root)
        {
            if (root == null)
                return 0;

            int lHeight = GetHeight(root.left);
            int rHeight = GetHeight(root.right);

            int ldiameter = FindDiameter(root.left);
            int rdiameter = FindDiameter(root.right);

            return (Math.Max((lHeight + rHeight + 1), Math.Max(ldiameter, rdiameter)));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();

            /* TREE 1  
                  26  
                 /    \  
                10    3  
                / \    \  
                4   6   3  
                 \  
                30          
           */
            Node root = new Node(26);
            root.right = new Node(3);
            root.right.right = new Node(3);
            root.left = new Node(10);
            root.left.left = new Node(4);
            root.left.left.right = new Node(30);
            root.left.right = new Node(6);

            Console.WriteLine("Diameter of the tree is {0}", tree.FindDiameter(root));
            Console.ReadKey();
        }
    }
}
