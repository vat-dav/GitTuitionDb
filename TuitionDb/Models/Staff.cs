using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionDbv1.Models
{
    public class Staff
    {
        public enum StaffPosition { Teacher, Admin, Cleaner } // declares enum for the possible staff options to prevent user misentry

        [Key]
        public int StaffId { get; set; } // primary key
        
        [Required(ErrorMessage = "Please enter a first name"), MaxLength(50, ErrorMessage = "Please enter a first name between 1-50 characters"), Display(Name = "First Name")]
        public string StaffFirstName { get; set; } // staff first name with max length of 50, display name of "First Name", validation for required and max length.

        [Required(ErrorMessage = "Please enter a last name"), MaxLength(50, ErrorMessage = "Please enter a last name between 1-50 characters"), Display(Name = "Last Name")]
        public string StaffLastName { get; set; } // staff last name with max length of 50, display name of "Last Name", validation for required and max length.


        [Required,EmailAddress, Display(Name = "Email")]
        public string StaffEmail { get; set; } // staff email with emailaddress validation, display name of "Email", validation for required and email address.

        [RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics accepted. Eg.) '0221234567'"), Display(Name = "Phone No.")]
        public string StaffPhone { get; set; } // staff phone  with Regular Expression validation, display name of "Phone No.", validation for regular expression.

        [Required, Display(Name = "Staff Position")]
        public StaffPosition Positions { get; set; } // required enum with display name of Staff Position

        
        public virtual ICollection<Batch> Batches { get; set; } // link to the batches model

        [NotMapped, Display(Name="Staff Name")]
        public string FullName => $"{StaffFirstName} {StaffLastName}"; // makes a notmapped variable of FullName to be used in the front end.
    }
}
