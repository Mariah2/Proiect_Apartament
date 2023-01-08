using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Apartament.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        [Display(Name = "Categorie")]

        public string NumeCategorie { get; set; }
        public ICollection<CategorieApartament> CategoriiApartament { get; set; }

        public Categorie()
        {
            CategoriiApartament = new HashSet<CategorieApartament>();
        }
    }
}
