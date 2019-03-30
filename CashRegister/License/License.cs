using CashRegister.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CashRegister.License
{
    public sealed class License
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private SortedList<string, OpenSourceInformation> licenseInformation = new SortedList<string, OpenSourceInformation>();

        // Make sure we only get one instance of this class
        // See https://stackoverflow.com/questions/6320393/how-to-create-a-class-which-can-only-have-a-single-instance-in-c-sharp
        // Make sure we initialise this as the last initialisation of this class!
        // The logger i.e. must be initialised first to prevent NPE's.
        public static readonly License Registration = new License();

        private License()
        {
            generateList();
            if (licenseInformation.Count != 0)
                logger.Debug($"This application uses {licenseInformation.Count} Open Source software projects.");
        }

        public Object getInstance()
        {
            return Registration;
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
                using (StreamReader reader = new StreamReader(_assembly.GetManifestResourceStream(_assembly.GetManifestResourceNames().Single(str => str.EndsWith(licenseInformation[packageName].InternalTextFile)))))
                {
                    fileContents = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(InvalidOperationException))
                    logger.Error($"InvalidOperationException: is the Build Action of file {licenseInformation[packageName].InternalTextFile} set to Embedded Resource?");
            }
            return fileContents;
        }

        public string GetAssembly()
        {
            return Assembly.GetExecutingAssembly().ToString();
        }

        private void generateList()
        {
            StringBuilder stringBuilder = new StringBuilder();
            LicenseHelper licenseHelper = new LicenseHelper();
            List<OpenSourceInformation> osiList;
            IUsesOSS usesOSS;

            // First, get the non-singletons
            foreach (Type type in licenseHelper.usesOSS)
            {
                usesOSS = (IUsesOSS)Activator.CreateInstance(type);
                stringBuilder.Clear();
                stringBuilder.Append($"{type.Name} provided the following OSS:");
                osiList = usesOSS.getOpenSourceInformation();
                foreach (OpenSourceInformation osi in osiList)
                {
                    stringBuilder.Append($" {osi.packageName}");
                    if (!licenseInformation.Keys.Contains(osi.packageName))
                        licenseInformation.Add(osi.packageName, osi);
                }
                logger.Debug(stringBuilder.ToString());
            }
        }
    }
}
