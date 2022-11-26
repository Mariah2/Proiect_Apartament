using System.ComponentModel.DataAnnotations;

namespace Proiect_Apartament.Models
{
    public class Inchiriere
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? ApartamentID { get; set; }
        public Apartament? Apartament { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckoutDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckinDate { get; set; }
    }
}
