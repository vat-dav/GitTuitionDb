using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuitionDbv1.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Please enter a valid subject name"), MaxLength(15), Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();
    }
}
