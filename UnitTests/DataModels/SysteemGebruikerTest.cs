﻿using System.Collections.Generic;
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
            Persoon persoon = new Persoon();
            persoon.Wachtwoord = Persoon.validateAndHashPassword(Definitions.TEST_PASSWORD_VALID);
            // Make sure that our password hasn't been saved but the hash has.
            Assert.IsFalse(Definitions.TEST_PASSWORD_VALID.Equals(persoon.Wachtwoord));
            // Make sure the password begins with $2a$
            Assert.IsTrue(persoon.Wachtwoord.StartsWith("$2a$"));
            // Finally, check if the valid password is indeed valid
            Assert.IsTrue(persoon.isPasswordCorrect(Definitions.TEST_PASSWORD_VALID));
        }

        [Test]
        public void test_isPasswordCorrect_UseInvalidPassword_ExpectEmptyStringInPasswordAndFailedComparison()
        {
            Persoon persoon = new Persoon();
            persoon.Wachtwoord = Persoon.validateAndHashPassword(Definitions.TEST_PASSWORD_TOOSHORT);
            // Check if the string is empty
            Assert.IsTrue(string.IsNullOrEmpty(persoon.Wachtwoord));
            // Valid same password
            Assert.IsFalse(persoon.isPasswordCorrect(Definitions.TEST_PASSWORD_TOOSHORT));
        }

        [Test]
        public void test_isPasswordCorrect_UseDifferentPasswordToCheck_ExpectFalse()
        {
            Persoon persoon = new Persoon();
            persoon.Wachtwoord = Persoon.validateAndHashPassword(Definitions.TEST_PASSWORD_VALID);
            // Make sure that our password hasn't been saved but the hash has.
            Assert.IsFalse(persoon.Wachtwoord.Equals(Definitions.TEST_PASSWORD_VALID));
            // Make sure the password begins with $2a$
            Assert.IsTrue(persoon.Wachtwoord.StartsWith("$2a$"));
            // Now, check with a different password (just add # to the used string)
            Assert.IsFalse(persoon.isPasswordCorrect(Definitions.TEST_PASSWORD_VALID + "#"));
        }
    }
}
