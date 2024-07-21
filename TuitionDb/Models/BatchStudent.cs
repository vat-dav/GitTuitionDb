using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuitionDbv1.Models;

namespace TuitionDbv1.Models
{
    public class BatchStudent
    {
        [Key]
        public int BatchStudentId { get; set; } // primary key - unique identifier

        [ForeignKey("Student")]
        public int StudentId { get; set; } // foreign key 
        public Student Students { get; set; } // links to the student model

        [ForeignKey("Batch")]
        public int BatchId { get; set; } // foreign key
        public Batch Batches { get; set; } // links to the batches model

      
    }
}
