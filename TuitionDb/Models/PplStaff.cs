using System.ComponentModel.DataAnnotations;

namespace TuitionDb.Models
{
    public class PplStaff
    {
        [Key] public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string Staff { get; set; }
        public string StaffPhone { get; set; }


        //nav props
        ICollection<PplStudent> pplStudents { get; set; }
        ICollection<Class> Classes { get; set; }
    }
}
