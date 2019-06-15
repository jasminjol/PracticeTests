using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTreeAndVerify
{
    public class Node
    {
        public Node left, right = null;
        public int data;

        public Node(int value)
        {
            this.data = value;
        }

        public Node(int value, Node left, Node right)
        {
            this.data = value;
            this.left = left;
            this.right = right;
        }

        //Deep copy of tree
        public Node Copy()
        {
            Node left = null;
            Node right = null;
            if (this.left != null)
            {
                left = this.left.Copy();
            }
            if (this.right != null)
            {
                right = this.right.Copy();
            }
            return new Node(data, left, right);
        }
    }

    public class Mirror
    {
        public Node MirrorTree(Node node)
        {
            if (node == null)
                return node;

            Node left = MirrorTree(node.left);
            Node right = MirrorTree(node.right);

            node.left = right;
            node.right = left;

            return node;
        }

        public Boolean IsMirror(Node tree1, Node tree2)
        {
            if (tree1 == null && tree2 == null)
                return true;

            if (tree1 == null || tree2 == null)
                return false;

            return (tree1.data == tree2.data && IsMirror(tree1.left, tree2.right) && IsMirror(tree1.right, tree2.left));

        }

        //InOrder Traversal
        public void PrintTreeInOrderT(Node tree)
        {
            if (tree == null)
                return;

            PrintTreeInOrderT(tree.left);
            Console.Write(tree.data + " -> ");
            PrintTreeInOrderT(tree.right);
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
            Node tree1 = new Node(10);
            tree1.left = new Node(2);
            tree1.right = new Node(3);
            tree1.left.left = new Node(7);
            tree1.left.right = new Node(8);
            tree1.right.right = new Node(15);
            tree1.right.left = new Node(12);
            tree1.right.right.left = new Node(14);

            Mirror mirror = new Mirror();
            Console.WriteLine("Printing Original tree before mirroring");
            mirror.PrintTreeInOrderT(tree1);
            Console.WriteLine();

            Node tree1Copy = tree1.Copy();

            Node tree2 = mirror.MirrorTree(tree1);
            Console.WriteLine("Printing clone of Original tree after mirroring");
            mirror.PrintTreeInOrderT(tree1Copy);
            Console.WriteLine();

            Console.WriteLine("Printing Mirror tree");
            mirror.PrintTreeInOrderT(tree2);
            Console.WriteLine();

            Console.WriteLine("Checking if Tree1 and Tree2 are Mirror trees");
            Console.WriteLine("Is mirror - " +mirror.IsMirror(tree1Copy, tree2).ToString());
            Console.ReadKey();

        }
    }
}
