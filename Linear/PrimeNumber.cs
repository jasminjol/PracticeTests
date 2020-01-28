using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prime numbers: ");
            for (int i = 2; i < 50; i++)
            {
                if (IsPrime(i))
                    Console.WriteLine( i + " ");
            }

            Console.ReadKey();
        }

        public static bool IsPrime(int number)
        {
            if (number == 0)
                return false;

            int modVal = 0;
            bool isPrime = true;

            for (int i = 2; i < number; i++)
            {
                modVal = number % i;

                if (modVal == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }
    }
}
