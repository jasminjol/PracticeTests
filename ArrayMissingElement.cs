using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayMissingElement
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 4, 5, 6, 7, 8, 9, 10 };

            int result = FindMissingElement(arr);
            if (result == 0)
                Console.WriteLine("No missing element");
            else
                Console.WriteLine("Missing element is {0}", result);

            Console.ReadKey();
        }

        // Look for inconsistency: The difference between any element and its index must be arr[0] for every element. arr[i] - i = arr[0]
        // Time Complexity: O(logn)
        public static int FindMissingElement(int[] arrNum)
        {
            int lowIndex = 0;
            int highIndex = arrNum.Length - 1;
            int mid;

            while (lowIndex < highIndex)
            {
                mid = lowIndex + (highIndex - lowIndex) / 2;

                if (arrNum[mid] - mid == arrNum[0])
                {
                    if (arrNum[mid + 1] - arrNum[mid] > 1)
                        return arrNum[mid] + 1;
                    else
                        lowIndex = mid + 1;
                }
                else
                    if (arrNum[mid] - arrNum[mid-1] > 1)
                        return arrNum[mid] - 1;
                    else
                        highIndex = mid - 1;
            }

            return 0;
        }
    }
}
