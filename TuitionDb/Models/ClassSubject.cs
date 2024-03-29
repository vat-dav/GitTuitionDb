using System.ComponentModel.DataAnnotations;

namespace TuitionDb.Models
{
    public class ClassSubject
    {
        [Key] public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        ICollection<Class> Classes { get; set; }
    }
}
