using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModArithmetic
{
    class Program
    {
        static int aModm(string a, int m)
        {
            int number = 0;
            for (int i = 0; i < a.Length; i++)
            {
                number = (number * 10);
                int x = (int)(a[i] - '0');
                number = number + x;
                number %= m;
            }
            return number;
        }

        //Calculate (a^b)%m, where a is a very large number
        //Approach - (a%m)*(a%m) ....(a%m) b times
        static int Calculate(string a, int b, int m)
        {
            // Find a%m 
            int result = aModm(a, m);
            int mul = result;

            // multiply ans by b-1 times  
            // and take mod with m 
            for (int i = 1; i < b; i++)
                result = (result * mul) % m;

            return result;
        }
        static void Main(string[] args)
        {
            string a = "25567";
            int b = 2, m = 10;
            Console.WriteLine("Using modular arithmetic -> " + Calculate(a, b, m));
            Console.WriteLine("Using normal calc -> " + Math.Pow(int.Parse(a), b) % m);
            Console.ReadKey();
        }
    }
}
