using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoatRental.Model
{
    public class Bokning
    {
        public int BokningID { get; set; }

        public int KundID { get; set; }

        [Range(1, 10, ErrorMessage = "{0} måste vara {1} - {2}")]
        [Required(ErrorMessage = "Fältet måste vara ifyllt.")]
        public int BåtplID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Fältet måste vara ifyllt.")]
        public DateTime StartDatum { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Fältet måste vara ifyllt.")]
        public DateTime SlutDatum { get; set; }
    }
}