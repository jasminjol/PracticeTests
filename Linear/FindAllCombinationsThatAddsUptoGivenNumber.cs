    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> result = new List<IList<int>>();
        List<int> combination = new List<int>();
        Array.Sort(candidates);
        CombinationSum(result, candidates, combination, target, 0);
        return result;
    }

    private void CombinationSum(IList<IList<int>> result, int[] candidates, IList<int> combination, int target, int start)
    {
        if (target == 0)
        {
            result.Add(new List<int>(combination));
            return;
        }

        for (int i = start; i != candidates.Length && target >= candidates[i]; ++i)
        {
            combination.Add(candidates[i]);
            CombinationSum(result, candidates, combination, target - candidates[i], i);
            combination.Remove(combination.Last());
        }
    }



Solution #2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllCombinationsThatAddsUptoGivenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            findCombinations(n);
            Console.ReadKey();
        }

        /* Function to find out all  
combinations of positive  
numbers that add upto given  
number. It uses findCombinationsUtil() */
        public static void findCombinations(int n)
        {
            // array to store the combinations  
            // It can contain max n elements  
            int[] arr = new int[n];

            // find all combinations  
            findCombinationsUtil(arr, 0, n, n);
        }

        /* arr - array to store the  
combination  
index - next location in array  
num - given number  
reducedNum - reduced number */
        public static void findCombinationsUtil(int[] arr, int index,
                                         int num, int reducedNum)
        {
            // Base condition  
            if (reducedNum < 0)
                return;

            // If combination is  
            // found, print it  
            if (reducedNum == 0)
            {
                for (int i = 0; i < index; i++)
                    Console.Write(arr[i] + " ");
                Console.WriteLine();
                return;
            }

            // Find the previous number  
            // stored in arr[]. It helps  
            // in maintaining increasing  
            // order  
            int prev = (index == 0) ? 1 : arr[index - 1];

            // note loop starts from  
            // previous number i.e. at  
            // array location index - 1  
            for (int k = prev; k <= num; k++)
            {
                // next element of  
                // array is k  
                arr[index] = k;

                // call recursively with  
                // reduced number  
                findCombinationsUtil(arr, index + 1, num,
                                         reducedNum - k);
            }
        }
    }
}
