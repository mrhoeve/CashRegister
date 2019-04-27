// #define ALWAYSDROP results in dropping the database on the start of the programm
// This gives us the change to work with a new, clean database
// To work with an existing database (if present), just comment the definition out
#define ALWAYSDROP

using CashRegister.DataModels;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace CashRegister.DAL
{
#if (DEBUG && ALWAYSDROP)
    public class DatabaseContextInitialiser : DropCreateDatabaseAlways<DatabaseContext>
#else
    public class DatabaseContextInitialiser : CreateDatabaseIfNotExists<DatabaseContext>
#endif
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            // Aanmaken default administrator
            Persoon administrator = new Persoon()
            {
                Id = 1,
                Achternaam = "Administrator",
                heeftRekening = false,
                AangemaaktOp = DateTime.Now.Date
            };

            context.Persoon.AddOrUpdate(administrator);

            context.SysteemGebruiker.AddOrUpdate(
                new SysteemGebruiker()
                {
                    Persoon = administrator,
                    Wachtwoord = DataModels.SysteemGebruiker.validateAndHashPassword("@dmin7944AM24")
                });

            // Aanmaken standaard producten met huidige prijzen
            Product bier = new Product() { Id = 1, Productomschrijving = "Bier" };
            Product fris = new Product() { Id = 2, Productomschrijving = "Frisdrank" };

            context.Product.AddOrUpdate(bier, fris);

            ProductPrijs bierprijs = new ProductPrijs() { Id = 1, Product = bier, AangemaaktOp = DateTime.Now.Date, GeldigVan = DateTime.Now.Date, Prijs = 1.25m };
            ProductPrijs frisprijs = new ProductPrijs() { Id = 2, Product = fris, AangemaaktOp = DateTime.Now.Date, GeldigVan = DateTime.Now.Date, Prijs = 0.50m };

            context.ProductPrijs.AddOrUpdate(bierprijs, frisprijs);
        }
    }
}