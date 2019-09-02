using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNodesAtKDistanceFromRoot
{
    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    public class BinaryTree
    {
        public Node root;

        public virtual void printKDistant(Node node, int k)
        {
            if (node == null)
            {
                return;
            }
            if (k == 0)
            {
                Console.Write(node.data + " -> ");
                return;
            }
            else
            {
                printKDistant(node.left, k - 1);
                printKDistant(node.right, k - 1);
            }
        }
    }
        class Program
        {
             static void Main(string[] args)
             {
                BinaryTree tree = new BinaryTree();

                /* Constructed binary tree is  
                        1  
                      /   \  
                     2     3  
                    /  \   /  
                   4    5 8   
                */
                tree.root = new Node(1);
                tree.root.left = new Node(2);
                tree.root.right = new Node(3);
                tree.root.left.left = new Node(4);
                tree.root.left.right = new Node(5);
                tree.root.right.left = new Node(8);

                tree.printKDistant(tree.root, 2);
                Console.ReadKey();
            }
        }
}
