/* 
 * Unittests OSS Helper
 * 
 * Because the unittests are not in this assembly it's not possible to call getOpenSourceInformation.
 * Therefore, we're gonna use this helper file for that sole purpose.
 */

using System.Collections.Generic;

namespace CashRegister.License
{
    public class UnitTestsOSSHelper: IUsesOSS
    {
        public List<OpenSourceInformation> getOpenSourceInformation()
        {
            return new List<OpenSourceInformation>()
            {
                new OpenSourceInformation("NUnit", "https://github.com/nunit/nunit", "NUnit.txt"),
                new OpenSourceInformation("NSubstitute", "https://github.com/nsubstitute/NSubstitute", "NSubstitute.txt")
            };
        }

    }
}
