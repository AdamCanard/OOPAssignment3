// 2024-04-04
// Group 1:  Adam Cunard, Simon Luna, Tyler Meekel, Sunhee Ku
//This SLL class implements a singly linked list, in which nodes containing data are connected in one direction.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [DataContract]
    public class SLL : ILinkedListADT
    {
        [DataMember]
        public Node head;

        // Constructor of the SLL class. Initialize head.
        public SLL() { }

        // Insert the given value into the given index.
        public void Add(User value, int index)
        {
            //make sure index is in range
            if (index < 0 || index > Count())
            {
                throw new IndexOutOfRangeException();
            }

            //create new node
            int count = 0;
            Node walker = head;
            Node newNode = new Node(value);

            //if index is head, return head
            if (index == 0)
            {
                newNode.next = walker;
                head = newNode;
            }
            else
            {
                //set previous node
                Node previous = null;
                //loop index times
                while (count < index)
                {
                    //increment both node
                    previous = walker;
                    walker = walker.next;
                    count++;
                }

                //place new node at index
                previous.next = newNode;
                newNode.next = walker;
            }
        }

        // Add the given value to the first of the list.
        public void AddFirst(User value)
        {
            //create new node
            Node newNode = new Node(value);
            //place node infront of head
            newNode.next = head;
            //make new node head
            head = newNode;
        }

        // Add the given value to the end of the list.
        public void AddLast(User value)
        {
            //if list is empty
            if (head == null)
            {
                //make head new node
                head = new Node(value);
            }
            else
            {
                //loop until the end of the list
                Node walker = head;
                while (walker.next != null)
                {
                    walker = walker.next;
                }
                //create new node and place after the list
                Node newNode = new Node(value);
                walker.next = newNode;
            }
        }

        // Empty the list.
        public void Clear()
        {
            head = null;
        }

        // Returns whether the list contains a specific value.
        public bool Contains(User value)
        {
            //if list is empty, return false
            if (head == null)
            {
                return false;
            }
            Node walker = head;
            //loop through list
            while (walker.next != null)
            {
                //if node equal parameter, return true
                if (walker.data.Equals(value))
                {
                    return true;
                }
                walker = walker.next;
            }
            //else return false
            return false;
        }

        // Returns the number of nodes in the list.
        public int Count()
        {
            //if list is empty return 0
            if (head == null)
            {
                return 0;
            }
            Node walker = head;
            int count = 1;
            //increase count for every node in list
            while (walker.next != null)
            {
                count++;
                walker = walker.next;
            }
            return count;
        }

        // Returns the value of the node at the given index.
        public User GetValue(int index)
        {
            //index range checkd
            if (index < 0 || index > Count() - 1)
            {
                throw new IndexOutOfRangeException();
            }

            int count = 0;
            Node walker = head;
            //loop until index node
            while (count < index)
            {
                walker = walker.next;
                count++;
            }
            return walker.data;
        }

        // Returns the index of the given value.
        public int IndexOf(User value)
        {
            //if list is empty throw exception
            if (head == null)
            {
                throw new IndexOutOfRangeException();
            }

            Node walker = head;
            int count = 0;
            //if head equals parameter
            if (walker.data.Equals(value))
            {
                return count;
            }
            //loop list until node equals parameter 
            while (walker.next != null)
            {
                count++;
                if (walker.data.Equals(value))
                {
                    return count;
                }
                walker = walker.next;
            }

            throw new IndexOutOfRangeException();
        }

        // Returns whether the list is empty.
        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Remove the node at the given index.
        public void Remove(int index)
        {
            //index range check
            if (index < 0 || index > Count() - 1)
            {
                throw new IndexOutOfRangeException();
            }
            //if index 0, move head forward
            if (index == 0)
            {
                head = head.next;
                return;
            }

            int count = 0;
            Node walker = head;
            //loop until index node
            while (count < index - 1)
            {
                walker = walker.next;
                count++;
            }
            //remove node
            Node delete = walker.next;
            Node after = delete.next;

            walker.next = after;
        }

        // Remove the first node from the list.
        public void RemoveFirst()
        {
            if (head == null)
            {
                return;
            }
            else
            {
                head = head.next;

            }
        }

        // Remove the last node from the list.
        public void RemoveLast()
        {
            //if list is empty return
            if (head == null)
            {
                return;
            }
            else
            {

                Node walker = head;
                //find the last node
                for (int i = 0; i < this.Count() - 2; i++)
                {
                    walker = walker.next;
                }
                walker.next = null;

            }
        }

        // Replaces the value of the node at the given index with the given value.
        public void Replace(User value, int index)
        {
            //index range check
            if (index < 0 || index > Count() - 1)
            {
                throw new IndexOutOfRangeException();
            }

            int count = 0;
            Node walker = head;
            //find index node
            while (count < index)
            {
                walker = walker.next;
                count++;
            }
            //replace value of node
            walker.data = value;
        }

        // This method reverses the order of the linked list.
        public void ReverseOrder()
        {
            // If the head is null, the list is empty.
            if (head == null)
            {
                return;
            }
            else
            {
                // Traverse the list using the walker variable.
                Node walker = head;
                Node tail = null;

                // Calculate the length of the list.
                int lengthOfList = Count();

                // Iterate through all nodes in the list and add each node to the front of the list.
                // Through this process, the order of the list is reversed.
                for (int i = 0; i < lengthOfList; i++)
                {
                    AddFirst(walker.data);
                    walker = walker.next;
                    if (i == 0)
                    {
                        // In the first iteration, set the new tail (the head of the original list).
                        tail = head;
                    }
                }
                // Set next of the last node to null to mark the end of the list.
                tail.next = null;
            }
        }

        // This method prints all elements of the linked list to the console.
        public void DisplayList()
        {
            // Check if the list is empty. If empty, it returns without doing anything.
            if (head == null)
            {
                return;
            }
            else
            {
                // Traverse the list using the walker variable.
                Node walker = head;
                while (walker != null)
                {
                    // Print the data of the node pointed to by the current walker to the console.
                    Console.WriteLine(walker.data);
                    // Move the walker to the next node.
                    walker = walker.next;
                }
            }
        }
    }
}
