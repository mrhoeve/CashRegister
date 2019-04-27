namespace CashRegister.Helpers
{
    public static class PersoonNaamHelper
    {
        public static string Normalise(this string str)
        {
            if (str == null) return null;
            return str.Trim().TrimStart(',').TrimEnd(',').Trim();
        }
    }
}