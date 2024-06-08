using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuitionDbv1.Models;

namespace TuitionDbv1.Models
{
    public class BatchStudent
    {
        [Key]
        public int BatchStudentId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Students { get; set; }

        [ForeignKey("Batch")]
        public int BatchId { get; set; }
        public Batch Batches { get; set; }

      
       
        

    }
}
