using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TuitionDbv1.Areas.Identity.Data
{
    public class TuitionDbUser : IdentityUser
    {        [RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics are accepted."), Display(Name = "Phone No.")]//required for the user input
        public string StaffPhone { get; set; }
    }
}
