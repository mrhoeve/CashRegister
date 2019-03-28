using System;

namespace CashRegister.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime getDate(this DateTime? date)
        {
            return date ?? DateTime.Now;
        }
    }
}