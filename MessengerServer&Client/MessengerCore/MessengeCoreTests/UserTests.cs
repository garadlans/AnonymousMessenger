using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerCoreLib;
using NUnit.Framework;

namespace MessengeCoreTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CreateUser()
        {
            var user = new User(1, true, "admin");
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("admin", user.Username);
            Assert.AreEqual(true, user.Online);
        }

        //[Test]
        //public void Equals()
        //{
        //    var user1 = new User(1, true, "admin");
        //    var user2 = new User(1, true, "admin");
        //    Assert.IsTrue(user1.Equals(user2));
        //}

        [Test]
        public void _GetHashCode()
        {
            var user = new User(1, true, "admin");
            Assert.AreEqual(60881849, user.GetHashCode());
        }
    }
}
