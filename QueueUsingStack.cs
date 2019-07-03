using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingStack
{
    class Program
    {
        public static Stack<int> S1 = new Stack<int>();
        public static Stack<int> S2 = new Stack<int>();
        static void Main(string[] args)
        {
            Enqueue(1);
            Enqueue(2);
            Enqueue(3);
            Enqueue(4);
            Enqueue(5);

            Console.WriteLine("Stack count: " + S1.Count);

            Console.WriteLine("1st Dequeue: " + Dequeue());
            Console.WriteLine("2nd Dequeue: " + Dequeue());
            Console.WriteLine("3rd Dequeue: " + Dequeue());
            Console.WriteLine("4th Dequeue: " + Dequeue());
            Console.WriteLine("5th Dequeue: " + Dequeue());
            Console.WriteLine("6th Dequeue: " + Dequeue());
            Enqueue(6);
            Console.WriteLine("7th Dequeue: " + Dequeue());
            Console.ReadKey();
        }

        public static void Enqueue(int value)
        {
            S1.Push(value);
        }

        public static int Dequeue()
        {
            if (S2.Count == 0)
            {
                while (S1.Count > 1)
                {
                    S2.Push(S1.Pop());
                }
                return S1.Count > 0 ? S1.Pop() : 0;
            }

                return S2.Count > 0 ? S2.Pop() : 0;
        }
    }
}
