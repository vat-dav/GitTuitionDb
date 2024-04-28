using System.ComponentModel.DataAnnotations;
using TuitionDb.Models;

namespace TuitionDbv1.Models
{
    public class Staff
    {
        public enum StaffPosition{ Teacher  , Admin , Cleaner
            }
       
        [Key] public int StaffId { get; set; }

        [Required(ErrorMessage = "Please enter a name below 60 characters"),MaxLength(60), Display(Name = "Full Name")]//required for the user input
        public string StaffName { get; set; }
        [EmailAddress, Display(Name = "Email")]//required for the user input
        public string StaffEmail { get; set; }
        [RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics are accepted."), Display(Name = "Phone No.")]//required for the user input
        public string StaffPhone { get; set; }
        [Required, Display(Name = "Staff Position")]
        public StaffPosition Positions { get; set; }

      
        //nav props

        ICollection<Batch> Batches { get; set; }
    }
}
