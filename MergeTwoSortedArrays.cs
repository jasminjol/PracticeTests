using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoSortedArrays
{
    public class MergeArray
    {
        public int[] MergeUsingLINQ (int[] array1, int[] array2)
        {
            int[] result = array1.Concat(array2).OrderBy(x => x).ToArray();

            return result;
        }
        
        public int[] Merge(int[] array1, int[] array2)
        {
            int a = 0, b = 0;
            int c = 0;

            int count1 = array1.Length;
            int count2 = array2.Length;

            int[] result = new int[count1 + count2];

            while (a < count1 && b < count2)
            {
                if (array1[a] <= array2[b])
                    result[c++] = array1[a++];
                else
                    result[c++] = array2[b++];
            }

            if (a < count1)
            {
                for (int i = a; i < count1; i++)
                    result[c++] = array1[i];
            }
            else if (b < count2)
            {
                for (int j = a; j < count1; j++)
                    result[c++] = array1[j];
            }

            return result;
        }

        public void Print(int[] arr)
        {
            Console.Write(String.Join(",", arr));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 5, 10, 15, 20, 25, 30 };
            int[] array2 = new int[] { 3, 6, 9, 12, 15, 18, 21, 24, 27 };

            MergeArray mergeArray = new MergeArray();

            Console.WriteLine("Merge using LINQ");
            mergeArray.Print(mergeArray.MergeUsingLINQ(array1, array2));
            Console.WriteLine();

            Console.WriteLine("Merge without LINQ");
            mergeArray.Print(mergeArray.Merge(array1, array2));

            Console.ReadKey();
        }
    }
}
