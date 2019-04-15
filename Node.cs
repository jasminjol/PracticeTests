using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_and_DFS
{
    public class Node
    {
        public Node left;
        public Node right;
        public string data;

        public Node (string data)
        {
            this.left = null;
            this.right = null;
            this.data = data;
        }

        public Node (string data, Node left, Node right)
        {
            this.left = left;
            this.right = right;
            this.data = data;
        }
    }
}
