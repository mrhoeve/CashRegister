using CashRegister.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CashRegister.DataModels
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Productomschrijving { get; set; }

        public virtual ICollection<ProductPrijs> ProductPrijzen { get; set; }

        public ProductPrijs getProductPrijs()
        {
            return getProductPrijs(DateTime.Now);
        }

        public ProductPrijs getProductPrijs(DateTime date)
        {
            return ProductPrijzen.Where(p => p.GeldigVan.Date <= date.Date && (p.GeldigTot == null || p.GeldigTot.getDate() >= date.Date ))
                .SingleOrDefault();
        }
    }
}