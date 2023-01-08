using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Apartament.Models
{
    public class Proprietar
    {
        public int ID { get; set; }

        [Display(Name = "Proprietar")]
        public string NumeProprietar { get; set; }
        public ICollection<Apartament>? Apartamente { get; set; }
    }
}
