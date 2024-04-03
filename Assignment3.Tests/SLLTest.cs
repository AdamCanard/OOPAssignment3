using Assignment3;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    internal class SLLTest
    {
        private ILinkedListADT users;
        [SetUp]
        public void Setup()
        {
            users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        // Test whether the IsEmpty() method works properly when the linked list is emptied.
        [Test]
        public void ClearingSLL()
        {
            users.Clear();
            Assert.AreEqual(true, users.IsEmpty());
        }

        // Test that the number of nodes in the linked list is calculated correctly.
        [Test]
        public void CountingSLL()
        {
            
            Assert.AreEqual(4, users.Count());
        }

        // Test that the value at the given index is returned correctly.
        [Test]
        public void GetValueSLL()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            Assert.AreEqual(test, users.GetValue(0));
        }

        // Test that it correctly returns the index of the given value.
        [Test]
        public void GetIndexSLL()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            users.AddFirst(test);
            Console.WriteLine(users.IndexOf(test));
            Assert.AreEqual(0, users.IndexOf(test));
        }

        // Test whether the method that adds a node to the first of the linked list works correctly.
        [Test]
        public void SLLAddFirst()
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");
            users.AddFirst(test);
            Assert.AreEqual(test, users.GetValue(0));
        }

        // Test whether the method that adds a node to the end of the linked list works correctly.
        [Test]
        public void SLLAddLast()
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");
            users.AddFirst(test);
            Assert.AreEqual(test, users.GetValue(0));
        }

    }
}
