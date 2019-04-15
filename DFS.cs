using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_and_DFS
{
    partial class DFS
    {
        public static void DepthFirstSearch(Node node)
        {
            if (node == null)
                return;

            Console.Write(node.data + " ");

            DepthFirstSearch(node.left);
            DepthFirstSearch(node.right);
        }
    }
}
