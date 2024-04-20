using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionDbv1.Models
{
    public class BatchFee
    {
        [Key]
        public int FeeId { get; set; }

        [ForeignKey("BatchFee")]
        public int StudentId { get; set; }
        public Student Students { get; set; }
        [Required,Range(1, int.MaxValue, ErrorMessage = "Please Enter a Valid numeric value")]//required for the user input
        public int AmountToPay { get; set; }
        [Required]//required for the user input
        public bool Received { get; set; }

    }
}
