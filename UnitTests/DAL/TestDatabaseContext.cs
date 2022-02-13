using System.Data.Entity;
using CashRegister.DAL;
using Effort;
using Effort.DataLoaders;
using Effort.Provider;
using NUnit.Framework;

namespace UnitTests.DAL
{
    public class TestDatabaseContext
    {
        [SetUp]
        public void Setup()
        {
            Context.getInstance().setTest(DbConnectionFactory.CreateTransient(), new DatabaseContextTestInitialiser());
            // EntityFrameworkEffortManager.ContextFactory = context => Context.getInstance().Get();
            // Database.SetInitializer(new DatabaseContextTestInitialiser());
            Assert.IsTrue(Context.getInstance().isTest());
            Assert.IsFalse(Context.getInstance().isProduction());
        }
    }
}