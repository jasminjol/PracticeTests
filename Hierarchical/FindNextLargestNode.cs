using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNextLargest
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Input:
            20
          /    \
         8      22
       /   \    
      4     12  
           /  \ 
         10    14 
        */
            Node root = new Node(20);
            root.left = new Node(8);
            root.left.parent = root;
            root.right = new Node(22);
            root.right.parent = root;
            root.left.left = new Node(4);
            root.left.right = new Node(12);
            root.left.left.parent = root.left.right.parent = root.left;
            root.left.right.right = new Node(14);
            root.left.right.left = new Node(10);
            root.left.right.right.parent = root.left.right.left.parent = root.left.right;

            BST bst = new BST();
            Console.WriteLine("Next largest of 20:" + bst.FindNextLargest(root, 20));
            Console.WriteLine("Next largest of 10:" + bst.FindNextLargest(root, 10));
            Console.WriteLine("Next largest of 12:" + bst.FindNextLargest(root, 12));
            Console.WriteLine("Next largest of 14:" + bst.FindNextLargest(root, 14));
            Console.WriteLine("Next largest of 8:" + bst.FindNextLargest(root, 8));
            Console.WriteLine("Next largest of 4:" + bst.FindNextLargest(root, 4));
            Console.WriteLine("Next largest of 22:" + bst.FindNextLargest(root, 22));
            Console.ReadKey();
        }
    }

    public class Node
    {
        public int data;
        public Node left, right, parent;

        public Node(int value)
        {
            this.data = value;
            this.left = this.right = this.parent = null;
        }
    }

    public class BST
    {
        public int FindNextLargest(Node root, int number)
        {
            if (root == null)
                return -1;

            Node nextL = root;

            while (nextL != null)
            {
                if (nextL.data > number)
                {
                    nextL = nextL.left;
                }

                if (nextL.data < number)
                {
                    nextL = nextL.right;
                }

                if (nextL.data == number)
                {
                    if (nextL.right == null && nextL.left == null)
                    {
                        while (nextL.parent != null)
                        {
                            if (nextL.parent.left != nextL)
                                nextL = nextL.parent;
                            else
                                return nextL.parent.data;
                        }

                        return -1;
                    }

                    if (nextL.right != null)
                        nextL = nextL.right;

                    while (nextL.left != null)
                    {
                        nextL = nextL.left;
                    }

                    return nextL.data;
                }
            }

            return -1;
        }
    }
}
