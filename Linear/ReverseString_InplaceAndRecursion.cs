using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString_Inplace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string to be reversed");
            string str = Console.ReadLine();
            Console.WriteLine("Reversed string is " + ReverseString(str));
            Console.WriteLine("Reversed string using recursion is " + ReverseStringRecurse(str));
            Console.ReadKey();
        }

        public static string ReverseString(string input)
        {
            char[] result = new char[input.Length];

            for (int i=0, j=input.Length-1; i < input.Length - 1; i++, j--)
            {
                result[i] = input[j];
                result[j] = input[i];
            }

            return new string(result);
        }

        private static string ReverseStringRecurse(string str)
        {
            if (str.Length <= 1)
                return str;

            return ReverseStringRecurse(str.Substring(1)) + str[0];
        }
    }
}
