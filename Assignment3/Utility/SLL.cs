using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
        public SLL()
        {
            head = null;
        }

        // Insert the given value into the given index.
        public void Add(User value, int index)
        {
            int count = 0;
            Node walker = head;
            while(count < index)
            {
                walker = walker.next;
            }
            Node newNode = new Node(value);
            Node after = walker.next;
            walker.next = newNode;
            newNode.next = after;
        }

        // Add the given value to the first of the list.
        public void AddFirst(User value)
        {
            if (head == null)
            {
                head = new Node(value);
            }
            else
            {
                Node newNode = new Node(value);
                newNode.next = head;
                head = newNode;
            }
        }

        // Add the given value to the end of the list.
        public void AddLast(User value)
        {
            if (head == null)
            {
                head = new Node(value);
            }
            else
            {
                Node walker = head;
                while (walker.next != null)
                {
                    walker = walker.next;
                }
 
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
            if(head == null)
            {
                return false;
            }
            Node walker = head;
            while(walker.next != null)
            {
                if(walker.next.data == value)
                {
                    return true;
                }
                walker = walker.next;
            }
            return false;
        }

        // Returns the number of nodes in the list.
        public int Count()
        {
            if(head == null)
            {
                return 0;
            }
            Node walker = head;
            int count = 1;
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
            int count = 0;
            Node walker = head;
            while (count < index)
            {
                if (walker == null) 
                    return null; 
                walker = walker.next;
                count++;
            }
            return walker != null ? walker.data : null;
        }

        // Returns the index of the given value.
        public int IndexOf(User value)
        {
          
            Node walker = head;
            int count = 0;
            if(walker.data == value)
            {
                return count;
            }
            while (walker.next != null)
            {
                count++;
                if (walker.next.data == value)
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
            if(head == null)
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
            int count = 0;
            Node walker = head;
            while (count < index-1)
            {
                walker = walker.next;
            }
            Node delete = walker.next;
            Node after = delete.next;
            delete = null;
            walker.next = after;
        }

        // Remove the first node from the list.
        public void RemoveFirst()
        {
            if (head == null)
            {
                return;
            }
            else if (head.next == null)
            {
                head = null;
                
            }
            else
            {
                head = head.next;
                
            }
        }

        // Remove the last node from the list.
        public void RemoveLast()
        {
            if (head == null)
            {
                return;
            }
            else
            {

                Node walker = head;

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
            int count = 0;
            Node walker = head;
            while (count < index)
            {
                walker = walker.next;
            }
            walker.data = value;
        }

    }
}
