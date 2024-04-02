using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    public class SSL : ILinkedListADT
    {
        public Node head;
        public void Add(User value, int index)
        {
            int count = 0;
            Node walker = head;
            while(count < index)
            {
                walker = walker.next;
                count++;
            }
            Node newNode = new Node(value);
            Node after = walker.next;
            walker.next = newNode;
            newNode.next = after;
        }

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

        public void Clear()
        {
            head = null;
        }

        public bool Contains(User value)
        {
            if(head == null)
            {
                return false;
            }
            Node walker = head;
            while(walker.next != null)
            {
                if(walker.data.Equals(value))
                {
                    return true;
                }
                walker = walker.next;
            }
            return false;
        }

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

        public User GetValue(int index)
        {
            int count = 0;
            Node walker = head;
            while (count < index)
            {
                walker = walker.next;
                count++;
            }
            return walker.data;
        }

        public int IndexOf(User value)
        {
          
            Node walker = head;
            int count = 0;
            if(walker.data.Equals(value))
            {
                return count;
            }
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
            if(head == null)
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
