using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeToDLL
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int value;

        public Node(int data)
        {
            this.value = data;
        }
    }

    public class Convert
    {
        public Node root;
        public Node head;
        public static Node prev = null;

        public void BinaryToDLL(Node root)
        {
            if (root == null)
                return;

            BinaryToDLL(root.Left);

            if (prev == null)
            {
                head = root;
            }
            else
            {
                root.Left = prev;
                prev.Right = root;
            }
            prev = root;

            BinaryToDLL(root.Right);
        }

        public virtual void PrintDLL(Node node)
        {
            while (node != null)
            {
                Console.Write(node.value + " <-> ");
                node = node.Right;
            }
            Console.ReadKey();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*      10
             *     /   \
             *    12    15
             *   / \    / 
             *  25  30  36
             */  
           //Output = 25 <-> 12 <-> 30 <-> 10 <-> 36 <-> 15

            Convert tree = new Convert();
            tree.root = new Node(10);
            tree.root.Left = new Node(12);
            tree.root.Right = new Node(15);
            tree.root.Left.Left = new Node(25);
            tree.root.Left.Right = new Node(30);
            tree.root.Right.Left = new Node(36);

            // convert to DLL  
            tree.BinaryToDLL(tree.root);

            // Print the converted DLL  
            tree.PrintDLL(tree.head);
        }
    }
}
