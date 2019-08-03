using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array3SUM
{
    public class Triplet
    {
        public void find3Numbers(int[] A, int arr_size, int sum)
        {
            int l, r;

            /* Sort the elements */
            Array.Sort(A);

            //Check if arr[0] + arr[1] + arr[length-2] = arr[length-1]
            //if sum < arr[length-1], then increment arr[1] by 1
            //if sum > arr[length-1], then decrement arr[length-2] by 1 
            //Continue till sum found. Else, return false
            for (int i = 0; i < arr_size - 2; i++)
            {
                l = i + 1;
                r = arr_size - 1;
                while (l < r)
                {
                    if (A[i] + A[l] + A[r] == sum)
                    {
                        Console.WriteLine("Triplet is " + A[i] + ", " + A[l] + ", " + A[r]);
                        return;
                    }
                    else if (A[i] + A[l] + A[r] < sum)
                        l++;

                    else 
                        r--;
                }
            }
            Console.WriteLine("Triplet not found ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Triplet triplet = new Triplet();
            int[] arr = new int[] { 1, 4, 45, 6, 10, 8 };
            int sum = 20;
            //int sum = 30; // case of Triplet not found
            int count = arr.Length;

            triplet.find3Numbers(arr, count, sum);
            Console.ReadLine();
        }
    }
}
