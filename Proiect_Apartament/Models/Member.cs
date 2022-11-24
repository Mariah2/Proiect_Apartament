using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Apartament.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Adresa { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }
        [Display(Name = "Nume")]
        public string? FullName
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Inchiriere>? Inchirieri { get; set; }

    }
}
