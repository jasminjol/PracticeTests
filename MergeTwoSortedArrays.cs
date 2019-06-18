using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoSortedArrays
{
    public class MergeArray
    {
        public int[] Merge (int[] array1, int[] array2)
        {
            int[] result = array1.Concat(array2).OrderBy(x => x).ToArray();

            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 5, 10, 15, 20, 25, 30 };
            int[] array2 = new int[] { 3, 6, 9, 12, 15, 18, 21, 24, 27 };

            MergeArray mergeArray = new MergeArray();
            int[] array3 = mergeArray.Merge(array1, array2);

            Console.Write(String.Join(",", array3));
            Console.ReadKey();
        }
    }
}
