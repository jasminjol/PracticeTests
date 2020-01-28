using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythagoreanTriplet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 1, 4, 6, 5 };

            if (IsPythagoreanTriplet(numbers))
                Console.WriteLine("The array has Pythagorean Triplet");
            else
                Console.WriteLine("The array does not have Pythagorean Triplet");

            Console.ReadKey();
        }

        //a^2 + b^2 = c^2
        public static Boolean IsPythagoreanTriplet(int[] arr)
        {
            int l = arr.Length;

            //Square the elements
            for (int i = 0; i < l; i++)
            {
                arr[i] = arr[i] * arr[i];
            }

            //Sort the squared values
            Array.Sort(arr);

            // Return true if sum of 1st and 2nd last = last element
            // Else, if sum of 1st and 2nd last < last element, then increment position a 
            // Else, decrease position b
            //Repeat
            for (int i = l - 1; i >= 2; i--)
            {
                int a = 0;
                int b = i - 1;
 
                while (a < b)
                {
                    if (arr[a] + arr[b] == arr[i])
                    {
                        Console.WriteLine("Triplet values = {0} + {1} = {2}", arr[a], arr[b], arr[i]);
                        return true;
                    }

                    else
                    {
                        if (arr[a] + arr[b] < arr[i])
                            a++;
                        else
                            b--;
                    }
                }

            }
            return false;
        }
    }
}
