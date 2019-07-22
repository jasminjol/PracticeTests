using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateMatrixBy90degrees
{
    public class Matrix
    {
        int rows = 4;
        int cols = 4;
        public void Transpose(int[,] arr)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = i; j < cols; j++)
                {
                    int temp = arr[j, i];
                    arr[j, i] = arr[i, j];
                    arr[i, j] = temp;
                }
            }

        }

        public void ReverseColumns(int[,] arr)
        {
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0, k = cols - 1; j < k; j++, k--)
                {
                    int temp = arr[j, i];
                    arr[j, i] = arr[k, i];
                    arr[k, i] = temp;
                }
            }
        }

        public void PrintMatrix(int[,] arr)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = { { 10, 20, 30, 40 },
                        { 50, 60, 70, 80 },
                        { 90, 100, 110, 120 },
                        { 130, 140, 150, 160 } };

            Matrix matrix = new Matrix();
            Console.WriteLine("Matrix before rotation");
            matrix.PrintMatrix(arr);

            matrix.Transpose(arr);
            Console.WriteLine("Matrix after Transpose");
            matrix.PrintMatrix(arr);

            matrix.ReverseColumns(arr);

            Console.WriteLine("Matrix after rotation");
            matrix.PrintMatrix(arr);
        }
    }
}
