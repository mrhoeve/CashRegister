using System;
using System.Deployment.Application;
using System.IO;
using System.Reflection;

namespace CashRegister.Helpers
{
    public static class FolderHelper
    {
        public static String GetDataFolder()
        {
            if(ApplicationDeployment.IsNetworkDeployed)
                return ApplicationDeployment.CurrentDeployment.DataDirectory;
            else
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static String GetDBFolder()
        {
            // Build the folderpath for the database
            String dbFolder = GetDataFolder() + @"\db";
            // Make sure it exists
            Directory.CreateDirectory(dbFolder);
            // Return the path
            return dbFolder;
        }
    }

}
