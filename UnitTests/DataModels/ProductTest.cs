using System;
using System.Linq;
using CashRegister.DataModels;
using CashRegister.Model;
using NUnit.Framework;
using UnitTests.DAL;

namespace UnitTests.DataModels
{
    [TestFixture]
    public class ProductTest : MockEntityFramework
    {
        [Test]
        public void Test()
        {
            Product p = Assortiment.getInstance().GetProducten().First();
            Assert.IsTrue("Product 1".Equals(p.Productomschrijving));
            Assert.AreEqual(2.00m, p.getProductPrijs().Prijs);
            Assert.AreEqual(1.50m, p.getProductPrijs(DateTime.Now.AddDays(-14)).Prijs);

            Product r = Assortiment.getInstance().GetProducten().Where(pr => pr.Id == 2).SingleOrDefault();
            Assert.IsTrue("Product 2".Equals(r.Productomschrijving));
            Assert.AreEqual(4.00m, r.getProductPrijs().Prijs);
            Assert.AreEqual(3.0m, r.getProductPrijs(DateTime.Now.AddDays(-14)).Prijs);
        }
    }
}