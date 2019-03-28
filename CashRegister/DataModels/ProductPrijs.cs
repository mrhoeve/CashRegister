using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegister.DataModels
{
    public class ProductPrijs
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [DataType(DataType.Currency)]
        public decimal Prijs { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]      // https://stackoverflow.com/questions/5252979/assign-format-of-datetime-with-data-annotations
        public DateTime AangemaaktOp { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]      // https://stackoverflow.com/questions/5252979/assign-format-of-datetime-with-data-annotations
        public DateTime GeldigVan { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]      // https://stackoverflow.com/questions/5252979/assign-format-of-datetime-with-data-annotations
        public DateTime? GeldigTot { get; set; }
    }
}