using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeFindSubtree
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

    public class BinaryTree
    {
        private Boolean IsIdentical(Node root1, Node root2)
        {
            if (root1 == null && root2 == null)
                return true;
            if (root1 == null || root2 == null)
                return false;

            return (root1.data == root2.data
                && root1.left.data == root2.left.data
                && root1.right.data == root2.right.data);

        }

        public Boolean IsSubtree(Node Maintree, Node Subtree)
        {
            if (Subtree == null)
                return true;
            if (Maintree == null)
                return false;

            if (IsIdentical(Maintree, Subtree))
                return true;

            return (IsIdentical(Maintree.left, Subtree) || IsIdentical(Maintree.right, Subtree));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            /* TREE 1  
                  26  
                /    \  
                10   3  
                / \   \  
                4   6  3  
                 \  
                30          
           */

            Node root1 = new Node(26);
            root1.right = new Node(3);
            root1.right.right = new Node(3);
            root1.left = new Node(10);
            root1.left.left = new Node(4);
            root1.left.left.right = new Node(30);
            root1.left.right = new Node(6);

            /* TREE 2  
                10  
                / \  
                4 6  
                \  
                30 
            */

            Node root2 = new Node(10);
            root2.right = new Node(6);
            root2.left = new Node(4);
            root2.left.right = new Node(30);

            if (tree.IsSubtree(root1, root2))
                Console.WriteLine("Tree 2 is subtree of Tree 1 ");
            else
                Console.WriteLine("Tree 2 is not a subtree of Tree 1");

            Console.ReadKey();
        }
    }
}
