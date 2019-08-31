using System.Data.Entity;
using CashRegister.DAL;
using NUnit.Framework;

namespace UnitTests.DAL
{
    public class TestDatabaseContext
    {
        [SetUp]
        public void Setup()
        {
            Context.getInstance().setTest(Effort.DbConnectionFactory.CreateTransient());
            Database.SetInitializer(new DatabaseContextTestInitialiser());
            Assert.IsTrue(Context.getInstance().isTest());
            Assert.IsFalse(Context.getInstance().isProduction());
        }
    }
}