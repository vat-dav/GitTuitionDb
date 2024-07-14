using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuitionDbv1.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Please enter a subject name"), MaxLength(30,ErrorMessage ="Please enter a subject between 1-30 characters"), Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        public ICollection<Batch> Batches { get; set; } = new List<Batch>();
    }
}
