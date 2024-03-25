using System.ComponentModel.DataAnnotations;

namespace TuitionDb.Models
{
    public class ClassStudent
    {
        [Key] public int ClassStudentId { get; set; }

        public int ClassId { get; set; }
        public Classes Classes { get; set; }
        public int StudentId { get; set; }

        ICollection<PplStudent>PplStudents { get; set; }
    }
}
