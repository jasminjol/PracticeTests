using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLToBT
{
    public class Node
    {
        public int data;
        public Node next, prev;

        public Node (int value)
        {
            this.data = value;
            next = prev = null;
        }
    }

    public class DLLToBT
    {
        public static Node head = null;
        public static Node tail = null;
        public static int size = 0;
        public Node root;

        public void add(int data)
        {
            Node node = new Node(data);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                head.prev = node;
                node.next = head;
                head = node;
            }

            size++;
        }
        public Node ConvertToBT(int size)
        {
            if (size <= 0)
                return null;

            Node left = ConvertToBT(size / 2);
            Node root = head;
            root.prev = left;
            head = head.next;
            root.next = ConvertToBT(size - (size / 2) - 1);
            return root;
        }

        public void PrintDLL(Node head)
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data + " -> ");
                current = current.next;
            }
            Console.WriteLine();
        }
        public void PrintInOrder(Node tree)
        {
            if (tree != null)
            {
                PrintInOrder(tree.prev);
                Console.Write(tree.data + " -> ");
                PrintInOrder(tree.next);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DLLToBT dll = new DLLToBT();
            dll.add(7);
            dll.add(6);
            dll.add(5);
            dll.add(4);
            dll.add(3);
            dll.add(2);
            dll.add(1);
            Console.WriteLine("Print DLL");
            Node h = DLLToBT.head;
            dll.PrintDLL(h);
            Console.ReadKey();

            Console.WriteLine("DLL to Binary Tree");
            Node tree = dll.ConvertToBT(DLLToBT.size);
            
            dll.PrintInOrder(tree);
            Console.ReadKey();
        }

    }
}
