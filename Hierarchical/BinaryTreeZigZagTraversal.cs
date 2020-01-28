using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeZigZagTraversal
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

    public class BST
    {
        public void PrintTreeZigZag(Node root)
        {
            Stack<Node> currentLevel = new Stack<Node>();
            Stack<Node> nextLevel = new Stack<Node>();
            bool isLeftToRight = true;

            if (root != null)
                currentLevel.Push(root);


            while (currentLevel.Count > 0)
            {
                Node node = currentLevel.Pop();
                Console.Write(node.data + " -> ");

                if (isLeftToRight)
                {
                    if (node.left != null)
                        nextLevel.Push(node.left);
                    if (node.right != null)
                        nextLevel.Push(node.right);
                }
                else
                {
                    if (node.right != null)
                        nextLevel.Push(node.right);
                    if (node.left != null)
                        nextLevel.Push(node.left);
                }

                if (currentLevel.Count == 0)
                {
                    isLeftToRight = !isLeftToRight;
                    Stack<Node> temp = currentLevel;
                    currentLevel = nextLevel;
                    nextLevel = currentLevel;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
                BST tree = new BST();
                Node rootNode = new Node(1);
                rootNode.left = new Node(2);
                rootNode.right = new Node(3);
                rootNode.left.left = new Node(7);
                rootNode.left.right = new Node(6);
                rootNode.right.left = new Node(5);
                rootNode.right.right = new Node(4);

                Console.WriteLine("ZigZag Order traversal " +
                                        "of binary tree is");
                tree.PrintTreeZigZag(rootNode);
            Console.ReadKey();
        }
    }
}
