using System.ComponentModel.DataAnnotations;
using TuitionDb.Models;

namespace TuitionDbv1.Models
{
    public class Staff
    {
       
        [Key] public int StaffId { get; set; }

        [Required]
        public string StaffName { get; set; }
        [Required]
        public string StaffDesc { get; set; }
        [Required]
        public string StaffPhone { get; set; }
        [Required]
        public string StaffPosition { get; set; }

        //public  { get; set; }

        //nav props

        ICollection<Batch> Batches { get; set; }
    }
}
