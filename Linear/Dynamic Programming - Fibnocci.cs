using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming_Fibnocci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find Fibnocci series of number: ");
            string input = Console.ReadLine();
            int num = 0;
            Int32.TryParse(input, out num);
            int[] memoize = new int[num + 1];
            int result = Fibnocci(memoize, num);
            Console.WriteLine("Fibnocci({0}) using Memoization = {1}", input.ToString(), result.ToString());
            Console.ReadKey();

            result = BottomupTabulationFibnocci(num);
            Console.WriteLine("Fibnocci({0}) using Tabulation method = {1}", input.ToString(), result.ToString());
            Console.ReadKey();
        }

        public static int Fibnocci(int[] memoize, int n)
        {
            if (n < 2)
                return n;

            // Using DP memoization
            if (memoize[n] != 0)
                return memoize[n];

            memoize[n] =  (Fibnocci(memoize, n - 1) + Fibnocci(memoize, n - 2));
            return memoize[n];
        }

        public static int BottomupTabulationFibnocci(int n)
        {
            int[] result = new int[n + 1];
            result[0] = 0;
            result[1] = 1;

            for (int i = 2; i <= n; i++)
                result[i] = result[i - 1] + result[i - 2];

            return result[n];
        }
    }
}
