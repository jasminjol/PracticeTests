using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathinMaze_BFS
{

    public class Node
    {
        public int x;
        public int y;
        public int dist; // Distance from source cell

        public Node(int i, int j, int value)
        {
            this.x = i;
            this.y = j;
            this.dist = value;
        }
    }

    public class Maze
    {
        public static readonly int Rows = 10;
        public static readonly int Cols = 10;

        public static int[] xTrav = { -1,  0, 0, 1};
        public static int[] yTrav = { 0, -1, 1, 0 };

        public bool IsValidPath(int[,] matrix, bool[,] visited, int x, int y)
        {
            return ((x >= 0) && (x < Rows) && (y >= 0) && (y < Cols) && !visited[x, y] && matrix[x, y] == 1);
        }

        public int ShortestPath(int[,] matrix, int i, int j, int x, int y)
        {
            bool[,] visited = new bool[Rows, Cols];
            Queue<Node> queue = new Queue<Node>();
            int minDist = Int32.MaxValue;

            queue.Enqueue(new Node(i, j, 0));
            visited[i, j] = true;

            while (queue.Count != 0)
            {
                Node node = queue.Dequeue();

                i = node.x;
                j = node.y;
                int dist = node.dist;

                if ((i == x) && (j == y))
                {
                    minDist = dist;
                    return minDist;
                }

                for (int k=0; k<4; k++)
                {
                    if (IsValidPath(matrix, visited, i + xTrav[k], j + yTrav[k]))
                    {
                        visited[i + xTrav[k], j + yTrav[k]] = true;
                        queue.Enqueue(new Node(i + xTrav[k], j + yTrav[k], dist+1));
                    }
                }
            }

            return minDist;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = {
        { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 },
        { 0, 1, 1, 1, 1, 1, 0, 1, 0, 1 },
        { 0, 0, 1, 0, 1, 1, 1, 0, 0, 1 },
        { 1, 0, 1, 1, 1, 0, 1, 1, 0, 1 },
        { 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
        { 1, 0, 1, 1, 1, 0, 0, 1, 1, 0 },
        { 0, 0, 0, 0, 1, 0, 0, 1, 0, 1 },
        { 0, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
        { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 },
        { 0, 0, 1, 0, 0, 1, 1, 0, 0, 1 },
        };

            Maze maze = new Maze();
            int result = maze.ShortestPath(matrix, 0, 0, 7, 5);

            if (result == Int32.MaxValue)
                Console.WriteLine("Shortest path not found");
            else
                Console.WriteLine("Shortest path in given maze is {0}", result.ToString());

            Console.ReadLine();
        }
    }
}
