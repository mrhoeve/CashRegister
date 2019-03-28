using CashRegister.DataModels;
using CashRegister.Model;
using NUnit.Framework;
using System;
using System.Linq;
using UnitTests.DAL;

namespace UnitTests.DataModels
{
    [TestFixture]
    public class ProductTest : MockEntityFramework
    {
        [Test]
        public void TestProduct1Combinations()
        {
            Product p = Assortiment.getInstance().GetProducten().First();
            Assert.IsTrue("Product 1".Equals(p.Productomschrijving));
            Assert.AreEqual(2.00m, p.getProductPrijs().Prijs);
            Assert.AreEqual(1.50m, p.getProductPrijs(DateTime.Now.AddDays(-14)).Prijs);
            Assert.AreEqual(null, p.getProductPrijs(DateTime.Now.AddYears(-14)));
        }

        [Test]
        public void TestNonExistingProduct()
        {
            Product q = Assortiment.getInstance().GetProducten()
                .Where(pr => pr.Productomschrijving == "Niet bestaand product")
                .SingleOrDefault();
            Assert.IsNull(q);
        }

        [Test]
        public void TestProduct2Combinations()
        {
            Product r = Assortiment.getInstance().GetProducten().Where(pr => pr.Id == 2).SingleOrDefault();
            Assert.IsTrue("Product 2".Equals(r.Productomschrijving));
            Assert.AreEqual(4.00m, r.getProductPrijs().Prijs);
            Assert.AreEqual(3.0m, r.getProductPrijs(DateTime.Now.AddDays(-14)).Prijs);
            Assert.AreEqual(null, r.getProductPrijs(DateTime.Now.AddYears(-14)));
        }
    }
}