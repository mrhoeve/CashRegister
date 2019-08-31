using CashRegister.DataModels;
using CashRegister.Model;
using NUnit.Framework;
using System;
using System.Linq;
using UnitTests.DAL;

namespace UnitTests.DataModels
{
    [TestFixture]
    public class ProductTest : TestDatabaseContext
    {
        [Test]
        public void TestProduct1Combinations()
        {
            Product p = Assortiment.getInstance().GetProducten().First();
            Assert.IsTrue(Definitions.product1.Productomschrijving.Equals(p.Productomschrijving));
            Assert.AreEqual(Definitions.product1Prijs2.Prijs, p.getProductPrijs().Prijs);
            Assert.AreEqual(Definitions.product1Prijs1.Prijs, p.getProductPrijs(DateTime.Now.AddDays(-14)).Prijs);
            Assert.AreEqual(null, p.getProductPrijs(DateTime.Now.AddYears(-14)));
        }

        [Test]
        public void TestNonExistingProduct()
        {
            Product p = Assortiment.getInstance().GetProducten()
                .Where(pr => pr.Productomschrijving == "Niet bestaand product")
                .SingleOrDefault();
            Assert.IsNull(p);
        }

        [Test]
        public void TestProduct2Combinations()
        {
            Product p = Assortiment.getInstance().GetProducten().Where(pr => pr.Id == 2).SingleOrDefault();
            Assert.IsTrue(Definitions.product2.Productomschrijving.Equals(p.Productomschrijving));
            Assert.AreEqual(Definitions.product2Prijs2.Prijs, p.getProductPrijs().Prijs);
            Assert.AreEqual(Definitions.product2Prijs1.Prijs, p.getProductPrijs(DateTime.Now.AddDays(-14)).Prijs);
            Assert.AreEqual(null, p.getProductPrijs(DateTime.Now.AddYears(-14)));
        }
    }
}