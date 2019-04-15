using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_and_DFS
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Node tree = CreateTree();
            Console.WriteLine("------- Breadth First Search --------");
            BFS.BreadthFirstSearch(tree);
            Console.ReadKey();
            Console.WriteLine("------- Depth First Search --------");
            DFS.DepthFirstSearch(tree);
            Console.ReadKey();
        }

        public static Node CreateTree()
        {
            Node tree = new Node("A",
                new Node("B", 
                new Node("C"), new Node("D")),
                new Node("E", 
                new Node("F"), new Node("G", new Node("H"), null)));

            return tree;

        }
    }
}
