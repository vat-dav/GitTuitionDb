using System.ComponentModel.DataAnnotations;

namespace TuitionDb.Models
{
    public class BatchSubject
    {
        [Key] public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        ICollection<Batch> Batches { get; set; }
    }
}
