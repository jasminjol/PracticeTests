using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalHeightBSTWithSortedArray
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

    public class Tree
    {
        public Node CreateMinimalBST(int[] sortedArray)
        {
            return CreateMinimalBST(sortedArray, 0, sortedArray.Length - 1);
        }
        private Node CreateMinimalBST(int[] sortedArray, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;

            Node root = new Node(sortedArray[mid]);
            root.left = CreateMinimalBST(sortedArray, start, mid - 1);
            root.right = CreateMinimalBST(sortedArray, mid + 1, end);

            return root;
        } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            Tree tree = new Tree();
            Node bst = tree.CreateMinimalBST(array);
            PrintTree(bst);
            Console.ReadKey();
        }

        static void PrintTree(Node node)
        {
            if (node != null)
            {
               PrintTree(node.left);
               PrintTree(node.right);
               Console.WriteLine(node.data + " -> ");
            }

        }
    }
}
