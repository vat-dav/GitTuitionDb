using System.ComponentModel.DataAnnotations;

namespace TuitionDb.Models
{
    public class Classes
    {
        [Key] public int ClassId { get; set; }
        public string ClassDay { get; set; }
        public string ClassTime { get; set; }
        
        public int ClassStudentId { get; set; }
        public ClassStudent ClassStudent { get; set; }
        public int SubjectId { get; set; }
        public ClassSubject ClassSubject { get; set; }
    }
}
