using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    // Make the class serializable using the data contract.
    // This allows Node objects to be transmitted over the network or stored in files.
    [DataContract]
    public class Node
    {
        // Use data member properties to ensure that the data field is included in serialization.
        // This field stores data held by Node, in this case it is an object of type User.
        [DataMember]
        public User data;

        // Use data member properties to ensure that the next field is included in serialization.
        // This field is used to point to the next Node in the linked list.
        // If this Node is the last in the list, next has the value null.
        [DataMember]
        public Node next;

        // This is the default constructor. This constructor is used when creating a Node object.
        // The default constructor initializes data and next to default values (null).
        public Node() { }

        // Constructor that takes parameters. It receives User type data and creates a Node object.
        // This constructor is used to initialize the data that Node will have.
        // The next field is set to null by default, i.e. it is assumed that there will be no next Node when this Node is created.
        public Node(User data)
        {
            this.data = data;
            next = null;
        }
    }
}
