using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_and_DFS
{
    public class BFS
    {
        public static void BreadthFirstSearch(Node node)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                Console.Write(node.data + " ");

                if (node.left != null)
                    queue.Enqueue(node.left);

                if (node.right != null)
                    queue.Enqueue(node.right);
            }
        }
    }
}
