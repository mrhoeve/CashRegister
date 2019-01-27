using CashRegister.DAL;
using CashRegister.DataModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


// Idea: https://mirkomaggioni.com/2017/08/30/ef-db-context-mock-with-moq/
// Bases upon implementation in https://github.com/mirkomaggioni/EFContextMock/releases/tag/0.2.2
namespace UnitTests
{
    public class BaseTest
    {
        protected Mock<databaseContext> MockContext;
        protected Mock<DbSet<Persoon>> mockPersoon;
        protected Mock<DbSet<SysteemGebruiker>> mockSysteemGebruiker;

        [SetUp]
        public void Setup()
        {
            // Initialise the lists
            Persoon p3 = new Persoon() { Id = 3, Voornaam = "Bas", Tussenvoegsel = "", Achternaam = "Uurman", AangemaaktOp = DateTime.UtcNow };
            var personen = new List<Persoon>()
            {
                new Persoon() { Id=1, Voornaam="Kees", Tussenvoegsel="", Achternaam="Kwakker", AangemaaktOp=DateTime.UtcNow },
                new Persoon() { Id=2, Voornaam="Joran", Tussenvoegsel="", Achternaam="Kloek", AangemaaktOp=DateTime.UtcNow },
                p3
            };
            var personenQueryable = personen.AsQueryable();

            var systeemGebruiker = new List<SysteemGebruiker>()
            {
                new SysteemGebruiker() { Id=1, GebruikerId=p3.Id, Gebruiker=p3, Wachtwoord=SysteemGebruiker.validateAndHashPassword(Definitions.TEST_PASSWORD_VALID) }
            };
            var systeemGebruikerQueryable = systeemGebruiker.AsQueryable();

            // Create DbSet mocks and set it up
            mockPersoon = new Mock<DbSet<Persoon>>();
            mockSysteemGebruiker = new Mock<DbSet<SysteemGebruiker>>();

            mockPersoon.As<IQueryable<Persoon>>().Setup(m => m.Expression).Returns(personenQueryable.Expression);
            mockPersoon.As<IQueryable<Persoon>>().Setup(m => m.ElementType).Returns(personenQueryable.ElementType);
            mockPersoon.As<IQueryable<Persoon>>().Setup(m => m.GetEnumerator()).Returns(personenQueryable.GetEnumerator);
            mockPersoon.Setup(m => m.Add(It.IsAny<Persoon>())).Callback((Persoon person) => personen.Add(person));
            mockPersoon.Setup(m => m.Remove(It.IsAny<Persoon>())).Callback((Persoon person) => personen.Remove(person));

            mockSysteemGebruiker.As<IQueryable<SysteemGebruiker>>().Setup(m => m.Expression).Returns(systeemGebruikerQueryable.Expression);
            mockSysteemGebruiker.As<IQueryable<SysteemGebruiker>>().Setup(m => m.ElementType).Returns(systeemGebruikerQueryable.ElementType);
            mockSysteemGebruiker.As<IQueryable<SysteemGebruiker>>().Setup(m => m.GetEnumerator()).Returns(systeemGebruikerQueryable.GetEnumerator);
            mockSysteemGebruiker.Setup(m => m.Add(It.IsAny<SysteemGebruiker>())).Callback((SysteemGebruiker person) => systeemGebruiker.Add(person));
            mockSysteemGebruiker.Setup(m => m.Remove(It.IsAny<SysteemGebruiker>())).Callback((SysteemGebruiker person) => systeemGebruiker.Remove(person));

            MockContext = new Mock<databaseContext>();
            MockContext.Setup(m => m.Persoon).Returns(mockPersoon.Object);
            MockContext.Setup(m => m.SysteemGebruiker).Returns(mockSysteemGebruiker.Object);
        }
    }
}
