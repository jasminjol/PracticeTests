using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList___PrintLastKNodes
{

    public class Node
    {
        public int data;
        public Node next;

        public Node(int value)
        {
            this.data = value;
            next = null;
        }
    }

    public class PrintK
    {
        int c = 0;

        public void PrintKNodes(Node head, int k)
        {
            if (head == null)
                return;

            PrintKNodes(head.next, k);
            c++;

            if (c <= k)
                Console.Write(head.data + " -> ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node(10);
            head.next = new Node(20);
            head.next.next = new Node(30);
            head.next.next.next = new Node(40);
            head.next.next.next.next = new Node(50);

            PrintK printK = new PrintK();
            printK.PrintKNodes(head, 3);
            Console.ReadKey();
        }
    }
}
