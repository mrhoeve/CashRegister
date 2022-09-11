using CashRegister.DataModels;
using System;

namespace UnitTests
{
    class Definitions
    {
        // For testing administrators
        // Persoon localAdmin must be made without a SysteemGebruiker
        // Within the MockEntityFramework class, they'll be joined together
        public static readonly Persoon localAdmin = new Persoon() { Voornaam = "Bas", Tussenvoegsel = "", Achternaam = "Uurman", SystemUser = true, Wachtwoord = Persoon.validateAndHashPassword(Definitions.TEST_PASSWORD_VALID), AangemaaktOp = DateTime.UtcNow, GewijzigdOp = DateTime.UtcNow};

        // Testing passwords
        public const string TEST_PASSWORD_WITHOUTNUMERALS = "ABCDefgh";
        public const string TEST_PASSWORD_WITHOUTUPPERCASE = "abcd1234";
        public const string TEST_PASSWORD_WITHOUTLOWERCASE = "ABCD1234";
        public const string TEST_PASSWORD_TOOSHORT = "ABCdef1";
        public const string TEST_PASSWORD_VALID = "ABCdef12";
        public const string TEST_PASSWORD_VALIDFORMAT_INVALIDPASSWORD = "abcDEF12";

        // Testing products
        public static Product product1 = new Product() { Id = 1, Productomschrijving = "Product 1" };
        public static ProductPrijs product1Prijs1 = new ProductPrijs()
        {
            Id = 1,
            ProductId = product1.Id,
            Product = product1,
            Prijs = 1.50m,
            GeldigVan = DateTime.UtcNow.AddMonths(-1),
            GeldigTot = DateTime.Now.AddDays(-1),
            AangemaaktOp = DateTime.UtcNow.AddMonths(-1)
        };
        public static ProductPrijs product1Prijs2 = new ProductPrijs()
        {
            Id = 2,
            ProductId = product1.Id,
            Product = product1,
            Prijs = 2.00m,
            GeldigVan = DateTime.UtcNow,
            AangemaaktOp = DateTime.UtcNow.AddDays(-1)
        };

        public static Product product2 = new Product() { Id = 2, Productomschrijving = "Product 2" };
        public static ProductPrijs product2Prijs1 = new ProductPrijs()
        {
            Id = 3,
            ProductId = product2.Id,
            Product = product2,
            Prijs = 3.00m,
            GeldigVan = DateTime.UtcNow.AddMonths(-1),
            GeldigTot = DateTime.Now.AddDays(-1),
            AangemaaktOp = DateTime.UtcNow.AddMonths(-1)
        };
        public static ProductPrijs product2Prijs2 = new ProductPrijs()
        {
            Id = 4,
            ProductId = product2.Id,
            Product = product2,
            Prijs = 4.00m,
            GeldigVan = DateTime.UtcNow,
            AangemaaktOp = DateTime.UtcNow.AddDays(-1)
        };

    }
}
