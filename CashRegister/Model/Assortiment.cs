using System.Collections;
using System.Linq;
using CashRegister.DataModels;
using CashRegister.DAL;
using System.Collections.Generic;

namespace CashRegister.Model
{
    public sealed class Assortiment
    {
        // Make sure we only get one instance of this class
        // See https://stackoverflow.com/questions/6320393/how-to-create-a-class-which-can-only-have-a-single-instance-in-c-sharp
        private static readonly Assortiment instance = new Assortiment();
        private IDatabaseContext _context;

        private Assortiment() { }

        public ICollection<Product> GetProducten()
        {
            if (_context == null) getContext();
            return _context.Product.OrderBy(p => p.Productomschrijving).ToList();
        }

        public static Assortiment getInstance()
        {
            return instance;
        }

        private void getContext()
        {
            _context = Context.getInstance().Get();
        }

    }
}