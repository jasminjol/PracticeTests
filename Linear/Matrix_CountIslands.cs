using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_CountIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
                    {
                       { 1, 0, 1, 0, 0, 0, 1, 1, 1, 1 },
                       { 0, 0, 1, 0, 1, 0, 1, 0, 0, 0 },
                       { 1, 1, 1, 1, 0, 0, 1, 0, 0, 0 },
                       { 1, 0, 0, 1, 0, 1, 0, 0, 0, 0 },
                       { 1, 1, 1, 1, 0, 0, 0, 1, 1, 1 },
                       { 0, 1, 0, 1, 0, 0, 1, 1, 1, 1 },
                       { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0 },
                       { 0, 0, 0, 1, 0, 0, 1, 1, 1, 0 },
                       { 1, 0, 1, 0, 1, 0, 0, 1, 0, 0 },
                       { 1, 1, 1, 1, 0, 0, 0, 1, 1, 1 },
                    };
            int X = 10;
            int Y = 10;

            CountIsland obj = new CountIsland();
            int islands = 0;
            bool[,] processed = new bool[X, Y];

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if (!processed[i, j] && matrix[i,j] == 1)
                    {
                        obj.BFS(matrix, i, j, processed);
                        islands++;
                    }
                }
            }
            Console.WriteLine("Number of islands : {0}", islands);
            Console.ReadKey();
        }
    }

    public class Cell
    {
        public int x;
        public int y;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }

    public class CountIsland
    {
        private static readonly int[] row = { -1, -1, -1, 0, 0, 1, 1, 1 };
        private static readonly int[] col = { -1, 0, 1, -1, 1, -1, 0, 1 };

        public bool IsValidPath(int[,] matrix, int x, int y, bool[,] processed)
        {
            return ((x >= 0) && (x < 10) && (y >= 0) && (y < 10) && (matrix[x, y] == 1) && !processed[x, y]);
        }

        public void BFS(int[,] matrix, int x, int y, bool[,] processed)
        {
            Queue<Cell> queue = new Queue<Cell>();

            processed[x, y] = true;
            queue.Enqueue(new Cell(x, y));

            while (queue.Count > 0)
            {
                int p = queue.Peek().x;
                int q = queue.Peek().y;
                queue.Dequeue();

                for (int k = 0; k < 8; k++)
                {
                    if (IsValidPath(matrix, p + row[k], q + col[k], processed))
                    {
                        processed[p + row[k], q + col[k]] = true;
                        queue.Enqueue(new Cell(p + row[k], q + col[k]));
                    }
                }
            }
        }
    }
}
