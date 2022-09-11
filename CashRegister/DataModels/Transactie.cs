using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegister.DataModels
{
    [Table("Transactie")]
    public class Transactie
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Persoon")]
        public int PersoonId { get; set; }
        public virtual Persoon Persoon { get; set; }
        [Column(TypeName = "Date")]
        public DateTime BestelDatum { get; set; }
        [ForeignKey("ProductPrijs")]
        public int ProductPrijsId { get; set; }
        public virtual ProductPrijs ProductPrijs { get; set; }
        public int ProductAantal { get; set; }

        public decimal TotaalBedrag() { 
            return ProductAantal * ProductPrijs.Prijs; 
        }

    }
}
