using System.ComponentModel.DataAnnotations;

namespace TuitionDb.Models
{
    public class ClassStudent
    {
        [Key] public int ClassStudentId { get; set; }

        public int ClassId { get; set; }
        public Class Classes { get; set; }
        public int StudentId { get; set; }
        public PplStudent Students { get; set; }

        ICollection<PplStudent>PplStudents { get; set; }
    }
}
