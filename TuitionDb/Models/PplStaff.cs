using System.ComponentModel.DataAnnotations;

namespace TuitionDb.Models
{
    public class PplStaff
    {
        [Key] public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffDesc { get; set; }
        public string StaffPhone { get; set; }


        //nav props
        ICollection<PplStudent> PplStudents { get; set; }
        ICollection<Batch> Batches { get; set; }
    }
}
