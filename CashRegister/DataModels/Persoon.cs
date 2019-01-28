using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.DataModels
{
    public class Persoon
    {
        [Key]
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]      // https://stackoverflow.com/questions/5252979/assign-format-of-datetime-with-data-annotations
        public DateTime AangemaaktOp { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]      // https://stackoverflow.com/questions/5252979/assign-format-of-datetime-with-data-annotations
        public DateTime? VerwijderdOp { get; set; }

        public virtual SysteemGebruiker SysteemGebruiker { get; set; }
    }
}
