using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteCentre.Models
{
    public class ContactModelFr
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName("Address email")]
        public string Email { get; set; }

        [DisplayName("Nom de compagnie")]
        public string Compagnie { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName("Numéro de téléphone")]
        public string Telephone { get; set; }

        [Required]
        public string Commentaires { get; set; }

        [Required(ErrorMessage = "reCaptcha is required")]
        public string Captcha { get; set; }
    }
}
