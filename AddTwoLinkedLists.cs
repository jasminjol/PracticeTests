using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoLinkedList
{
    public class LinkedListSum
    {
        public LinkedList<int> AddLinkedLists(LinkedList<int> link1, LinkedList<int> link2)
        {
            LinkedList<int> Sum = new LinkedList<int>();

            int carry = 0;
            int temp = 0;
            int maxCount = link1.Count > link2.Count ? link1.Count : link2.Count;

            for (int i = 0; i < maxCount; ++i)
            {
                temp = link1.ElementAtOrDefault(i) + link2.ElementAtOrDefault(i);
                Sum.AddFirst((temp + carry) % 10);
                carry = (temp + carry) / 10;
            }
            return Sum;
        }

        public void PrintLinkedList(LinkedList<int> linkedList)
        {
            foreach (int item in linkedList)
                Console.Write(item + " -> ");

            Console.ReadKey();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> link1 = new LinkedList<int>();
            LinkedList<int> link2 = new LinkedList<int>();

            link1.AddLast(7);
            link1.AddLast(5);
            link1.AddLast(9);
            link1.AddLast(4);
            link1.AddLast(6);

            link2.AddLast(8);
            link2.AddLast(4);

            LinkedListSum linkedListSum = new LinkedListSum();
            LinkedList<int> link3 = linkedListSum.AddLinkedLists(link1, link2);

            linkedListSum.PrintLinkedList(link3);
        }
    }
}
