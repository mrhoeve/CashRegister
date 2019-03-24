/* 
 * License OSS Helper
 * 
 * Because License is a singleton it's not possible to call getOpenSourceInformation.
 * Therefore, we're gonna use this helper file for that sole purpose.
 */

using System.Collections.Generic;

namespace CashRegister.License
{
    class LicenseOSSHelper : IUsesOSS
    {
        public List<OpenSourceInformation> getOpenSourceInformation()
        {
            return new OpenSourceInformation("NLog", "https://github.com/NLog/NLog", "NLog.txt").singleList();
        }

    }
}
