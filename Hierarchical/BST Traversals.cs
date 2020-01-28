using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTTraversal
{
    public class Node
    {
        public Node Left{ get; set;}
        public Node Right { get; set; }
        public int Value { get; set; }

        public Node(int data)
        {
            this.Value = data;
        }
    }

    public class BST
    {
        public Node Root { get; set; }

        // Left subtree -> Root -> Right subtree
        public void InOrderTraversal(Node root)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left);
                Console.Write(root.Value + " -> ");
                InOrderTraversal(root.Right);
            }
        }

        // Root -> Left subtree -> Right subtree
        public void PreOrderTraversal(Node root)
        {
            if (root != null)
            {
                Console.Write(root.Value + " -> ");
                PreOrderTraversal(root.Left);
                PreOrderTraversal(root.Right);
            }
        }

        // Left subtree -> Right subtree -> Node
        public void PostOrderTraversal(Node root)
        {
            if (root != null)
            {
                PostOrderTraversal(root.Left);
                PostOrderTraversal(root.Right);
                Console.Write(root.Value + " -> ");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BST tree = new BST();
            tree.Root = new Node(20);
            tree.Root.Left = new Node(10);
            tree.Root.Left.Left = new Node(5);
            tree.Root.Left.Right = new Node(7);

            tree.Root.Right = new Node(30);
            tree.Root.Right.Left = new Node(25);
            tree.Root.Right.Right = new Node(27);

            Console.WriteLine(" ******* InOrder Traversal *******");
            tree.InOrderTraversal(tree.Root);
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine(" ******* PreOrder Traversal *******");
            tree.PreOrderTraversal(tree.Root);
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine(" ******* PostOrder Traversal *******");
            tree.PostOrderTraversal(tree.Root);
            Console.ReadKey();
            Console.WriteLine();

        }
    }
}
