using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixFindAllCommonElementsInAllRows
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = {{1, 2, 5, 4, 3},
                  {9, 7, 8, 5, 1},
                  {8, 7, 5, 3, 1},
                  {8, 1, 2, 7, 5}};

            CommonElements elements = new CommonElements();
            elements.FindCommonElements(matrix);
            Console.ReadLine();
        }
    }

    public class CommonElements
    {
        public static int rows = 4;
        public static int cols = 5;

        public void FindCommonElements(int[,] matrix)
        {
            Dictionary<int, int> commonalities = new Dictionary<int, int>();
            for (int j = 0; j < cols; j++)
            {
                if (!commonalities.ContainsKey(matrix[0, j]))
                    commonalities.Add(matrix[0, j], 1);
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (commonalities.ContainsKey(matrix[i, j]) && commonalities[matrix[i, j]] != i + 1)
                        commonalities[matrix[i, j]] = commonalities[matrix[i, j]] + 1;
                }
            }

            foreach(var item in commonalities)
            {
                if (item.Value == rows)
                    Console.WriteLine(item.Key);
            }
            
        }
    }
}
