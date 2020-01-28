using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBST
{
    class Program
    {
        static void Main(string[] args)
        {
            Node objNode = new Node(10);
            Console.WriteLine("Root node: " + objNode.data);
            objNode.Insert(5);
            objNode.Insert(15);
            objNode.Insert(2);
            objNode.Insert(11);

            Console.Read();
        }
    }

     class Node
    {
        public Node left;
        public Node right;
        public int data;

        public Node (int value)
        {
            this.data = value;
        }
       

        public void Insert (int value)
        {
            if (value <= data)
            {
                if (left == null)
                    left = new Node(value);
                else
                    left.Insert(value);

                Console.WriteLine("Left Node: " + value);
            }
            else
            {
                if (right == null)
                    right = new Node(value);
                else
                    right.Insert(value);

                Console.WriteLine("Right Node: " +value);
            }

            
        }

        public Boolean Contains(int value)
        {
            if (value == data)
                return true;
            else if (value < data)
            {
                if (left == null)
                    return false;
                else
                    return left.Contains(value);
            }
            else
            {
                if (right == null)
                    return false;
                else
                    return right.Contains(value);
            }
        }

        public void InOrderTraversal()
        {
            if (left != null)
                left.InOrderTraversal();

            Console.WriteLine(data);

            if (right != null)
                right.InOrderTraversal();

        }

    }
}
