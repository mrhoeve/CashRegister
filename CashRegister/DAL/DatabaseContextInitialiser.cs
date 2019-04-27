using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using CashRegister.DataModels;

namespace CashRegister.DAL
{
#if DEBUG
    public class DatabaseContextInitialiser : DropCreateDatabaseAlways<DatabaseContext>
#else
    public class DatabaseContextInitialiser : CreateDatabaseIfNotExists<DatabaseContext>
#endif
    {
        protected override void Seed(DatabaseContext context)
        {
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

            base.Seed(context);
        }
    }
}