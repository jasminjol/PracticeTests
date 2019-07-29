using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyUnixLikePath
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = "/a/./b/./c/./d/"; // " / a//b//c//////d";  " / a/./b/../../c/";
            Console.WriteLine("Simplified path = " +Simplify(path));
            Console.ReadKey();
        }

        public static string Simplify(String path)
        {
            String simplifiedPath = "/";
            int count = path.Length;
           Stack<string> first = new Stack<string>();

            for (int i = 0; i < count; i++)
            {
                String temp = "";

                while (i < count && path[i] == '/')
                    i++;

                while (i < count && path[i] != '/')
                {
                    temp += path[i];
                    i++;
                }

                if (temp.Equals(".."))
                {
                    if (first.Count != 0)
                        first.Pop();
                }
                else if (temp.Equals("."))
                    continue;

                else if (temp.Length != 0)
                    first.Push(temp);
            }

            Stack<string> second = new Stack<string>();

            while (first.Count != 0)
                second.Push(first.Pop());

            while (second.Count != 0)
            {
                if (second.Count != 1)
                    simplifiedPath += second.Pop() + "/";
                else
                    simplifiedPath += second.Pop();
            }

            return simplifiedPath;
        }
    }
}
