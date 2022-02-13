using System;
using CashRegister.DataModels;
using CashRegister.Enum;
using NUnit.Framework;

namespace UnitTests.DataModels
{
    [TestFixture]
    public class PersoonTest
    {
        [Test]
        public void test_NieuwPersoon_DefaultSettings()
        {
            Persoon persoon = new Persoon();
            Assert.IsTrue(persoon.heeftRekening);
            // Default settings, worden ingevuld bij het saven
            Assert.IsNotNull(persoon.AangemaaktOp);
            Assert.IsNull(persoon.AangemaaktDoorId);
            Assert.IsNull(persoon.AangemaaktDoor);
            Assert.IsNotNull(persoon.GewijzigdOp);
            Assert.IsNull(persoon.GewijzigdDoorId);
            Assert.IsNull(persoon.GewijzigdDoor);
            Assert.IsNull(persoon.VerwijderdOp);
            Assert.IsNull(persoon.VerwijderdDoorId);
            Assert.IsNull(persoon.VerwijderdDoor);
            
        }

        [Test]
        public void test_NieuwPersoon_SetRekeningToFalse_ExpectFalse()
        {
            Persoon persoon = new Persoon();
            persoon.heeftRekening = false;
            Assert.IsFalse(persoon.heeftRekening);
        }

        [Test]
        public void test_NieuwPersoon_SetVoorEnAchternaamEnControleerDeze()
        {
            Persoon persoon = new Persoon();
            persoon.Achternaam = "Voorbeeld";
            persoon.Voornaam = "Bij";
            Assert.AreEqual("Bij Voorbeeld", persoon.GetVolledigeNaam(NameOrder.Firstname));
            Assert.AreEqual("Voorbeeld, Bij", persoon.GetVolledigeNaam(NameOrder.Lastname));
        }

        [Test]
        public void test_NieuwPersoon_SetAlleenVoornaamEnControleerDeze()
        {
            Persoon persoon = new Persoon();
            persoon.Voornaam = "Bij";
            Assert.AreEqual("Bij", persoon.GetVolledigeNaam(NameOrder.Firstname));
            Assert.AreEqual("Bij", persoon.GetVolledigeNaam(NameOrder.Lastname));
        }

        [Test]
        public void test_NieuwPersoon_SetAlleenAchternaamEnControleerDeze()
        {
            Persoon persoon = new Persoon();
            persoon.Achternaam = "Voorbeeld";
            Assert.AreEqual("Voorbeeld", persoon.GetVolledigeNaam(NameOrder.Firstname));
            Assert.AreEqual("Voorbeeld", persoon.GetVolledigeNaam(NameOrder.Lastname));
        }

        [Test]
        public void test_NieuwPersoon_SetVoorEnAchternaamMetTussenvoegselEnControleerDeze()
        {
            Persoon persoon = new Persoon();
            persoon.Achternaam = "Voorbeeld";
            persoon.Tussenvoegsel = "der";
            persoon.Voornaam = "Bij";
            Assert.AreEqual("Bij der Voorbeeld", persoon.GetVolledigeNaam(NameOrder.Firstname));
            Assert.AreEqual("Voorbeeld, Bij der", persoon.GetVolledigeNaam(NameOrder.Lastname));
        }

        [Test]
        public void test_NieuwPersoon_SetVoornaamMetTussenvoegselEnControleerDeze()
        {
            Persoon persoon = new Persoon();
            persoon.Tussenvoegsel = "der";
            persoon.Voornaam = "Bij";
            Assert.AreEqual("Bij der", persoon.GetVolledigeNaam(NameOrder.Firstname));
            Assert.AreEqual("Bij der", persoon.GetVolledigeNaam(NameOrder.Lastname));
        }

        [Test]
        public void test_NieuwPersoon_SetAchternaamMetTussenvoegselEnControleerDeze()
        {
            Persoon persoon = new Persoon();
            persoon.Achternaam = "Voorbeeld";
            persoon.Tussenvoegsel = "der";
            Assert.AreEqual("der Voorbeeld", persoon.GetVolledigeNaam(NameOrder.Firstname));
            Assert.AreEqual("Voorbeeld, der", persoon.GetVolledigeNaam(NameOrder.Lastname));
        }

    }
}