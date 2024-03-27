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
                if(walker.next.data == value)
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
            }
            return walker.data;
        }

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
    }
}
