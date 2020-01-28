using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionMultiplicationUsingShiftOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 20;

            //Multiply by 2
            Console.WriteLine("{0} * 2 = {1}", number, number * 2);
            //Multiply by 2 using Shift
            Console.WriteLine("{0} << 1 = {1}", number, number << 1);

            //Multiply by 8
            Console.WriteLine("{0} * 8 = {1}", number, number * 8);
            //Multiply by 2 using Shift
            Console.WriteLine("{0} << 3 = {1}", number, number << 3);
            Console.ReadKey();

            //Divide by 2
            Console.WriteLine("{0} / 2 = {1}", number, number / 2);
            //Divide by 2 using Shift
            Console.WriteLine("{0} >> 1 = {1}", number, number >> 1);

            //Divide by 8
            Console.WriteLine("{0} / 8 = {1}", number, number / 8);
            //Divide by 2 using Shift
            Console.WriteLine("{0} >> 3 = {1}", number, number >> 3);
            Console.Read();
        }
    }
}
