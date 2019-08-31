using CashRegister.Helpers;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;

namespace CashRegister.DAL
{
    public class Context
    {

        private static Context instance = new Context();
        private DatabaseContext _context;
        private bool productionEnvironment;

        private Context() { }

        public static Context getInstance()
        {
            return instance;
        }

        public DatabaseContext Get()
        {
            return _context;
        }

        public void setProduction()
        {
            DbConnection connection = new SqlConnection($"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=CashRegister100;Integrated Security=SSPI;AttachDBFilename=" + FolderHelper.GetDBFolder() + @"\CashRegister100.mdf;MultipleActiveResultSets=True");
            if (_context == null)
            {
                productionEnvironment = true;
                _context = new DatabaseContext(connection, productionEnvironment);
                Database.SetInitializer(new DatabaseContextInitialiser());
            }
        }

        public void setTest(DbConnection connection)
        {
            if (_context == null)
            {
                productionEnvironment = false;
                _context = new DatabaseContext(connection, productionEnvironment);
                // Initialising is set from test project
            }
        }

        public bool isProduction()
        {
            return productionEnvironment;
        }

        public bool isTest()
        {
            return !productionEnvironment;
        }
    }
}