using System;
using CashRegister.DAL;
using CashRegister.DataModels;
using CashRegister.Model;
using NUnit.Framework;

namespace UnitTests.DAL
{
    [TestFixture]
    public class DatabaseContextTest : TestDatabaseContext
    {
        [Test]
        public void test_BewerkingenPersoon()
        {
            var voornaam = "voornaam";
            var achternaam = "achternaam";
            // Login in the context
            var curUser = loginAdministrator();
            var context = Context.getInstance().Get();

            // Creëer een nieuw persoon
            Persoon persoon = new Persoon();
            persoon.Voornaam = voornaam;
            persoon.Achternaam = achternaam;
            
            checkFields(persoon, false, false);

            context.Persoon.Add(persoon);
            context.SaveChanges();
        }

        private void checkFields(Persoon persoon, bool aangemaakt, bool verwijderd)
        {
            if (!aangemaakt && !verwijderd)
            {
                Assert.AreEqual(0, persoon.Id);
                Assert.AreEqual(persoon.AangemaaktOp, DateTime.MinValue);
                Assert.IsNull(persoon.AangemaaktDoorId);
                Assert.IsNull(persoon.AangemaaktDoor);
                Assert.AreEqual(persoon.GewijzigdOp, DateTime.MinValue);
                Assert.IsNull(persoon.GewijzigdDoorId);
                Assert.IsNull(persoon.GewijzigdDoor);
                Assert.IsNull(persoon.VerwijderdOp);
                Assert.IsNull(persoon.VerwijderdDoorId);
                Assert.IsNull(persoon.VerwijderdDoor);
            }
        }
        private CurUser loginAdministrator()
        {
            var curUser = CurUser.get();
            curUser.LogIn(Definitions.localAdminP, Definitions.TEST_PASSWORD_VALID);
            Assert.IsTrue(curUser.isLoggedIn());
            Assert.AreEqual(Definitions.localAdminP, curUser.getCurrentUser());
            return curUser;
        }
    }
}