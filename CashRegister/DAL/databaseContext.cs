using CashRegister.DataModels;
using CashRegister.Helpers;
using CashRegister.Model;
using NLog;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace CashRegister.DAL
{
    public class DatabaseContext : DbContext
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IDbSet<Persoon> Persoon { get; set; }
        public IDbSet<SysteemGebruiker> SysteemGebruiker { get; set; }
        public IDbSet<Product> Product { get; set; }
        public IDbSet<ProductPrijs> ProductPrijs { get; set; }
        public IDbSet<Transactie> Transactie { get; set; }

        public DatabaseContext(DbConnection connection, bool logging = false) : base(connection, true)
        {
            if (logging)
            {
                String dbFolder = FolderHelper.GetDBFolder();
                logger.Debug($"Location of database: { dbFolder }");
                Database.Log = s => logger.Trace(s);
                logger.Trace($"Database connection string: {Database.Connection.ConnectionString}");
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // To prevent pluralization of tablenames, we specify them specifically
            // There's no way to do it with the old modelBuilder.Conventions.Remove<PluralizingTableNameConvention>() in newer versions of .NET Core
            // See https://stackoverflow.com/questions/37493095/entity-framework-core-rc2-table-name-pluralization
            modelBuilder.Entity<Persoon>()
                .ToTable("Persoon")
                .HasOptional(p => p.SysteemGebruiker)
                .WithRequired(s => s.Persoon);
            modelBuilder.Entity<SysteemGebruiker>().ToTable("SysteemGebruiker");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductPrijs>()
                .ToTable("ProductPrijs")
                .HasRequired(p => p.Product);
            modelBuilder.Entity<Transactie>().ToTable("Transactie");
        }

        public override int SaveChanges()
        {
            Persoon currentUser = CurUser.get().isLoggedIn() ? CurUser.get().getCurrentUser() : null;

            var persoonsWijzigingen = ChangeTracker.Entries()
                .Where(e => e.Entity is Persoon)
                .Where(e => e.State != EntityState.Detached && e.State != EntityState.Unchanged);

            foreach (var entry in persoonsWijzigingen)
            {
                var currentDateTime = DateTime.Now;
                var persoon = entry.Entity as Persoon;
                // Als de persoon is toegevoegd zetten we de datum en tijd
                // en de user die de bewerking heeft uitgevoerd
                if (entry.State == EntityState.Added)
                {
                    persoon.AangemaaktOp = currentDateTime;
                    if(currentUser != null) persoon.AangemaaktDoor = currentUser;
                }
                // De gegevens zetten we altijd
                persoon.GewijzigdOp = currentDateTime;
                if(currentUser != null) persoon.GewijzigdDoor = currentUser;
                // Indien een persoon verwijderd wordt, dan doen we dit niet echt
                // We zetten het record om naar Modified en vullen de relevante velden
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    persoon.VerwijderdOp = currentDateTime;
                    if(currentUser != null) persoon.VerwijderdDoor = currentUser;
                }
            }

            var productprijzenToegevoegd = ChangeTracker.Entries()
                .Where(e => e.Entity == ProductPrijs)
                .Where(e => e.State == EntityState.Added);

            foreach (var entry in productprijzenToegevoegd)
            {
                var productPrijs = entry.Entity as ProductPrijs;
                productPrijs.AangemaaktOp = DateTime.Now.Date;
            }
            return base.SaveChanges();
        }
    }
}
