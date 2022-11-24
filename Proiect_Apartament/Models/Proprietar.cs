namespace Proiect_Apartament.Models
{
    public class Proprietar
    {
        public int ID { get; set; }
        public string NumeProprietar { get; set; }
        public ICollection<Apartament>? Apartamente { get; set; }
    }
}
