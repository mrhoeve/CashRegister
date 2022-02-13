using System.Collections.Generic;
using CashRegister.DataModels;
using CashRegister.License;
using NUnit.Framework;

namespace UnitTests.DataModels
{
    /// <summary>
    /// Summary description for SysteemGebruiker
    /// </summary>
    [TestFixture]
    public class SysteemGebruikerTest
    {
        [Test]
        public void test_isPasswordCorrect_UseValidPassword_ExpectTrue()
        {
            SysteemGebruiker systeemGebruiker = new SysteemGebruiker();
            systeemGebruiker.Wachtwoord = SysteemGebruiker.validateAndHashPassword(Definitions.TEST_PASSWORD_VALID);
            // Make sure that our password hasn't been saved but the hash has.
            Assert.IsFalse(Definitions.TEST_PASSWORD_VALID.Equals(systeemGebruiker.Wachtwoord));
            // Make sure the password begins with $2a$
            Assert.IsTrue(systeemGebruiker.Wachtwoord.StartsWith("$2a$"));
            // Finally, check if the valid password is indeed valid
            Assert.IsTrue(systeemGebruiker.isPasswordCorrect(Definitions.TEST_PASSWORD_VALID));
        }

        [Test]
        public void test_isPasswordCorrect_UseInvalidPassword_ExpectEmptyStringInPasswordAndFailedComparison()
        {
            SysteemGebruiker systeemGebruiker = new SysteemGebruiker();
            systeemGebruiker.Wachtwoord = SysteemGebruiker.validateAndHashPassword(Definitions.TEST_PASSWORD_TOOSHORT);
            // Check if the string is empty
            Assert.IsTrue(string.IsNullOrEmpty(systeemGebruiker.Wachtwoord));
            // Valid same password
            Assert.IsFalse(systeemGebruiker.isPasswordCorrect(Definitions.TEST_PASSWORD_TOOSHORT));
        }

        [Test]
        public void test_isPasswordCorrect_UseDifferentPasswordToCheck_ExpectFalse()
        {
            SysteemGebruiker systeemGebruiker = new SysteemGebruiker();
            systeemGebruiker.Wachtwoord = SysteemGebruiker.validateAndHashPassword(Definitions.TEST_PASSWORD_VALID);
            // Make sure that our password hasn't been saved but the hash has.
            Assert.IsFalse(systeemGebruiker.Wachtwoord.Equals(Definitions.TEST_PASSWORD_VALID));
            // Make sure the password begins with $2a$
            Assert.IsTrue(systeemGebruiker.Wachtwoord.StartsWith("$2a$"));
            // Now, check with a different password (just add # to the used string)
            Assert.IsFalse(systeemGebruiker.isPasswordCorrect(Definitions.TEST_PASSWORD_VALID + "#"));
        }
    }
}
