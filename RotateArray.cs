using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray= new int[6] { 1,2,3,4,5,6 };
            RotateArray(inputArray, 2);
        }

        public static void RotateArray(int[] input, int pivot)
        {
            int[] tempArray = new int[pivot];

            Array.Copy(input, tempArray, pivot);

            int pos = 0;

            int[] target = new int[input.Length];

            for (int i = pivot; i< input.Length; i++)
            {
               target[pos] = input[i];
                pos++;

            }

            Array.Copy(tempArray, 0,  target, target.Length-pivot, pivot);

            for (int len = 0; len < target.Length; len++)
            {
                Console.Write(target[len] + " , ");
            }

            Console.ReadLine();

        }
    }
}
