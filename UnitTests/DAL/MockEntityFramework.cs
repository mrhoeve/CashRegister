using CashRegister.DAL;
using CashRegister.DataModels;
using NSubstitute;
using NUnit.Framework;


// Idea: https://mirkomaggioni.com/2017/08/30/ef-db-context-mock-with-moq/
// Working mock: http://www.nogginbox.co.uk/blog/mocking-entity-framework-data-context
namespace UnitTests.DAL
{
    public class MockEntityFramework
    {
        protected IDatabaseContext mockData;

        [SetUp]
        public void Setup()
        {
            mockData = Substitute.For<IDatabaseContext>();
            mockPersoon();
            mockSysteemGebruiker();
            Context.getInstance().Set(mockData);
        }

        private void mockSysteemGebruiker() { 
            var inMemorySysteemGebruikers = new FakeDbSet<SysteemGebruiker>
            {
                Definitions.localAdminS
            };
            mockData.SysteemGebruiker.Returns(inMemorySysteemGebruikers);
        }

        private void mockPersoon()
        {
            // Add the SysteemGebruiker model to Persoon, just like EF would do normally ;-)
            Persoon persoon = Definitions.localAdminP;
            persoon.SysteemGebruiker = Definitions.localAdminS;

            var inMemoryPersoon = new FakeDbSet<Persoon>
            {
                persoon
            };
            mockData.Persoon.Returns(inMemoryPersoon);
        }
    }
}
