using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionDb.Models
{
    public class Batch
    {
        [Key] public int BatchId { get; set; }
        public string ClassDay { get; set; }
        public string ClassTime { get; set; }
        
        //nav props
        public BatchStudent ClassStudent { get; set; }

        [ForeignKey("Batch")]

        public int SubjectId { get; set; }
        public BatchSubject ClassSubject { get; set; }

        [ForeignKey("Batch")]
        public int StaffId { get; set; }
        public PplStaff PplStaff { get; set; }

        
    }
}
