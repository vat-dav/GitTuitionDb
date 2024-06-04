using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionDbv1.Models
{
    public class Staff
    {
        public enum StaffPosition { Teacher, Admin, Cleaner }

        [Key]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Please enter a name below 30 characters"), MaxLength(30), Display(Name = "First Name")]
        public string StaffFirstName { get; set; }
        
        [Required(ErrorMessage = "Please enter a name below 30 characters"), MaxLength(30), Display(Name = "Last Name")]
        public string StaffLastName { get; set; }


        [EmailAddress, Display(Name = "Email")]
        public string StaffEmail { get; set; }

        [RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics are accepted."), Display(Name = "Phone No.")]
        public string StaffPhone { get; set; }

        [Required, Display(Name = "Staff Position")]
        public StaffPosition Positions { get; set; }

        
        public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

        [NotMapped]
        public string FullName => $"{StaffFirstName} {StaffLastName}";
    }
}
