using System.Data.Entity;
using CashRegister.DataModels;

namespace CashRegister.DAL
{
    public interface IDatabaseContext
    {
        IDbSet<Persoon> Persoon { get; set; }
        IDbSet<SysteemGebruiker> SysteemGebruiker { get; set; }
        IDbSet<Product> Product { get; set; }
        IDbSet<ProductPrijs> ProductPrijs { get; set; }

    }
}