using System.ComponentModel.DataAnnotations;
using TuitionDb.Models;

namespace TuitionDbv1.Models
{
    public class Staff
    {
       
        [Key] public int StaffId { get; set; }

        [Required(ErrorMessage = "Please enter a name"),MaxLength(30)]//required for the user input
        public string StaffName { get; set; }
        [Required(ErrorMessage = "Please enter a description of staff"), MaxLength(30)]//required for the user input
        public string StaffDesc { get; set; }
        [Required(ErrorMessage = "Please enter a valid phone number"), MaxLength(10)]//required for the user input
        public string StaffPhone { get; set; }
        [Required(ErrorMessage = "Please enter a Staff position"), MaxLength(20)]
        public string StaffPosition { get; set; }

      
        //nav props

        ICollection<Batch> Batches { get; set; }
    }
}
