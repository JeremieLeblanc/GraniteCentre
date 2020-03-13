using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteCentre.Models
{
    public class RightFitModelFr
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName("Address Email")]
        public string Email { get; set; }

        [DisplayName("Nom de compagnie")]
        public string Compagnie { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName("Numéro de téléphone")]
        public string Telephone { get; set; }

        public string RightFit1 { get; set; }
        public string RightFit2 { get; set; }
        public string RightFit3 { get; set; }
        public string RightFit4 { get; set; }
        public string RightFit5 { get; set; }
        public string RightFit6 { get; set; }
        public string RightFit7 { get; set; }
        public string RightFit8 { get; set; }

        [Required(ErrorMessage = "reCaptcha is required")]
        public string Captcha { get; set; }
    }
}
