using CashRegister.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegister.DataModels
{
    public class SysteemGebruiker
    {
        [Key, ForeignKey("Persoon")]
        public int PersoonId { get; set; }
        public virtual Persoon Persoon { get; set; }
        // Wachtwoord: tenminste een UPPERCASE, lowercase en een getal.
        // Overige validaties via de methode om het wachtwoord te zetten
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain at least 1 UPPERCASE, 1 lowercase and 1 numeral character")]        // See https://stackoverflow.com/questions/8699033/password-dataannotation-in-asp-net-mvc-3 (1 upper, 1 lower, 1 numeric)
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        public bool isPasswordCorrect(String password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(Wachtwoord)) return false;
            return this.Wachtwoord.Equals(password);
        }

        public static string validateAndHashPassword (string password)
        {
            return (password.isValid() ? password : "");
        }
    }
}
