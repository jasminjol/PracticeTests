using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_FixSwappedNodes
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
        public List<int> currentTree = new List<int>();
        public Node first, middle, last, prev;

        //Option 1 - Do an Inorder traversal and assign the list values to a Sorted Set
        public void TraverseBST(Node root)
        {
            if (root != null)
            {
                TraverseBST(root.left);
                currentTree.Add(root.data);
                TraverseBST(root.right);
            }
        }

        public void PrintValues(List<int> tree)
        {
            foreach (int value in tree)
            {
                Console.Write(" " + value + " -> ");
            }
        }

        //Option 2 - Do an Inorder traversal and find the incorrect values and Swap.
        private void TraverseNodesAndFind(Node root)
        {
            if (root != null)
            {
                TraverseNodesAndFind(root.left);

                if (prev != null && root.data < prev.data)
                {
                    if (first == null)
                    {
                        first = prev;
                        middle = root;
                    }
                    else
                        last = root;
                }               
                 prev = root;

                TraverseNodesAndFind(root.right);
            }
        }

        public void CorrectBST(Node root)
        {
            if (root == null)
                return;

            first = last = middle = prev = null;
            TraverseNodesAndFind(root);

            if (first != null && last != null)
            {
                int temp = first.data;
                first.data = last.data;
                last.data = temp;
            }
            else if (first != null && middle != null)
            {
                int temp = first.data;
                first.data = middle.data;
                middle.data = temp;
            }
        }

        public void PrintInOrder(Node root)
        {
            if (root == null)
                return;

            PrintInOrder(root.left);
            Console.Write(" {0} -> ", root.data);
            PrintInOrder(root.right);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(6);
            root.left = new Node(10);
            root.right = new Node(2);
            root.left.left = new Node(1);
            root.left.right = new Node(3);
            root.right.right = new Node(12);
            root.right.left = new Node(7);

            BST bstTree = new BST();
            //Do an Inorder Traversal to get the current items
            bstTree.TraverseBST(root);
            Console.WriteLine("========= Option 1 ===========");
            Console.WriteLine("Printing Original BST");
            bstTree.PrintValues(bstTree.currentTree);

            //Assigning the current tree list to a Sorted Set to auto correct the order
            SortedSet<int> correctedTree = new SortedSet<int>(bstTree.currentTree);
            Console.WriteLine();
            Console.WriteLine("Printing Corrected BST");           
            bstTree.PrintValues(correctedTree.ToList());

            //Option 2 - Find mismatched nodes using Inorder Traversal and Swap them
            Console.WriteLine();
            Console.WriteLine("========= Option 2 ===========");
            Console.WriteLine("Printing Original BST");
            bstTree.PrintInOrder(root);
            
            Console.WriteLine();
            Console.WriteLine("Printing Corrected BST");
            bstTree.CorrectBST(root);
            bstTree.PrintInOrder(root);
            Console.ReadKey();
        }
    }
}
