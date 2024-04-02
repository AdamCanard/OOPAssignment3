using Assignment3;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    internal class SSLTest
    {
        private ILinkedListADT users;
        [SetUp]
        public void Setup()
        {
            users = new SSL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [Test]
        public void ClearingSSL()
        {
            users.Clear();
            Assert.AreEqual(true, users.IsEmpty());
        }

        [Test]
        public void CountingSSL()
        {
            
            Assert.AreEqual(4, users.Count());
        }

        [Test]
        public void GetValueSSL()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            Assert.AreEqual(test, users.GetValue(0));
        }

        [Test]
        public void GetIndexSSL()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            Console.WriteLine(users.IndexOf(test));
            Assert.AreEqual(0, users.IndexOf(test));
        }

        [Test]
        public void SSLAddFirst()
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");
            users.AddFirst(test);
            Assert.AreEqual(test, users.GetValue(0));
        }

        [Test]
        public void SSLAddLast()
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");
            users.AddLast(test);
            // The index of the last node in the list, is one less than then number of nodes in the list
            Assert.AreEqual(test, users.GetValue(users.Count()-1));
        }

    }
}
