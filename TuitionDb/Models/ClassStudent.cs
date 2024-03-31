using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionDb.Models
{
    public class ClassStudent
    {
        [Key] public int ClassStudentId { get; set; }

        
        public Class Classes { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }
        ICollection<PplStudent>PplStudents { get; set; }
    }
}
