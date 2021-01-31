using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CashRegister.Enum;
using CashRegister.Helpers;

namespace CashRegister.DataModels
{
    public class Persoon
    {
        private bool rekening = true;

        [Key]
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public bool heeftRekening
        {
            get { return rekening; }
            set { this.rekening = value; }
        }
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]      // https://stackoverflow.com/questions/5252979/assign-format-of-datetime-with-data-annotations
        public DateTime AangemaaktOp { get; set; }
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]      // https://stackoverflow.com/questions/5252979/assign-format-of-datetime-with-data-annotations
        public DateTime? VerwijderdOp { get; set; }

        public virtual SysteemGebruiker SysteemGebruiker { get; set; }

        public string GetVolledigeNaam(NameOrder nameOrder = NameOrder.Lastname)
        {
            switch (nameOrder)
            {
                case NameOrder.Firstname:
                    if (string.IsNullOrEmpty(Tussenvoegsel))
                        return $"{Voornaam} {Achternaam}".Trim();
                    else
                        return $"{Voornaam} {Tussenvoegsel} {Achternaam}".Trim();
                default:
                    if (string.IsNullOrEmpty(Tussenvoegsel))
                        return $"{Achternaam}, {Voornaam}".Normalise();
                    else
                        if(string.IsNullOrEmpty(Voornaam))
                            return $"{Achternaam}, {Tussenvoegsel}".Normalise();
                        else
                            return $"{Achternaam}, {Voornaam} {Tussenvoegsel}".Normalise();
                
            }
        }
    }
}
