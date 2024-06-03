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

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please Enter a Valid numeric value"), Display(Name = "Fees")]
        [RegularExpression(@"^\d{1,4}$", ErrorMessage = "Please enter a positive numeric value and up to 4 digits.")]
        public int AmountToPay { get; set; }

        [Required]
        public bool Received { get; set; }
    }
}

/*public class BatchStudent
{
    [Key]
    public int BatchStudentId { get; set; }
    public int BatchId { get; set; }
    public Batch Batch { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    [Required, Range(1, int.MaxValue)]
    public int AmountToPay { get; set; }
    [Required]
    public bool Received { get; set; }
}
*/