using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath_Backtracking
{

    public class Maze
    {
        public int Rows = 10;
        public int Cols = 10;

        public int[] xTrav = { -1, 0, 0, 1 };
        public int[] yTrav = { 0, -1, 1, 0 };

        public bool IsValid(int x, int y)
        {
            return ((x >= 0) && (x < Rows) && (y >= 0) && (y < Cols));
        }

        public bool IsSafe(int[,] matrix, int[,] visited, int x, int y)
        {
            return !(matrix[x,y] == 0 || visited[x,y] != 0);
        }

        public int ShortestPath(int[,] matrix, int[,] visited, int i, int j, int x, int y, int minDist, int dist)
        {
            if (i == x && j == y)
                return Math.Min(minDist, dist);

            visited[i, j] = 1;

                if (IsValid(i-1, j) && IsSafe(matrix, visited, i-1, j))
                {
                    minDist = ShortestPath(matrix, visited, i-1, j, x, y, minDist, dist + 1);
                }

            if (IsValid(i, j-1) && IsSafe(matrix, visited, i, j-1))
            {
                minDist = ShortestPath(matrix, visited, i, j - 1, x, y, minDist, dist + 1);
            }

            if (IsValid(i, j+1) && IsSafe(matrix, visited, i, j + 1))
            {
                minDist = ShortestPath(matrix, visited, i, j + 1, x, y, minDist, dist + 1);
            }

            if (IsValid(i + 1, j) && IsSafe(matrix, visited, i + 1, j))
            {
                minDist = ShortestPath(matrix, visited, i + 1, j, x, y, minDist, dist + 1);
            }

            visited[i, j] = 0;

            return minDist;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix =
		{
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

            int[,] visited = new int[10, 10];
            Maze maze = new Maze();

            int result = maze.ShortestPath(matrix, visited, 0, 0, 7, 5, Int32.MaxValue, 0);
            if (result != Int32.MaxValue)
                Console.WriteLine("Shortest path in maze is {0}", result.ToString());
            else
                Console.WriteLine("Shortest path not found");

            Console.ReadLine();
        }
    }
}
