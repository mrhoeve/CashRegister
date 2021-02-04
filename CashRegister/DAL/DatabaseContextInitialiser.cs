// #define ALWAYSDROP results in dropping the database on the start of the programm
// This gives us the change to work with a new, clean database
// To work with an existing database (if present), just comment the definition out
#define ALWAYSDROP

using CashRegister.DataModels;
using CashRegister.Helpers;
using NLog;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CashRegister.DAL
{
#if DEBUG && ALWAYSDROP
    public class DatabaseContextInitialiser : DropCreateDatabaseAlways<DatabaseContext>
#else
    public class DatabaseContextInitialiser : CreateDatabaseIfNotExists<DatabaseContext>
#endif
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            // Aanmaken SYSTEM account
            Persoon systemAccount = new Persoon()
            {
                Id = 1,
                Achternaam = "SYSTEM",
                heeftRekening = false,
                AangemaaktOp = DateTime.Now,
                GewijzigdOp = DateTime.Now
            };
            context.Persoon.AddOrUpdate(systemAccount);
            context.SaveChanges();
            systemAccount.AangemaaktDoor = systemAccount;
            systemAccount.GewijzigdDoor = systemAccount;
            context.Persoon.AddOrUpdate(systemAccount);
            logger.Debug($"Systemaccount {systemAccount.GetVolledigeNaam()} created");

            // Aanmaken default administrator
            Persoon administrator = new Persoon()
            {
                Achternaam = "Administrator",
                heeftRekening = false,
                AangemaaktOp = DateTime.Now,
                AangemaaktDoor = systemAccount,
                GewijzigdOp = DateTime.Now,
                GewijzigdDoor = systemAccount
            };

            context.Persoon.AddOrUpdate(administrator);
            logger.Debug($"Administratoraccount {administrator.GetVolledigeNaam()} created");

#if DEBUG
            // Aanmaken klant, alleen in debug
            Persoon klant = new Persoon()
            {
                Voornaam = "Klant",
                Achternaam = "Klant",
                heeftRekening = true,
                AangemaaktOp = DateTime.Now,
                AangemaaktDoor = systemAccount,
                GewijzigdOp = DateTime.Now,
                GewijzigdDoor = administrator
            };

            context.Persoon.AddOrUpdate(klant);
            logger.Debug($"Account {klant.GetVolledigeNaam()} created");
#endif

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
            context.SaveChanges();

            context.ProductPrijs.ToList().ForEach(p => logger.Debug($"Product {p.Product.Productomschrijving} met prijs {p.Prijs.ToEuroString()} toegevoegd."));
        }
    }
}