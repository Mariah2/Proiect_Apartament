using Proiect_Apartament.Migrations;

namespace Proiect_Apartament.Models
{
    public class ApartamentData
    {
        public IEnumerable<Apartament> Apartamente { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieApartament> CategoriiApartament
        {
            get; set;
        }
    }
}
