using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.License
{
    public sealed class License
    {
        // Make sure we only get one instance of this class
        // See https://stackoverflow.com/questions/6320393/how-to-create-a-class-which-can-only-have-a-single-instance-in-c-sharp
        public static readonly License Registration = new License();

        private SortedList<string, LicenseInformation> licenseInformation;

        private License()
        {
            licenseInformation = new SortedList<string, LicenseInformation>();
        }

        public void Register(string packageName, string URL, string InternalTextFile)
        {
            // Is everything known? So not, throw an error
            if (string.IsNullOrEmpty(packageName) ||
                string.IsNullOrEmpty(URL) ||
                string.IsNullOrEmpty(InternalTextFile)) throw new ArgumentException("Required element not present");
            // Check if the package is already registered
            // If so, we're not going to throw errors because multiple parts can use the same open source software
            if (licenseInformation.ContainsKey(packageName)) return;

            // Register the information
            licenseInformation.Add(packageName,
                new LicenseInformation(packageName, URL, InternalTextFile));
        }

        public IList<string> GetPackages()
        {
            return licenseInformation.Keys;
        }

        public string GetURLForPackage(string packageName)
        {
            if (!licenseInformation.Keys.Contains(packageName)) throw new ArgumentException($"Package name {packageName} not found");
            return licenseInformation[packageName].URL;
        }

        public string GetEmbeddedLicenseFile(string packageName)
        {
            if (!licenseInformation.Keys.Contains(packageName)) throw new ArgumentException($"Package name {packageName} not found");
            var _assembly = Assembly.GetExecutingAssembly();
            string fileContents = "";
            try
            {
                fileContents = new StreamReader(_assembly.GetManifestResourceStream(_assembly.GetManifestResourceNames().Single(str => str.EndsWith(licenseInformation[packageName].txtFile)))).ReadToEnd();
            }
            catch (Exception)
            {
            }
            return fileContents;
        }

        public string GetAssembly()
        {
            return Assembly.GetExecutingAssembly().ToString(); 
        }

        private class LicenseInformation
        {
            public string PackageName;
            public string URL;
            public string txtFile;

            public LicenseInformation(string packageName, string URL, string txtFile)
            {
                this.PackageName = packageName;
                this.URL = URL;
                this.txtFile = txtFile;
            }
        }
    }
}
