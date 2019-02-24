using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Helpers;

namespace CashRegister.License
{
    public sealed class License
    {
        // Make sure we only get one instance of this class
        // See https://stackoverflow.com/questions/6320393/how-to-create-a-class-which-can-only-have-a-single-instance-in-c-sharp
        public static readonly License Registration = new License();

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private SortedList<string, OpenSourceInformation> licenseInformation;

        private License()
        {
            licenseInformation = new SortedList<string, OpenSourceInformation>();
            generateList();
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
            Console.WriteLine($"Package: {packageName}");
            if (!licenseInformation.Keys.Contains(packageName)) throw new ArgumentException($"Package name {packageName} not found");
            var _assembly = Assembly.GetExecutingAssembly();
            string fileContents = "";
            try
            {
                using (StreamReader reader = new StreamReader(_assembly.GetManifestResourceStream(_assembly.GetManifestResourceNames().Single(str => str.EndsWith(licenseInformation[packageName].InternalTextFile))))) {
                    fileContents = reader.ReadToEnd();
                    Console.WriteLine(fileContents);
                }
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(InvalidOperationException))
                    logger.Error($"InvalidOperationException: is the Build Action of file {licenseInformation[packageName].InternalTextFile} set to Embedded Resource?");
            }
            Console.WriteLine($"{fileContents}");
            return fileContents;
        }

        public string GetAssembly()
        {
            return Assembly.GetExecutingAssembly().ToString(); 
        }

        private void generateList()
        {
            LicenseHelper licenseHelper = new LicenseHelper();
            OpenSourceInformation osi;
            foreach(Type type in licenseHelper.usesOSS)
            {
                IUsesOSS usesOSS = (IUsesOSS)Activator.CreateInstance(type);
                osi = usesOSS.getOpenSourceInformation();
                licenseInformation.Add(osi.packageName, osi);
            }
            //foreach(IUsesOSS usesOSS in licenseHelper.usesOSS)
            //{
            //}

        }
    }
}
