using System.ComponentModel.DataAnnotations;

namespace TuitionDb.Models
{
    public class PplParent
    {
        [Key] public int ParentId { get; set; }
        public string ParentName { get; set; }
        public string ParentAddress { get; set; }
        public int ParentPhone { get; set; }

        ICollection<PplStudent> pplStudents { get; set; }
        ICollection<ClassFees> ClassFees { get; set; }
    }
}
