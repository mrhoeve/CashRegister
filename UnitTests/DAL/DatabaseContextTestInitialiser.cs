using CashRegister.DAL;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace UnitTests.DAL
{
    class DatabaseContextTestInitialiser : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            // Aanmaken default administrator
            context.Persoon.AddOrUpdate(Definitions.localAdminP);

            context.SysteemGebruiker.AddOrUpdate(
                Definitions.localAdminS);

            context.Product.AddOrUpdate(Definitions.product1, Definitions.product2);

            context.ProductPrijs.AddOrUpdate(
                Definitions.product1Prijs1, Definitions.product1Prijs2,
                Definitions.product2Prijs1, Definitions.product2Prijs2);
        }
    }
}