/* 
 * License OSS Helper
 * 
 * Because License is a singleton it's not possible to call getOpenSourceInformation.
 * Therefore, we're gonna use this helper file for that sole purpose.
 */

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CashRegister.License
{
    class LicenseOSSHelper : IUsesOSS
    {
        [ExcludeFromCodeCoverage]
        public List<OpenSourceInformation> getOpenSourceInformation()
        {
            return new List<OpenSourceInformation>
            {
                new OpenSourceInformation("NLog", "https://github.com/NLog/NLog", "NLog.txt"),
                new OpenSourceInformation("GitVersion.MsBuild", "https://github.com/GitTools/GitVersion", "GitVersion.MsBuild.txt"),
                new OpenSourceInformation("NodaMoney", "https://www.nodamoney.org/", "NodaMoney.txt")
            };
        }

    }
}
