using CashRegister.DAL;
using CashRegister.DataModels;
using CashRegister.Model;
using NUnit.Framework;
using System.Linq;
using UnitTests.DAL;

namespace UnitTests.Model
{
    /// <summary>
    /// Summary description for CurUserTest
    /// </summary>
    [TestFixture]
    public class CurUserTest : MockEntityFramework
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
        public void test_isLoggedIn_NewInstanceWithoutRightCredentials_ExpectFalse()
        {
            CurUser curUser = CurUser.curUser;
            curUser.LogIn(Definitions.localAdminP, Definitions.TEST_PASSWORD_VALIDFORMAT_INVALIDPASSWORD);
            Assert.IsFalse(curUser.isLoggedIn());
        }

        [Test]
        public void sgtest()
        {
            SysteemGebruiker sg = Context.getInstance().Get().Persoon.Where(p => p.Id == Definitions.localAdminP.Id).SingleOrDefault().SysteemGebruiker;
            Assert.IsTrue(sg != null);
        }

        [Test]
        public void test()
        {
            Persoon sg = Context.getInstance().Get().Persoon.Where(p => p.Id == Definitions.localAdminP.Id).SingleOrDefault();
            Assert.IsTrue(sg!=null);
        }
    }
}
