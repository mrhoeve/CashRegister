using System;
using System.Text;
using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister.Model;
using CashRegister.DataModels;
using NUnit.Framework;
using Moq;
using System.Linq;

namespace UnitTests.Model
{
    /// <summary>
    /// Summary description for CurUserTest
    /// </summary>
    [TestFixture]
    public class CurUserTest : BaseTest
    {
        [Test]
        public void test_isLoggedIn_NewInstanceWithoutLoggingIn_ExpectFalse()
        {
            CurUser curUser = CurUser.curUser;
            Assert.IsFalse(curUser.isLoggedIn());
        }

        [Test]
        public void test_isLoggedIn_NewInstanceWithRightCredentials_ExpectTrue()
        {
            CurUser curUser = CurUser.curUser;
            curUser.LogIn(Definitions.localAdminP, Definitions.TEST_PASSWORD_VALID);
            Assert.IsTrue(curUser.isLoggedIn());
        }

        [Test]
        public void test()
        {
            var sg = MockContext.Object.Persoon.Where(p => p.Id == Definitions.localAdminP.Id).SingleOrDefault();
            Assert.IsTrue(sg!=null);
        }
    }
}
