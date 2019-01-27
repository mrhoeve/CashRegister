using CashRegister.Helpers;
using Isopoh.Cryptography.Argon2;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegister.DataModels
{
    public class SysteemGebruiker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Persoon")]
        public int GebruikerId { get; set; }
        public virtual Persoon Gebruiker { get; set; }
        // Wachtwoord: tenminste een UPPERCASE, lowercase en een getal.
        // Overige validaties via de methode om het wachtwoord te zetten
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain at least 1 UPPERCASE, 1 lowercase and 1 numeral character")]        // See https://stackoverflow.com/questions/8699033/password-dataannotation-in-asp-net-mvc-3 (1 upper, 1 lower, 1 numeric)
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        public bool isPasswordCorrect(String password)
        {
            return Argon2.Verify(this.Wachtwoord, password);
        }

        public static string validateAndHashPassword (string password)
        {
            return (password.isValid() ? Argon2.Hash(password) : "");
        }
    }
}
