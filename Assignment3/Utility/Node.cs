using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [DataContract]
    public class Node
    {
        [DataMember]
        public User data;
        [DataMember]
        public Node next;

        public Node() { }

        public Node(User data)
        {
            this.data = data;
            next = null;
        }
    }
}
