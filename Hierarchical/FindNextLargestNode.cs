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
        Time Complexity - O(h)
     public static TreeNode findNextHigherNodeInBST(TreeNode node){

     /* Empty Tree */
     if (node == null)
        return null;

     /* If the given node has right child  */
     if (node.right() != null)
        return findLeftMostNode(node.right());

     /* When the given node has no right child  */
     /* Go up till node is the first left child - return node's parent */
     TreeNode parent = node.parent();
     while (parent != null  & &  node == parent.right()){
        node = parent;
        parent = parent.parent();
     }
        // Intuition: as we traverse left up the tree we traverse smaller values
        // The first node on the right is the next larger number
     return parent;
 }

 public static Node findLeftMostNode(Node node){

      if(node == null)
           return null;

      /* Go to the leftmost leaf node */
      while(node.left != null)
           node = node.left;

      /* Return the leftmost node */
      return node;
 }
    }
}
