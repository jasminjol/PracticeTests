using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDupCharsFromString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = String.Join("", input.Distinct());
            Console.WriteLine("String with duplicate characters removed - " + output);
            Console.ReadLine();
        }
    }
}
