using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Helpers
{
    public static class PasswordHelper
    {
        public static void checkValidityWithErrorThrowing(this String str)
        {
            // check if null or empty
            if(string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException("Password is null or empty");
            }
            // check if length is at least 8 characters
            if(str.Length < 8)
            {
                throw new ArgumentException("Password does not meet minimum length");
            }
            // check if it contains at least 1 UPPERCASE, 1 lowercase and 1 numeral
            if(!System.Text.RegularExpressions.Regex.Match(str, @"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$").Success)
            {
                throw new ArgumentException("Password must contain at least 1 UPPERCASE, 1 lowercase and 1 numeral character");
            }
        }

        public static bool isValid(this String str)
        {
            try
            {
                str.checkValidityWithErrorThrowing();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
