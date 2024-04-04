﻿using System;
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

        public SLL() { }

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

        public void AddFirst(User value)
        {
            //create new node
            Node newNode = new Node(value);
            //place node infront of head
            newNode.next = head;
            //make new node head
            head = newNode;
        }

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

        public void Clear()
        {
            head = null;
        }

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

        public void ReverseOrder()
        {
            // If the head is null, the list is empty.
            if (head == null)
            {
                return;
            }
            else
            {
                // Create some temporary pointers.
                Node walker = head;
                Node tail = null;

                // Check the current size of the list (this needs to be checked outside the loop, as we will increase the size of the list through each iteration and this would cause an error)
                int lengthOfList = Count();

                // Add each node in the list again but flip the order (using AddFirst())
                for (int i = 0; i < lengthOfList; i++)
                {
                    AddFirst(walker.data);
                    walker = walker.next;
                    if (i == 0)
                    {
                        // After the first instance of AddFirst(), the head's position will shift, have the tail point to this new position
                        tail = head;
                    }
                }
                // Now that we have flipped the order, all we have to do is remove the excess nodes, have the tail point to null.
                tail.next = null;
            }
        }

        public void DisplayList()
        {
            if (head == null)
            {
                return;
            }
            else
            {
                Node walker = head;
                while (walker != null)
                {
                    Console.WriteLine(walker.data);
                    walker = walker.next;
                }
            }
        }
    }
}
