using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TuitionDbv1.Areas.Identity.Data
{
    public class TuitionDbUser : IdentityUser
    {        [Required, RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics accepted. Eg.) '0221234567'"), Display(Name = "Phone No.")]//required for the user input
        public string AdminPhone { get; set; }

        [Required(ErrorMessage = "Please enter a first name"), MaxLength(50, ErrorMessage = "Please enter a first name between 1-50 characters"), Display(Name = "First Name")]
        public string AdminFirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name"), MaxLength(50, ErrorMessage = "Please enter a last name between 1-50 characters"), Display(Name = "Last Name")]
        public string AdminLastName { get; set; }
    }
}
