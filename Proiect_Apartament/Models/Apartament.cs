using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Apartament.Models
{
    public class Apartament
    {
        public int ID { get; set; }

        [Display(Name = "Nume Apartament")]
        public string Nume { get; set; } = string.Empty;

        //public string Proprietar { get; set; }
        public int ProprietarID { get; set; }
        public Proprietar Proprietar { get; set; } = null!;

        [Column(TypeName = "decimal(6,2)")]
        [Range(0.01, 500)]

        public decimal Pret { get; set; }

        public ICollection<CategorieApartament>? CategoriiApartament { get; set; }

        public Apartament()
        {
            CategoriiApartament = new HashSet<CategorieApartament>();
        }
    }
}
