namespace CashRegister.DAL
{
    public class Context
    {
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