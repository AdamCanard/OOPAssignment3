using Assignment3;
using Assignment3.Utility;
using NUnit.Framework.Internal;
using System.Reflection.Metadata;

namespace Assignment3.Tests
{
    internal class SLLTest
    {
        // Create an SLL instance. This list stores User objects to be used in testing.
        private SLL users = new();

        // Runs before each test run. Add initial data for testing to the SLL.
        [SetUp]
        public void Setup()
        {
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        // Runs after each test run. Initializes the state of SLL.
        [TearDown]
        public void Teardown() 
        {
            users.Clear();
        }

        // Test whether the list can be emptied normally.
        [Test]
        public void ClearingSLL()
        {
            users.Clear();
            Assert.AreEqual(true, users.IsEmpty());
        }

        // Test whether the list's elements are counted correctly.
        [Test]
        public void CountingSLL()
        {
            Assert.AreEqual(4, users.Count());
        }

        // Test that we get the correct value at the specified index.
        [Test]
        public void GetValueSLL()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            Assert.AreEqual(test, users.GetValue(0));
        }

        // Tests whether an exception is thrown when the specified index is out of range.
        [Test]
        public void GetValueSLLIndexOutOfRange()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                users.GetValue(20);
            });
        }

        // Test that we are getting the index of a specific value correctly.
        [Test]
        public void GetIndexSLL()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");

            Assert.AreEqual(0, users.IndexOf(test));
        }

        // Test whether an exception is thrown when looking up the index of an element that is not in the list.
        [Test]
        public void GetIndexSLLIndexOutOfRangeException()
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                users.IndexOf(test);
            });
        }

        // Test if an element can be added to the beginning of the list.
        [Test]
        public void SLLAddFirst()
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");
            users.AddFirst(test);
            Assert.AreEqual(test, users.GetValue(0));
        }

        // Test if an element can be added to the end of the list.
        [Test]
        public void SLLAddLast()
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");
            users.AddLast(test);

            int lastIndex = users.Count() - 1;
            Assert.AreEqual(test, users.GetValue(lastIndex));
        }

        // Test if an element can be added at the specified index.
        [Test]
        public void SLLAddAtIndex()
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");
            users.Add(test, 2);

            Assert.AreEqual(test, users.GetValue(2));
        }

        // Tests whether an exception is thrown when attempting to add an element when the specified index is out of range.
        [Test]
        public void SLLAddAtIndexOutOfRange()
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                users.Add(test, 20);
            });
        }

        // Test that the list correctly checks whether it contains a specific element.
        [Test]
        public void SLLContains()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            User test2 = new User(0, "Test Test", "Test@email.com", "TestPassword");

            Assert.AreEqual(true, users.Contains(test));
            Assert.AreEqual(false, users.Contains(test2));
        }

        // Test that the first element of the list is updated as expected after removing the first element.
        [Test]
        public void SLLRemoveFirst()
        {
            User test = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            users.RemoveFirst();
            Assert.AreEqual(test, users.GetValue(0));
            users.DisplayList();
        }

        // After removing the last element of the list, test whether the new last element updates as expected.
        [Test]
        public void SLLRemoveLast()
        {
            User test = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            users.RemoveLast();

            int lastIndex = users.Count() - 1;
            Assert.AreEqual(test, users.GetValue(lastIndex));
            users.DisplayList();
        }

        // Test the ability to remove index 0 (the first element of the list).
        [Test]
        public void SLLRemoveAtIndexZero()
        {
            User test = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            users.Remove(0);
            Assert.AreEqual(test, users.GetValue(0));
            users.DisplayList();
        }

        // Test the ability to remove an element at a specific index from a list.
        [Test]
        public void SLLRemoveAtAnyIndex()
        {
            User test = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            users.Remove(2);
            Assert.AreEqual(test, users.GetValue(2));
            users.DisplayList();
        }

        // Test to see if an IndexOutOfRangeException is thrown when trying to remove an element at an index that is outside the range of the list.
        [Test]
        public void SLLRemoveAtIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                users.Remove(20);
            });
        }

        // Test the ability to replace the element at a specific index in the list with a new element.
        [Test]
        public void SLLReplace() 
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");
            users.Replace(test, 2);
            Assert.AreEqual(test, users.GetValue(2));
            users.DisplayList();
        }

        // Test the ability to reverse the order of the list.
        // After the order is reversed, check whether the element originally in the first position has been moved to the last position in the list.
        [Test]
        public void SLLReverseOrder()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            users.ReverseOrder();

            int lastIndex = users.Count() - 1;
            Assert.AreEqual(test, users.GetValue(lastIndex));
            users.DisplayList();
        }
    }
}
