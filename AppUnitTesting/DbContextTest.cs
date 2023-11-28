using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TicketingApp.Models.Context;
using MySqlConnector;

namespace AppUnitTesting
{
    [TestFixture]
    public class DbContextTest
    {
        private DbContext context;
        private MySqlConnection connTest;

        [SetUp]
        public void Init()
        {
            context = new DbContext();
            connTest = new MySqlConnection();
        }

        [Test]
        public void TestConnection()
        {
            Assert.IsInstanceOf<MySqlConnection>(context.Conn, "It should member of MySqlConnector");
        }

        [Test]
        public void TestDispose()
        {
            Assert.AreEqual(connTest.State, context.Conn);
        }
    }
}
