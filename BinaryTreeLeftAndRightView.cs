using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLeftAndRightView
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

    public class BinaryTree
    {
        public IList<int> GetRightTreeView(Node node)
        {
            List<int> result = new List<int>();

            if (node == null)
                return result;

            Queue<Node> nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(node);

            while (nodeQueue.Count != 0)
            {
                int n = nodeQueue.Count;

                for (int i=1; i<=n; i++)
                {
                    Node temp = nodeQueue.Dequeue();

                    if (i == n)
                        result.Add(temp.value);

                    if (temp.Left != null)
                        nodeQueue.Enqueue(temp.Left);

                    if (temp.Right != null)
                        nodeQueue.Enqueue(temp.Right);
                }                
            }

            return result;
        }

        public IList<int> GetLeftTreeView(Node node)
        {
            List<int> result = new List<int>();

            if (node == null)
                return result;

            Queue<Node> nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(node);

            while (nodeQueue.Count != 0)
            {
                int n = nodeQueue.Count;

                for (int i = 1; i <= n; i++)
                {
                    Node temp = nodeQueue.Dequeue();

                    if (i == 1)
                        result.Add(temp.value);

                    if (temp.Left != null)
                        nodeQueue.Enqueue(temp.Left);

                    if (temp.Right != null)
                        nodeQueue.Enqueue(temp.Right);
                }
            }

            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
               /* Input:
                    10
                  /     \
                  2         3
                /   \    /    \
               7     8  12     15
                              /
                            14 */

            Node root = new Node(10);
            root.Left = new Node(2);
            root.Right = new Node(3);
            root.Left.Left = new Node(7);
            root.Left.Right = new Node(8);
            root.Right.Right = new Node(15);
            root.Right.Left = new Node(12);
            root.Right.Right.Left = new Node(14);

            BinaryTree tree = new BinaryTree();

            //Print Right View
            Console.WriteLine("========= Right View of Binary Tree =========");
            PrintView(tree.GetRightTreeView(root));

            //Print Left View
            Console.WriteLine("========= Left View of Binary Tree =========");
            PrintView(tree.GetLeftTreeView(root));
        }

        public static void PrintView(IList<int> nodeList)
        {
            for (int i = 0; i < nodeList.Count; i++)
            {
                Console.WriteLine(nodeList[i].ToString() + " \\");
            }

            Console.ReadKey();
        }
    }
}
