using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TuitionDb.Models.PplStudent;

namespace TuitionDb.Models
{
    public class Batch
    {
        [Key] public int BatchId { get; set; }
        public StudentBatchDay BatchDay { get; set; }
        public StudentBatchTime BatchTime { get; set; }
        public PplStudent PplStudents { get; set; }

        //nav props

        [ForeignKey("Batches")]

        public int SubjectId { get; set; }
        public BatchSubject BatchSubject { get; set; }

        [ForeignKey("Batches")]
        public int StaffId { get; set; }
        public PplStaff pplStaff { get; set; }

        [ForeignKey("Batches")]
        public int StudentId { get; set; }
        public PplStudent pplStudent { get; set; } 

        
    }
}
