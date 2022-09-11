using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using CashRegister.DAL;
using CashRegister.DataModels;
using CashRegister.Model;
using NLog;
using NMemory.Linq;
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
            persoon.SystemUser = false;

            checkFields(persoon, false, false);

            context.Persoon.Add(persoon);
            context.SaveChanges();
            persoon = context.Persoon.First(p => p.Achternaam == achternaam);
            checkFields(persoon, true, false);

            context.Persoon.Remove(persoon);
            context.SaveChanges();
            persoon = context.Persoon.First(p => p.Achternaam == achternaam);
            checkFields(persoon, true, true);
        }

        private void checkFields(Persoon persoon, bool aangemaakt, bool verwijderd)
        {
            if (!aangemaakt && !verwijderd)
            {
                Assert.AreEqual(0, persoon.Id);
                Assert.AreEqual(DateTime.MinValue, persoon.AangemaaktOp);
                Assert.IsNull(persoon.AangemaaktDoorId);
                Assert.IsNull(persoon.AangemaaktDoor);
                Assert.AreEqual(DateTime.MinValue, persoon.GewijzigdOp);
                Assert.IsNull(persoon.GewijzigdDoorId);
                Assert.IsNull(persoon.GewijzigdDoor);
                Assert.IsNull(persoon.VerwijderdOp);
                Assert.IsNull(persoon.VerwijderdDoorId);
                Assert.IsNull(persoon.VerwijderdDoor);
            }
            else
            {
                Assert.AreNotEqual(0, persoon.Id);
                Assert.AreNotEqual(DateTime.MinValue, persoon.AangemaaktOp);
                Assert.AreEqual(Definitions.localAdmin.Id, persoon.AangemaaktDoorId);
                Assert.IsNotNull(persoon.AangemaaktDoor);
                Assert.AreNotEqual(DateTime.MinValue, persoon.GewijzigdOp);
                Assert.AreEqual(Definitions.localAdmin.Id, persoon.GewijzigdDoorId);
                Assert.IsNotNull(persoon.GewijzigdDoor);
                if (verwijderd)
                {
                    Assert.IsNotNull(persoon.VerwijderdOp);
                    Assert.AreEqual(Definitions.localAdmin.Id, persoon.VerwijderdDoorId);
                    Assert.IsNotNull(persoon.VerwijderdDoor);
                }
                else
                {
                    Assert.IsNull(persoon.VerwijderdOp);
                    Assert.IsNull(persoon.VerwijderdDoorId);
                    Assert.IsNull(persoon.VerwijderdDoor);
                }
            }
        }
        
        private CurUser loginAdministrator()
        {
            var curUser = CurUser.get();
            curUser.LogIn(Definitions.localAdmin, Definitions.TEST_PASSWORD_VALID);
            Assert.IsTrue(curUser.isLoggedIn());
            Assert.AreEqual(Definitions.localAdmin.Id, curUser.getCurrentUser().Id);
            return curUser;
        }
    }
}