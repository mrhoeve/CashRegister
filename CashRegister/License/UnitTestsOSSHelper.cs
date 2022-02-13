/* 
 * Unittests OSS Helper
 * 
 * Because the unittests are not in this assembly it's not possible to call getOpenSourceInformation.
 * Therefore, we're gonna use this helper file for that sole purpose.
 */

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CashRegister.License
{
    public class UnitTestsOSSHelper: IUsesOSS
    {
        [ExcludeFromCodeCoverage]
        public List<OpenSourceInformation> getOpenSourceInformation()
        {
            return new List<OpenSourceInformation>()
            {
                new OpenSourceInformation("(Test) NUnit", "https://github.com/nunit/nunit", "NUnit.txt"),
                new OpenSourceInformation("(Test) NSubstitute", "https://github.com/nsubstitute/NSubstitute", "NSubstitute.txt"),
                new OpenSourceInformation("(Test) Castle.Core", "http://www.castleproject.org", "CastleCore.txt"),
                new OpenSourceInformation("(Test) Moq", "https://github.com/moq/moq4", "Moq.txt"),
                new OpenSourceInformation("(Test) EntityFramework-Effort", "https://entityframework-effort.net/", "Effort.txt"),
                new OpenSourceInformation("(Test) NMemory", "https://nmemory.net", "NMemory.txt")
            };
        }

    }
}
