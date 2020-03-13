using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteCentre.Models
{
    public class ContactModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        [DisplayName("Company Name")]
        public string Company { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [Required]
        public string Comments { get; set; }

        [Required(ErrorMessage = "reCaptcha is required")]
        public string Captcha { get; set; }
    }
}
