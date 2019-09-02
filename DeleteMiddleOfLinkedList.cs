using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteMiddleOfLinkedList
{
    /* Given a singly linked list, delete middle of the linked list. 
      For example, if given linked list is 1->2->3->4->5 then linked list should be modified to 1->2->4->5
       If there are even nodes, then there would be two middle nodes, we need to delete the second middle element. 
       For example, if given linked list is 1->2->3->4->5->6 then it should be modified to 1->2->3->5->6.
        If the input linked list is NULL, then it should remain NULL.
        If the input linked list has 1 node, then this node should be deleted and new head should be returned.
    */
    /* Approach 1 - Delete the node at LinkedListcount/2 + 1
     * Approach 2 - Slow Pointer and Fast Pointer. Delete the Slow pointer node when Fast pointer reaches the end of LinkedList
     */

        public class Node
        {
            public int data;
            public Node next;

            public Node (int data)
            {
                this.data = data;
                this.next = null;
            }
        }

    public class DeleteLinkedList
    {
        // Deletes middle node and returns  
        // head of the modified list  
        public Node deleteMid(Node head)
        {
            // Base cases  
            if (head == null)
                return null;
            if (head.next == null)
            {
                return null;
            }

            // Initialize slow and fast pointers   
            // to reach middle of linked list  
            Node slow_ptr = head;
            Node fast_ptr = head;

            // Find the middle and previous of middle.  
            Node prev = null;

            // To store previous of slow_ptr  
            while (fast_ptr != null &&
                    fast_ptr.next != null)
            {
                fast_ptr = fast_ptr.next.next;
                prev = slow_ptr;
                slow_ptr = slow_ptr.next;
            }

            // Delete the middle node  
            prev.next = slow_ptr.next;

            return head;
        }
        public void printList(Node ptr)
        {
            while (ptr != null)
            {
                Console.Write(ptr.data + "->");
                ptr = ptr.next;
            }
            Console.WriteLine("NULL");
        }

    }


    class Program
    {
        public static void Main(String[] args)
        {
            /* Start with the empty list */
            Node head = new Node(1);
            head.next = new Node(2);
            head.next.next = new Node(3);
            head.next.next.next = new Node(4);
            head.next.next.next.next = new Node(5);
            head.next.next.next.next.next = new Node(6);

            Console.WriteLine("Given Linked List");
            DeleteLinkedList link = new DeleteLinkedList();
            link.printList(head);

            head = link.deleteMid(head);

            Console.WriteLine("Linked List after" +
                                "deletion of middle");
            link.printList(head);
            Console.ReadKey();
        }
    }
    }
