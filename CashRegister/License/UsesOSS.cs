using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.License
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=true)]
    public class UsesOSS : Attribute
    {
        private string packageName;
        private string URL;
        private string InternalTextFile;

        public UsesOSS(string packageName, string URL, string InternalTextFile)
        {
            License.Registration.Register(packageName, URL, InternalTextFile);
        }
    }
}
