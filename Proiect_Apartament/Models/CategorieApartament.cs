namespace Proiect_Apartament.Models
{
    public class CategorieApartament
    {
        public int ID { get; set; }
        public int ApartamentID { get; set; }
        public Apartament Apartament { get; set; } 
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
