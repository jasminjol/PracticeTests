using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    public class Node
    {
        public int key;
        public int value;
        public Node prev;
        public Node next;

        public Node(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }

    public class LRUCache
    {
        private Dictionary<int, Node> dict = new Dictionary<int, Node>();
        private Node head, tail;
        private int capacity;

        public void AddNode(Node node)
        {
            capacity++;
            if (head == null && tail == null)
            {
                head = tail = node;
                return;
            }

            node.next = head;
            head.prev = node;
            head = node;
        }

        public void RemoveNode(Node node)
        {
            if (head == null || node == null)
            {
                return;
            }
            capacity--;
            if (head == tail && head == node)
            {
                head = tail = null;
                return;
            }

            if (head == node)
            {
                head = head.next;
                head.prev = null;
                return;
            }

            if (tail == node)
            {
                tail = tail.prev;
                tail.next = null;
                return;
            }

            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        public void MoveFirst(Node node)
        {
            RemoveNode(node);
            AddNode(node);
        }

        public void RemoveLast()
        {
            RemoveNode(tail);
        }

        public int Get(int key)
        {
            if (dict.ContainsKey(key))
            {
                Node node = dict[key];
                MoveFirst(node);
                return node.value;
            }
            return -1;
        }

        public void Set(int key, int value)
        {
            if (dict.ContainsKey(key))
            {
                Node node = dict[key];
                MoveFirst(node);
                node.value = value;
                return;
            }

            if (dict.Count >= capacity)
            {
                RemoveLast();
                dict.Remove(tail.key);
            }

            Node newNode = new Node(key, value);
            AddNode(newNode);
            dict.Add(key, newNode);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
