using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;//dbl check

namespace TuitionDbv1.Models
{
    public class BatchStudent
    {
        [Key]
        public int BatchStudentId { get; set; }

        [ForeignKey("BatchStudent")]

        Student Students { get; set; }
        public int StudentId { get; set; }

        Batch Batches { get; set; }
        public int BatchId { get; set; }
    }
}
