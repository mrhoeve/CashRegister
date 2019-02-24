using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CashRegister.License;

namespace CashRegister.Helpers
{
    public class LicenseHelper
    {
        public IEnumerable<Type> usesOSS { get; private set; }

        public LicenseHelper()
        {
            usesOSS = GetTypesWithUsesOSSInterface();
        }

        public IEnumerable<Type> GetTypesWithUsesOSSInterface()
        {

            Type parentType = typeof(IUsesOSS);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            return types.Where(t => t.GetInterfaces().Contains(parentType));

        }
    }
}
