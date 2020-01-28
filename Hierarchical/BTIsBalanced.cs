using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTIsBalanced
{

    public class Node
    {
       public Node left, right = null;
       public int data;

        public Node (int value)
        {
            this.data = value;
        }
    }

    public class BinaryTree
    {
        public int GetHeight(Node node)
        {
            if (node == null)
                return 0;

            return Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
        }

        public bool IsBalanced(Node node)
        {
            // Empty tree is balanced
            if (node == null)
                return true;

            int heightDiff = GetHeight(node.left) - GetHeight(node.right);

            if (Math.Abs(heightDiff) > 1)
                return false;
            else
            {
                return (IsBalanced(node.left) && IsBalanced(node.right));
            }
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
            */

            Node root1 = new Node(10);
            root1.left = new Node(2);
            root1.right = new Node(3);
            root1.left.left = new Node(7);
            root1.left.right = new Node(8);
            root1.right.right = new Node(15);
            root1.right.left = new Node(12);
            root1.right.right.left = new Node(14);

            /* Input: Unbalanced Tree
              10
            /     \
            2         3
          /   \    /    \
         7     8  12     15
          \              /
           6           14 
            \
             9
              \
               1
             */

            Node root2 = new Node(10);
            root2.left = new Node(2);
            root2.right = new Node(3);
            root2.left.left = new Node(7);
            root2.left.right = new Node(8);
            root2.left.left.right = new Node(6);
            root2.left.left.right.right = new Node(9);
            root2.left.left.right.right.right = new Node(1);
            root2.right.right = new Node(15);
            root2.right.left = new Node(12);
            root2.right.right.left = new Node(14);

            BinaryTree tree1 = new BinaryTree();
            if (tree1.IsBalanced(root1))
                Console.WriteLine("Tree {0} is balanced.", "1");
            else
                Console.WriteLine("Tree {0} is not balanced.", "1");

            if (tree1.IsBalanced(root2))
                Console.WriteLine("Tree {0} is balanced.", "2");
            else
                Console.WriteLine("Tree {0} is not balanced.", "2");

            Console.ReadKey();
        }
    }
}
