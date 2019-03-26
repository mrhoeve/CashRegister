using CashRegister.Helpers;
using System;
using NUnit.Framework;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class PasswordHelperTest
    {
        [Test]
        public void test_checkValidityWithErrorThrowing_PasswordWithNull_ExpectArgumentNullException()
        {
            String password = null;
            Assert.That(() => password.checkValidityWithErrorThrowing(), Throws.ArgumentNullException);
        }

        [Test]
        public void test_checkValidityWithErrorThrowing_PasswordWithEmptyString_ExpectArgumentNullException()
        {
            String password = "";
            Assert.That(() => password.checkValidityWithErrorThrowing(), Throws.ArgumentNullException);
        }

        [Test]
        public void test_checkValidityWithErrorThrowing_TooShortPassword_ExpectArgumentException()
        {
            String password = Definitions.TEST_PASSWORD_TOOSHORT;
            Assert.That(() => password.checkValidityWithErrorThrowing(), Throws.ArgumentException);
        }

        [Test]
        public void test_checkValidityWithErrorThrowing_PasswordWithoutUppercase_ExpectArgumentException()
        {
            String password = Definitions.TEST_PASSWORD_WITHOUTUPPERCASE;
            Assert.That(() => password.checkValidityWithErrorThrowing(), Throws.ArgumentException);
        }

        [Test]
        public void test_checkValidityWithErrorThrowing_PasswordWithoutlowercase_ExpectArgumentException()
        {
            String password = Definitions.TEST_PASSWORD_WITHOUTLOWERCASE;
            Assert.That(() => password.checkValidityWithErrorThrowing(), Throws.ArgumentException);
        }

        [Test]
        public void test_checkValidityWithErrorThrowing_PasswordWithoutNumerals_ExpectArgumentException()
        {
            String password = Definitions.TEST_PASSWORD_WITHOUTNUMERALS;
            Assert.That(() => password.checkValidityWithErrorThrowing(), Throws.ArgumentException);
        }

        [Test]
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

        [Test]
        public void test_isValid_PasswordWithNull_ExpectFalse()
        {
            String password = null;
            Assert.IsFalse(password.isValid());
        }

        [Test]
        public void test_isValid_PasswordWithEmptyString_ExpectFalse()
        {
            String password = "";
            Assert.IsFalse(password.isValid());
        }

        [Test]
        public void test_isValid_TooShortPassword_ExpectFalse()
        {
            String password = Definitions.TEST_PASSWORD_TOOSHORT;
            Assert.IsFalse(password.isValid());
        }

        [Test]
        public void test_isValid_PasswordWithoutUppercase_ExpectFalse()
        {
            String password = Definitions.TEST_PASSWORD_WITHOUTUPPERCASE;
            Assert.IsFalse(password.isValid());
        }

        [Test]
        public void test_isValid_PasswordWithoutLowercase_ExpectFalse()
        {
            String password = Definitions.TEST_PASSWORD_WITHOUTLOWERCASE;
            Assert.IsFalse(password.isValid());
        }

        [Test]
        public void test_isValid_PasswordWithoutNumerals_ExpectFalse()
        {
            String password = Definitions.TEST_PASSWORD_WITHOUTNUMERALS;
            Assert.IsFalse(password.isValid());
        }

        [Test]
        public void test_isValid_ValidPassword_ExpectTrue()
        {
            String password = Definitions.TEST_PASSWORD_VALID;
            Assert.IsTrue(password.isValid());
        }

    }
}
