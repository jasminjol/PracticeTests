using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTopandBottomView
{

    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }

        public Node (int data)
        {
            this.Value = data;
        }
    }
    public class BinaryTreeTopandBottomView
    {
        public Node Root { get; set; }
        public List<int> TopView(Node root)
        {
            int level = 0;
            Dictionary<int, List<int>> verticalHashMap = new Dictionary<int, List<int>>();
            List<int> result = new List<int>();

            CreateVerticalOrder(root, level, verticalHashMap);

            var nodeList = verticalHashMap.Keys.ToList();
            nodeList.Sort();

            foreach(var hash in nodeList)
            {
                result.Add(verticalHashMap[hash].ElementAt(0));
            }

            return result;
        }

        public List<int> BottomView(Node root)
        {
            int level = 0;
            Dictionary<int, List<int>> verticalHashMap = new Dictionary<int, List<int>>();
            List<int> result = new List<int>();

            CreateVerticalOrder(root, level, verticalHashMap);

            var nodeList = verticalHashMap.Keys.ToList();
            nodeList.Sort();

            foreach (var hash in nodeList)
            {
                result.Add(verticalHashMap[hash].LastOrDefault());
            }

            return result;

        }
        public Node CreateVerticalOrder(Node root, int level, Dictionary<int, List<int>> verticalHashMap)
        {
            if (root == null)
                return null;

            if (verticalHashMap.ContainsKey(level))
                verticalHashMap[level].Add(root.Value);
            else
            {
                verticalHashMap.Add(level, new List<int> { root.Value });
            }

            Node node = CreateVerticalOrder(root.Left, --level, verticalHashMap);

            if (node == null)
                level++;
                
            return CreateVerticalOrder(root.Right, ++level, verticalHashMap);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<int> topNodes, bottomNodes;

            BinaryTreeTopandBottomView tree = new BinaryTreeTopandBottomView ();
            tree.Root = new Node(1);
            tree.Root.Left = new Node(2);
            tree.Root.Left.Left = new Node(4)
            {
                Left = new Node(8),
                Right = new Node(9)
            };
            
            tree.Root.Left.Right = new Node(5);
            tree.Root.Right = new Node(3)
            {
                Left = new Node(6),
                Right = new Node(7)
            };

            topNodes = tree.TopView(tree.Root);

            Console.WriteLine("========== Printing Top View ==========");
            for (int i = 0; i < topNodes.Count; i++)
            {
                Console.Write(topNodes[i].ToString() + " -> ");
            }

            bottomNodes = tree.BottomView(tree.Root);

            Console.WriteLine();
            Console.WriteLine("========== Printing Bottom View ==========");
            for (int i = 0; i < bottomNodes.Count; i++)
            {
                Console.Write(bottomNodes[i].ToString() + " -> ");
            }

            Console.ReadKey();

        }
    }
}
