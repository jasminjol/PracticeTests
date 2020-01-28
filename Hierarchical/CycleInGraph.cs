using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleInGraph
{
    public class Node
    {
        public string Value;
        public List<Node> Edges;

        public Node(string value)
        {
            Value = value;
            Edges = new List<Node>();
        }
        public void AddEdge(Node n)
        {
            Edges.Add(n);
        }
    }
    public class Graph
    {
        public List<Node> Nodes;

        public bool HasCycle()
        {
            if (Nodes == null || !Nodes.Any()) return false;

            var visitedNodes = new HashSet<Node>();
            var completedNodes = new HashSet<Node>();

            foreach (Node n in Nodes)
            {
                if (HasCycleDfs(n, visitedNodes, completedNodes))
                    return true;
            }
            return false;
        }

        private static bool HasCycleDfs(Node node, HashSet<Node> visitedNodes, HashSet<Node> completedNodes)
        {

            if (visitedNodes.Contains(node))
            {
                if (completedNodes.Contains(node))
                    return false;
                return true;
            }
            visitedNodes.Add(node);

            foreach (Node n in node.Edges)
            {
                if (HasCycleDfs(n, visitedNodes, completedNodes))
                    return true;
            }

            completedNodes.Add(node);
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node a1 = new Node("a1");
            Node a2 = new Node("a2");
            Node a3 = new Node("a3");
            Node a4 = new Node("a4");
            Node b1 = new Node("b1");
            Node b2 = new Node("b2");
            Node b3 = new Node("b3");

            var graph = new Graph();
            graph.Nodes = new List<Node>() { a1, a2, a3, a4, b1, b2, b3 };
            a1.AddEdge(a2);
            a1.AddEdge(a3);
            a2.AddEdge(a3);
            a3.AddEdge(a4);
            a3.AddEdge(b1);
            a3.AddEdge(a1); // Create a back edge (cycle)
            a4.AddEdge(b1);

            if (graph.HasCycle())
                Console.WriteLine("Cycle Detected in Graph");
            else

                Console.WriteLine("No Cycle in Graph");

            Console.ReadLine();
        }
    }
}
