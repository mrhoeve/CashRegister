using System;
using System.Collections;
using System.Collections.Generic;
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
            mockProducten();
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

        private void mockProducten()
        {
            // Mock product 1
            ICollection<ProductPrijs> product1Prijzen = new List<ProductPrijs>() { Definitions.product1Prijs1, Definitions.product1Prijs2 };
            Definitions.product1.ProductPrijzen = product1Prijzen;

            // Mock product 2
            ICollection<ProductPrijs> product2Prijzen = new List<ProductPrijs>() { Definitions.product2Prijs1, Definitions.product2Prijs2 };
            Definitions.product2.ProductPrijzen = product2Prijzen;

            var inMemoryProducten = new FakeDbSet<Product>
            {
                Definitions.product1, Definitions.product2
            };

            var inMemoryProductPrijzen = new FakeDbSet<ProductPrijs>
            {
                Definitions.product1Prijs1, Definitions.product1Prijs2,
                Definitions.product2Prijs1, Definitions.product2Prijs2
            };

            mockData.Product.Returns(inMemoryProducten);
            mockData.ProductPrijs.Returns(inMemoryProductPrijzen);
        }
    }
}
