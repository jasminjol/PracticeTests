using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linkedlist1 = new LinkedList<string>();
            LinkedListNode<string> node1 = new LinkedListNode<string>("A");
            LinkedListNode<string> node2 = new LinkedListNode<string>("B");
            LinkedListNode<string> node3 = new LinkedListNode<string>("C");

            linkedlist1.AddFirst(node1);
            linkedlist1.AddAfter(node1, node2);
            linkedlist1.AddLast(node3);

            LinkedList<string> linkedlist2 = new LinkedList<string>();
            LinkedListNode<string> node4 = new LinkedListNode<string>("D");
            LinkedListNode<string> node5 = new LinkedListNode<string>("E");
            LinkedListNode<string> node6 = new LinkedListNode<string>("F");

            linkedlist2.AddFirst(node4);
            linkedlist2.AddAfter(node4, node5);
            linkedlist2.AddLast(node6);

            // Using Concat
            Console.WriteLine("Merge LinkedLists using Concat");
            MergeUsingConcat(linkedlist1, linkedlist2);
            Console.ReadKey();

            //Using Loop
            Console.WriteLine("Merge LinkedLists using Loop");
            MergeUsingLoop(linkedlist1, linkedlist2);
            Console.ReadKey();
        }

        public static void MergeUsingConcat(LinkedList<string> linkedlist1, LinkedList<string> linkedlist2)
        {          
           var linkedlist3 = new LinkedList<string>(linkedlist1.Concat(linkedlist2));

            foreach (string value in linkedlist3)
            {
                Console.WriteLine(value);
            }
        }

        public static void MergeUsingLoop(LinkedList<string> linkedlist1, LinkedList<string> linkedlist2)
        {
            foreach (string value in linkedlist2)
            {
                linkedlist1.AddLast(value);
            }

            foreach (string value in linkedlist1)
            {
                Console.WriteLine(value);
            }
        }
    }
}
