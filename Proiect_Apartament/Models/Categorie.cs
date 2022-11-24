namespace Proiect_Apartament.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<CategorieApartament>? CategorieApartament { get; set; }
    }
}
