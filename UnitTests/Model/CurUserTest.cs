using CashRegister.DataModels;
using CashRegister.Model;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Threading;
using UnitTests.DAL;

namespace UnitTests.Model
{
    /// <summary>
    /// Summary description for CurUserTest
    /// </summary>
    [TestFixture]
    public class CurUserTest : TestDatabaseContext
    {
        [Test]
        public void test_isLoggedIn_NewInstanceWithoutLoggingIn_ExpectFalse()
        {
            CurUser curUser = CurUser.get();
            Assert.IsFalse(curUser.isLoggedIn());
        }

        [Test]
        public void test_isLoggedIn_NewInstanceWithoutPersoonOrPassword_ExpectFalse()
        {
            CurUser curUser = CurUser.get();
            curUser.LogIn(null,null);
            Assert.IsFalse(curUser.isLoggedIn());
        }

        [Test]
        public void test_isLoggedIn_NewInstanceWithRightCredentials_ExpectTrue()
        {
            CurUser curUser = CurUser.get();
            curUser.LogIn(Definitions.localAdminP, Definitions.TEST_PASSWORD_VALID);
            Assert.IsTrue(curUser.isLoggedIn());
        }

        [Test]
        public void test_isLoggedIn_NewInstanceWithRightCredentials_WaitForTimeOut_FinallyExpectFalse()
        {
            // Setup test
            CurUser curUser = CurUser.get();
            object o = curUser;
            var t = typeof(CurUser);
            // Change the private (!!) property from the initial 5 minutes to 2 seconds
            t.GetProperty("_timerInterval", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(o, TimeSpan.FromSeconds(2));
            // Log in with the right credentials
            curUser.LogIn(Definitions.localAdminP, Definitions.TEST_PASSWORD_VALID);
            // Are we logged in?
            Assert.IsTrue(curUser.isLoggedIn());
            // Now wait for the adjusted timer to expire
            Thread.Sleep(TimeSpan.FromSeconds(3));
            // And check again if we're logged in
            Assert.IsFalse(curUser.isLoggedIn());
        }

        [Test]
        public void test_isLoggedIn_NewInstanceWithRightCredentials_DelayForTimeOut_FinallyExpectFalse()
        {
            // Setup test
            CurUser curUser = CurUser.get();
            object o = curUser;
            var t = typeof(CurUser);
            // Call the private (!!) method to change the timerinterval from the initial 5 minutes to 3 seconds
            t.GetMethod("SetTimerInterval", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(o, new object[] { TimeSpan.FromSeconds(3) });
            // Log in with the right credentials
            curUser.LogIn(Definitions.localAdminP, Definitions.TEST_PASSWORD_VALID);
            for (int i = 0; i < 10; i++)
            {
                // Now wait for the adjusted timer to nearly expire
                Thread.Sleep(TimeSpan.FromSeconds(1));
                // Are we logged in? -- This should reset the timer
                Assert.IsTrue(curUser.isLoggedIn());
            }
            // Now wait for the adjusted timer to expire
            Thread.Sleep(TimeSpan.FromSeconds(4));
            // And check again if we're logged in
            Assert.IsFalse(curUser.isLoggedIn());
        }

        [Test]
        public void test_isLoggedIn_NewInstanceWithoutRightCredentials_ExpectFalse()
        {
            CurUser curUser = CurUser.get();
            curUser.LogIn(Definitions.localAdminP, Definitions.TEST_PASSWORD_VALIDFORMAT_INVALIDPASSWORD);
            Assert.IsFalse(curUser.isLoggedIn());
        }

        [Test]
        public void test_isLoggedIn_NewInstanceWithoutExistingUserUsingCorrectPassword_ExpectFalse()
        {
            CurUser curUser = CurUser.get();
            curUser.LogIn(new Persoon(), Definitions.TEST_PASSWORD_VALID);
            Assert.IsFalse(curUser.isLoggedIn());
        }
    }
}
