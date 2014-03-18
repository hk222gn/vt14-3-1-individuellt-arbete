using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoatRental.Model
{
    public class Kund
    {
        public int KundID { get; set; }

        [Required(ErrorMessage = "Fältet Namn måste vara ifyllt.")]
        [StringLength(30, ErrorMessage = "Fältets längd måste vara emellan 1 och 30 tecken.")]
        public string Namn { get; set; }

        [Required(ErrorMessage = "Fältet Address måste vara ifyllt.")]
        [StringLength(20, ErrorMessage = "Fältets längd måste vara emellan 1 och 20 tecken.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Fältet Telefonnummer måste vara ifyllt.")]
        [StringLength(16, ErrorMessage = "Fältets längd måste vara emellan 1 och 16 tecken.")]
        public string Telefonnummer { get; set; }

        [Required(ErrorMessage = "Fältet Mail måste vara ifyllt.")]
        [RegularExpression("[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}", ErrorMessage = "Inmatningen matchar inte en Mail adress.")]
        [StringLength(50, ErrorMessage = "Fältets längd måste vara emellan 5 och 50 tecken.")]
        public string E_Mail { get; set; }

        public int MedlemskapID { get; set; }
    }
}