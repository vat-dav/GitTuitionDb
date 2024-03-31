using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionDb.Models
{
    public class BatchStudent
    {
        [Key] public int BatchStudentId { get; set; }
        public Batch Batches { get; set; }

        [ForeignKey("BatchStudent")]
        public int BatchId { get; set; }
        [ForeignKey("BatchStudent")]
        public int StudentId { get; set; }
        ICollection<PplStudent>PplStudents { get; set; }
    }
}
