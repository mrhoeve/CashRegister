using CashRegister.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    class Definitions
    {
        // For testing administrators
        public static readonly Persoon localAdminP = new Persoon() { Id = 3, Voornaam = "Bas", Tussenvoegsel = "", Achternaam = "Uurman", AangemaaktOp = DateTime.UtcNow };
        public static readonly SysteemGebruiker localAdminS = new SysteemGebruiker() { PersoonId = localAdminP.Id, Persoon = localAdminP, Wachtwoord = SysteemGebruiker.validateAndHashPassword(Definitions.TEST_PASSWORD_VALID) };

        // Testing passwords
        public const string TEST_PASSWORD_WITHOUTNUMERALS = "ABCDefgh";
        public const string TEST_PASSWORD_WITHOUTUPPERCASE = "abcd1234";
        public const string TEST_PASSWORD_WITHOUTLOWERCASE = "ABCD1234";
        public const string TEST_PASSWORD_TOOSHORT = "ABCdef1";
        public const string TEST_PASSWORD_VALID = "ABCdef12";
    }
}
