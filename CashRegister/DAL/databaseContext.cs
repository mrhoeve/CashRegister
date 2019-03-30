using CashRegister.DataModels;
using System;
using System.Data.Entity;
using System.Linq;

namespace CashRegister.DAL
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public IDbSet<Persoon> Persoon { get; set; }
        public IDbSet<SysteemGebruiker> SysteemGebruiker { get; set; }
        public IDbSet<Product> Product { get; set; }
        public IDbSet<ProductPrijs> ProductPrijs { get; set; }

        public DatabaseContext() : base("CashRegister100")
        {

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

        }

        public override int SaveChanges()
        {
            var entriesAdded = ChangeTracker.Entries()
                .Where(e => e.Entity == Persoon)
                .Where(e => e.State == EntityState.Added);

            foreach (var entry in entriesAdded)
            {
                var persoon = entry.Entity as Persoon;
                persoon.AangemaaktOp = DateTime.UtcNow;
            }

            var productPrijzen = ChangeTracker.Entries()
                .Where(e => e.Entity == ProductPrijs)
                .Where(e => e.State == EntityState.Added);

            foreach (var entry in productPrijzen)
            {
                var productPrijs = entry.Entity as ProductPrijs;
                productPrijs.AangemaaktOp = DateTime.Now;
            }
            return base.SaveChanges();
        }

        public override string ToString()
        {
            return "DatabaseContext";
        }
    }
}
