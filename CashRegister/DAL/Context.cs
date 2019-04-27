using CashRegister.DataModels;
using System.Data.Entity;

namespace CashRegister.DAL
{
    public class Context : IDatabaseContext
    {
        public IDbSet<Persoon> Persoon { get; set; }
        public IDbSet<SysteemGebruiker> SysteemGebruiker { get; set; }
        public IDbSet<Product> Product { get; set; }
        public IDbSet<ProductPrijs> ProductPrijs { get; set; }

        private static Context instance = new Context();
        private IDatabaseContext _context;

        private Context() { }

        public static Context getInstance()
        {
            return instance;
        }

        public IDatabaseContext Get()
        {
            return _context;
        }

        public void Set(IDatabaseContext context)
        {
            if (_context == null)
                _context = context;
        }

    }
}