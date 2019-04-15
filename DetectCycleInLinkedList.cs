using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleInLinkedList
{
    class Program
    {
        public static LinkedList<string> linkedList = new LinkedList<string> ();

        static void Main(string[] args)
        {
            Initialize();
            Console.WriteLine("LinkedList: ");

            DetectCycle();
            Console.ReadKey();

        }

        public static void Initialize()
        {
            LinkedListNode<string> first = new LinkedListNode<string> ("A");
            LinkedListNode<string> second = new LinkedListNode<string>("B");
            LinkedListNode<string> third = new LinkedListNode<string>("C");
            LinkedListNode<string> fourth = new LinkedListNode<string>("D");
            LinkedListNode<string> fifth = new LinkedListNode<string>("E");

            linkedList.AddFirst(first);
            linkedList.AddAfter(first, second);
            linkedList.AddAfter(second, third);
            linkedList.AddAfter(second, fourth);
            linkedList.AddAfter(third,fifth);
        }

        public static void DetectCycle()
        {
            LinkedListNode<string> slowNode = linkedList.First;
            LinkedListNode<string> fastNode = linkedList.First.Next;

            Console.Write("{0} {1} ", slowNode.Value, fastNode.Value);

            while(slowNode != linkedList.Last && fastNode != null && fastNode.Next != null)
            {
                if (slowNode == fastNode)
                {
                    Console.WriteLine("Cycle detected between Node{0} and Node {1} ", slowNode.Value, fastNode.Value);
                    break;
                }

                if (fastNode.Next.Next != null)
                {
                    slowNode = slowNode.Next;
                    fastNode = fastNode.Next.Next;
                }
                else
                    fastNode = linkedList.First;

                Console.WriteLine("Slow node = {0}, Fast node = {1} ", slowNode.Value, fastNode.Value);
            }
        }
    }
}
