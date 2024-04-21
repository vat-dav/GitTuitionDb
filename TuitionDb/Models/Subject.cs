using System.ComponentModel.DataAnnotations;

namespace TuitionDbv1.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Please enter a valid subject name"), MaxLength(15), Display(Name = "Subject Name")]//required for the user input
        public string SubjectName { get; set; }

        ICollection<Batch> Batches { get; set; }
    }
}
