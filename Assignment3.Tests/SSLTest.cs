using Assignment3;
using Assignment3.Utility;
using NUnit.Framework.Internal;
using System.Reflection.Metadata;

namespace Assignment3.Tests
{
    internal class SSLTest
    {
        private SSL users = new();

        [SetUp]
        public void Setup()
        {
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void Teardown() 
        {
            users.Clear();
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
        public void GetValueSSLIndexOutOfRange()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                users.GetValue(20);
            });
        }

        [Test]
        public void GetIndexSSL()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");

            Assert.AreEqual(0, users.IndexOf(test));
        }

        [Test]
        public void GetIndexSSLIndexOutOfRangeException()
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                users.IndexOf(test);
            });
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

            int lastIndex = users.Count() - 1;
            Assert.AreEqual(test, users.GetValue(lastIndex));
        }

        [Test]
        public void SSLAddAtIndex()
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");
            users.Add(test, 2);

            Assert.AreEqual(test, users.GetValue(2));
        }

        [Test]
        public void SSLAddAtIndexOutOfRange()
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                users.Add(test, 20);
            });
        }

        [Test]
        public void SSLContains()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            User test2 = new User(0, "Test Test", "Test@email.com", "TestPassword");

            Assert.AreEqual(true, users.Contains(test));
            Assert.AreEqual(false, users.Contains(test2));
        }

        [Test]
        public void SSLRemoveFirst()
        {
            User test = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            users.RemoveFirst();
            Assert.AreEqual(test, users.GetValue(0));
            users.DisplayList();
        }

        [Test]
        public void SSLRemoveLast()
        {
            User test = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            users.RemoveLast();

            int lastIndex = users.Count() - 1;
            Assert.AreEqual(test, users.GetValue(lastIndex));
            users.DisplayList();
        }

        [Test]
        public void SSLRemoveAtIndexZero()
        {
            User test = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            users.Remove(0);
            Assert.AreEqual(test, users.GetValue(0));
            users.DisplayList();
        }

        [Test]
        public void SSLRemoveAtAnyIndex()
        {
            User test = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            users.Remove(2);
            Assert.AreEqual(test, users.GetValue(2));
            users.DisplayList();
        }

        [Test]
        public void SSLRemoveAtIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                users.Remove(20);
            });
        }

        [Test]
        public void SSLReplace() 
        {
            User test = new User(0, "Test Test", "Test@email.com", "TestPassword");
            users.Replace(test, 2);
            Assert.AreEqual(test, users.GetValue(2));
            users.DisplayList();
        }

        [Test]
        public void SSLReverseOrder()
        {
            User test = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            users.ReverseOrder();

            int lastIndex = users.Count() - 1;
            Assert.AreEqual(test, users.GetValue(lastIndex));
            users.DisplayList();
        }
    }
}
