using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelOrderTraversal_BinaryTree
{
    class Program
    {
        public class Node
        {
            public Node left, right = null;
            public int value;

            public Node(int data)
            {
                this.value = data;
            }
        }

        public class BinaryTree
        {
            public Dictionary<int, List<int>> LevelOrderTraversal(Node root)
            {
                Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();

                if (root == null)
                    return result;

                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(root);
                int level = 0;
                while (queue.Count != 0)
                {
                    int levelCount = queue.Count;
                    List<int> values = new List<int>();
       
                    for (int i=0; i < levelCount; i++)
                    {
                        Node node = queue.Dequeue();

                        if (node.left != null)
                            queue.Enqueue(node.left);

                        if (node.right != null)
                            queue.Enqueue(node.right);

                        values.Add(node.value);
                    }
                    result.Add(level, values);
                    level++;
                }
                return result;
            }

            public void PrintLevels(Dictionary<int, List<int>> nodeList)
            {
                foreach (var key in nodeList)
                {
                    Console.Write("Level: " + key.Key);
                    Console.Write(" Values: ");

                    for (int i=0; i < key.Value.Count; i++)
                    {
                        Console.Write(key.Value[i].ToString()+ " -> ");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
        }
        static void Main(string[] args)
        {
           /* Input:
                 10
               /     \
               2         3
             /   \    /    \
            7     8  12     15
                           /
                         14 
          */

            Node root = new Node(10);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(7);
            root.left.right = new Node(8);
            root.right.right = new Node(15);
            root.right.left = new Node(12);
            root.right.right.left = new Node(14);

            BinaryTree tree = new BinaryTree();
            var output = tree.LevelOrderTraversal(root);
            tree.PrintLevels(output);
        }
    }
}
