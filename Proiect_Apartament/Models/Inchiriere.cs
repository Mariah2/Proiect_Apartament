using System.ComponentModel.DataAnnotations;

namespace Proiect_Apartament.Models
{
    public class Inchiriere
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }

        [Display(Name = "Client")]

        public Member? Member { get; set; }
        public int? ApartamentID { get; set; }
        public Apartament? Apartament { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "CheckOut")]

        public DateTime CheckoutDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "CheckIn")]

        public DateTime CheckinDate { get; set; }
    }
}
