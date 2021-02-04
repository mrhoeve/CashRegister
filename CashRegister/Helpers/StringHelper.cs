using CashRegister.License;
using NodaMoney;
using System.Collections.Generic;
using System.Globalization;

namespace CashRegister.Helpers
{
    public static class StringHelper
    {
        public static string Normalise(this string str)
        {
            if (str == null) return null;
            return str.Trim().TrimStart(',').TrimEnd(',').Trim();
        }

        public static string ToEuroString(this decimal amount)
        {
            var ci = new CultureInfo("nl-NL");
            var euro = Money.Euro(amount);
            return euro.ToString(ci);
        }
    }
}