using System;
using System.ComponentModel.DataAnnotations;
using CashRegister.Enum;

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

        public string GetVolledigeNaam(NameOrder nameOrder = NameOrder.Lastname)
        {
            switch (nameOrder)
            {
                case NameOrder.Firstname:
                    if (string.IsNullOrEmpty(Tussenvoegsel))
                        return $"{Voornaam} {Achternaam}";
                    else
                        return $"{Voornaam} {Tussenvoegsel} {Achternaam}";
                    break;
                default:
                    if (string.IsNullOrEmpty(Tussenvoegsel))
                        return $"{Achternaam}, {Voornaam}";
                    else
                        return $"{Achternaam}, {Voornaam} {Tussenvoegsel}";
                    break;
                
            }
        }
    }
}
