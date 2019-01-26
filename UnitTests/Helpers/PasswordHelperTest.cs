using CashRegister.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.Helpers
{
    [TestClass]
    public class PasswordHelperTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Password is null or empty")]
        public void test_checkValidityWithErrorThrowing_PasswordWithNull_ExpectArgumentNullException()
        {
            String password = null;
            password.checkValidityWithErrorThrowing();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Password is null or empty")]
        public void test_checkValidityWithErrorThrowing_PasswordWithEmptyString_ExpectArgumentNullException()
        {
            String password = "";
            password.checkValidityWithErrorThrowing();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Password does not meet minimum length")]
        public void test_checkValidityWithErrorThrowing_TooShortPassword_ExpectArgumentException()
        {
            String password = Definitions.TEST_PASSWORD_TOOSHORT;
            password.checkValidityWithErrorThrowing();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Password must contain at least 1 UPPERCASE, 1 lowercase and 1 numeral character")]
        public void test_checkValidityWithErrorThrowing_PasswordWithoutUppercase_ExpectArgumentException()
        {
            String password = Definitions.TEST_PASSWORD_WITHOUTUPPERCASE;
            password.checkValidityWithErrorThrowing();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Password must contain at least 1 UPPERCASE, 1 lowercase and 1 numeral character")]
        public void test_checkValidityWithErrorThrowing_PasswordWithoutlowercase_ExpectArgumentException()
        {
            String password = Definitions.TEST_PASSWORD_WITHOUTLOWERCASE;
            password.checkValidityWithErrorThrowing();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Password must contain at least 1 UPPERCASE, 1 lowercase and 1 numeral character")]
        public void test_checkValidityWithErrorThrowing_PasswordWithoutNumerals_ExpectArgumentException()
        {
            String password = Definitions.TEST_PASSWORD_WITHOUTNUMERALS;
            password.checkValidityWithErrorThrowing();
        }

        [TestMethod]
        public void test_checkValidityWithErrorThrowing_ValidPassword_ExpectNothing()
        {
            try
            {
                String password = Definitions.TEST_PASSWORD_VALID;
                password.checkValidityWithErrorThrowing();
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void test_isValid_PasswordWithNull_ExpectFalse()
        {
            String password = null;
            Assert.IsFalse(password.isValid());
        }

        [TestMethod]
        public void test_isValid_PasswordWithEmptyString_ExpectFalse()
        {
            String password = "";
            Assert.IsFalse(password.isValid());
        }

        [TestMethod]
        public void test_isValid_TooShortPassword_ExpectFalse()
        {
            String password = Definitions.TEST_PASSWORD_TOOSHORT;
            Assert.IsFalse(password.isValid());
        }

        [TestMethod]
        public void test_isValid_PasswordWithoutUppercase_ExpectFalse()
        {
            String password = Definitions.TEST_PASSWORD_WITHOUTUPPERCASE;
            Assert.IsFalse(password.isValid());
        }

        [TestMethod]
        public void test_isValid_PasswordWithoutlowercase_ExpectFalse()
        {
            String password = Definitions.TEST_PASSWORD_WITHOUTLOWERCASE;
            Assert.IsFalse(password.isValid());
        }

        [TestMethod]
        public void test_isValid_PasswordWithoutNumerals_ExpectFalse()
        {
            String password = Definitions.TEST_PASSWORD_WITHOUTNUMERALS;
            Assert.IsFalse(password.isValid());
        }

        [TestMethod]
        public void test_isValid_ValidPassword_ExpectTrue()
        {
            String password = Definitions.TEST_PASSWORD_VALID;
            Assert.IsTrue(password.isValid());
        }

    }
}
