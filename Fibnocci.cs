using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibnocci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            int prev = 0;
            int next = 1;

            Console.Write("{0} {1}", prev, next);

            do
            {
                number = prev + next;
                Console.Write(" {0}", number);
                prev = next;
                next = number;
            } while (number < 100);

            Console.ReadKey();
        }
    }
}
