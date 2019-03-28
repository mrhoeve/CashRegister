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
            Product product1 = new Product() {Id = 1, Productomschrijving = "Product 1"};
            ProductPrijs product1Prijs1 = new ProductPrijs()
            {
                Id = 1,
                ProductId = product1.Id,
                Product = product1,
                Prijs = 1.50m,
                GeldigVan = DateTime.UtcNow.AddMonths(-1),
                GeldigTot = DateTime.Now.AddDays(-1),
                AangemaaktOp = DateTime.UtcNow.AddMonths(-1)
            };
            ProductPrijs product1Prijs2 = new ProductPrijs()
            {
                Id = 2,
                ProductId = product1.Id,
                Product = product1,
                Prijs = 2.00m,
                GeldigVan = DateTime.UtcNow,
                AangemaaktOp = DateTime.UtcNow.AddDays(-1)
            };
            ICollection<ProductPrijs> product1Prijzen = new List<ProductPrijs>() { product1Prijs1, product1Prijs2};
            product1.ProductPrijzen = product1Prijzen;

            // Mock product 2
            Product product2 = new Product() { Id = 2, Productomschrijving = "Product 2" };
            ProductPrijs product2Prijs1 = new ProductPrijs()
            {
                Id = 3,
                ProductId = product2.Id,
                Product = product2,
                Prijs = 3.00m,
                GeldigVan = DateTime.UtcNow.AddMonths(-1),
                GeldigTot = DateTime.Now.AddDays(-1),
                AangemaaktOp = DateTime.UtcNow.AddMonths(-1)
            };
            ProductPrijs product2Prijs2 = new ProductPrijs()
            {
                Id = 4,
                ProductId = product2.Id,
                Product = product2,
                Prijs = 4.00m,
                GeldigVan = DateTime.UtcNow,
                AangemaaktOp = DateTime.UtcNow.AddDays(-1)
            };
            ICollection<ProductPrijs> product2Prijzen = new List<ProductPrijs>() { product2Prijs1, product2Prijs2 };
            product2.ProductPrijzen = product1Prijzen;

            var inMemoryProducten = new FakeDbSet<Product>
            {
                product1, product2
            };

            var inMemoryProductPrijzen = new FakeDbSet<ProductPrijs>
            {
                product1Prijs1, product1Prijs2,
                product2Prijs1, product2Prijs2
            };

            mockData.Product.Returns(inMemoryProducten);
            mockData.ProductPrijs.Returns(inMemoryProductPrijzen);
        }
    }
}
