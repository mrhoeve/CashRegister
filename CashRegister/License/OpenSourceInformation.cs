using System.Collections.Generic;

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

    public static class OpenSourceInformationHelper
    {
        public static List<OpenSourceInformation> singleList(this OpenSourceInformation osi)
        {
            return new List<OpenSourceInformation> { osi };
        }
    }
}
