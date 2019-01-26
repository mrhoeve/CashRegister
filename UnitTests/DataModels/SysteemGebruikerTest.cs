using CashRegister.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.DataModels
{
    /// <summary>
    /// Summary description for SysteemGebruiker
    /// </summary>
    [TestClass]
    public class SysteemGebruikerTest
    {
        [TestMethod]
        public void test_isPasswordCorrect_UseValidPassword_ExpectTrue()
        {
            SysteemGebruiker systeemGebruiker = new SysteemGebruiker();
            systeemGebruiker.Wachtwoord = SysteemGebruiker.validateAndHashPassword(Definitions.TEST_PASSWORD_VALID);
            // Make sure that our password hasn't been saved but the hash has.
            Assert.IsFalse(systeemGebruiker.Wachtwoord.Equals(Definitions.TEST_PASSWORD_VALID));
            // Make sure it's a Argon2 hash
            Assert.IsTrue(systeemGebruiker.Wachtwoord.StartsWith("$argon2i$"));
            // Finally, check if the valid password is indeed valid
            Assert.IsTrue(systeemGebruiker.isPasswordCorrect(Definitions.TEST_PASSWORD_VALID));
        }

        [TestMethod]
        public void test_isPasswordCorrect_UseInvalidPassword_ExpectEmptyStringInPasswordAndFailedComparison()
        {
            SysteemGebruiker systeemGebruiker = new SysteemGebruiker();
            systeemGebruiker.Wachtwoord = SysteemGebruiker.validateAndHashPassword(Definitions.TEST_PASSWORD_TOOSHORT);
            // Check if the string is empty
            Assert.IsTrue(string.IsNullOrEmpty(systeemGebruiker.Wachtwoord));
            // Valid same password
            Assert.IsFalse(systeemGebruiker.isPasswordCorrect(Definitions.TEST_PASSWORD_TOOSHORT));
        }

        [TestMethod]
        public void test_isPasswordCorrect_UseDifferentPasswordToCheck_ExpectFalse()
        {
            SysteemGebruiker systeemGebruiker = new SysteemGebruiker();
            systeemGebruiker.Wachtwoord = SysteemGebruiker.validateAndHashPassword(Definitions.TEST_PASSWORD_VALID);
            // Make sure that our password hasn't been saved but the hash has.
            Assert.IsFalse(systeemGebruiker.Wachtwoord.Equals(Definitions.TEST_PASSWORD_VALID));
            // Make sure it's a Argon2 hash
            Assert.IsTrue(systeemGebruiker.Wachtwoord.StartsWith("$argon2i$"));
            // Now, check with a different password (just add # to the used string)
            Assert.IsFalse(systeemGebruiker.isPasswordCorrect(Definitions.TEST_PASSWORD_VALID + "#"));
        }
    }
}
