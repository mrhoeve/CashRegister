using CashRegister.License;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            Type typeIUsessOSS = typeof(IUsesOSS);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            return types.Where(t => t.GetInterfaces().Contains(typeIUsessOSS));
        }
    }

}
