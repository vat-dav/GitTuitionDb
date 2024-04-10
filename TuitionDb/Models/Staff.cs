using System.ComponentModel.DataAnnotations;
using TuitionDb.Models;

namespace TuitionDbv1.Models
{
    public class Staff
    {
        public enum StaffPosition{ Teacher = 1 , Admin = 2, Cleaner = 3
}
       
        [Key] public int StaffId { get; set; }

        [Required(ErrorMessage = "Please enter a name"),MaxLength(30)]//required for the user input
        public string StaffName { get; set; }
        [Required(ErrorMessage = "Please enter a description of staff"), MaxLength(30)]//required for the user input
        public string StaffEmail { get; set; }
        [Required(ErrorMessage = "Please enter a valid phone number"), MaxLength(10)]//required for the user input
        public string StaffPhone { get; set; }
        [Required]
        public StaffPosition Positions { get; set; }

      
        //nav props

        ICollection<Batch> Batches { get; set; }
    }
}
