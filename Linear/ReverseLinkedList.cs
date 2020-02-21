using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkList = new LinkedList();
            linkList.AddNode(new Node(1));
            linkList.AddNode(new Node(2));
            linkList.AddNode(new Node(3));
            linkList.AddNode(new Node(4));
            linkList.AddNode(new Node(5));

            Console.WriteLine("Original LinkedList");
            linkList.Print();
            Console.WriteLine();

            linkList.Reverse();
            Console.WriteLine("Reversed LinkedList");
            linkList.Print();

            Console.ReadLine();
        }
    }

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

    public class LinkedList
    {
        Node head;
        public void AddNode(Node node)
        {
            if (head == null)
                head = node;
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = node;
            }
        }

        public void Reverse()
        {
            Node next, prev = null;
            Node current = head;

            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

        public void Print()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + "->");
                temp = temp.next;
            }
        }
    }
    
}
