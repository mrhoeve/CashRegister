using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using CashRegister.Enum;
using CashRegister.Helpers;
using CashRegister.License;

namespace CashRegister.DataModels
{
    [Table("Persoon")]
    public class Persoon : IUsesOSS
    {
        private bool rekening = true;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public bool SystemUser { get; set; }
        // Wachtwoord: tenminste een UPPERCASE, lowercase en een getal.
        // Overige validaties via de methode om het wachtwoord te zetten
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain at least 1 UPPERCASE, 1 lowercase and 1 numeral character")]        // See https://stackoverflow.com/questions/8699033/password-dataannotation-in-asp-net-mvc-3 (1 upper, 1 lower, 1 numeric)
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }
        public bool heeftRekening
        {
            get { return rekening; }
            set { this.rekening = value; }
        }
        [Column(TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]      // https://stackoverflow.com/questions/5252979/assign-format-of-datetime-with-data-annotations
        public DateTime AangemaaktOp { get; set; }
        public int? AangemaaktDoorId { get; set; }
        [ForeignKey("AangemaaktDoorId")]
        [InverseProperty("HeeftAangemaakt")]
        public virtual Persoon AangemaaktDoor { get; set; }
        [Column(TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]      // https://stackoverflow.com/questions/5252979/assign-format-of-datetime-with-data-annotations
        public DateTime GewijzigdOp { get; set; }
        public int? GewijzigdDoorId { get; set; }
        [ForeignKey("GewijzigdDoorId")]
        [InverseProperty("HeeftGewijzigd")]
        public virtual Persoon GewijzigdDoor { get; set; }
        [Column(TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]      // https://stackoverflow.com/questions/5252979/assign-format-of-datetime-with-data-annotations
        public DateTime? VerwijderdOp { get; set; }
        public int? VerwijderdDoorId { get; set; }
        [ForeignKey("VerwijderdDoorId")]
        [InverseProperty("HeeftVerwijderd")]
        public virtual Persoon VerwijderdDoor { get; set; }

        [InverseProperty("AangemaaktDoor")]
        public virtual ICollection<Persoon> HeeftAangemaakt { get; set; }
        [InverseProperty("GewijzigdDoor")]
        public virtual ICollection<Persoon> HeeftGewijzigd { get; set; }
        [InverseProperty("VerwijderdDoor")]
        public virtual ICollection<Persoon> HeeftVerwijderd { get; set; }


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
        
        public bool isPasswordCorrect(String password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(Wachtwoord)) return false;
            return BCrypt.Net.BCrypt.Verify(password,this.Wachtwoord);
        }

        public static string validateAndHashPassword (string password)
        {
            return password.isValid() ? BCrypt.Net.BCrypt.HashPassword(password) : "";
        }
        
        

        [ExcludeFromCodeCoverage]
        public List<OpenSourceInformation> getOpenSourceInformation()
        {
            return new OpenSourceInformation("BCrypt.Net-Next", "https://github.com/BcryptNet/bcrypt.net", "BCrypt.Net-Next.txt").singleList();
        }
    }
}
