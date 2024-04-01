using System.ComponentModel.DataAnnotations;

namespace TuitionDbv1.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }

        ICollection<Batch> Batches { get; set; }
    }
}
