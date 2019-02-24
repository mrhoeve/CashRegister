using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.License
{
    public class OpenSourceInformation
    {
        public string packageName { get; private set; }
        public string URL { get; private set; }
        public string InternalTextFile { get; private set; }

        public OpenSourceInformation(string packageName, string URL, string InternalTextFile)
        {
            this.packageName = packageName;
            this.URL = URL;
            this.InternalTextFile = InternalTextFile;
        }
    }
}
