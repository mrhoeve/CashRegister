using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CashRegister.License
{
    public interface IUsesOSS
    {
        List<OpenSourceInformation> getOpenSourceInformation();
    }
}
