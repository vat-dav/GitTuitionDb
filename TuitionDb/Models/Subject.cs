using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuitionDbv1.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; } // primary key

        [Required(ErrorMessage = "Please enter a subject name"), MaxLength(30,ErrorMessage ="Please enter a subject between 1-30 characters"), Display(Name = "Subject Name")]
        public string SubjectName { get; set; } // validation for max length 30 and required, display name is "Subject Name"

        public ICollection<Batch> Batches { get; set; } // links to the batches model
    }
}
