using CashRegister.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.DAL
{
    class databaseContext : DbContext
    {
        public DbSet<Persoon> Persoon { get; set; }
        public DbSet<SysteemGebruiker> SysteemGebruiker { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // To prevent pluralization of tablenames, we specify them specifically
            // There's no way to do it with the old modelBuilder.Conventions.Remove<PluralizingTableNameConvention>() in newer versions of .NET Core
            // See https://stackoverflow.com/questions/37493095/entity-framework-core-rc2-table-name-pluralization
            modelBuilder.Entity<Persoon>().ToTable("Persoon");
            modelBuilder.Entity<SysteemGebruiker>().ToTable("SysteemGebruiker");
        }
    }
}
