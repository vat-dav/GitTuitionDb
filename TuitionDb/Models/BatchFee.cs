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
        [Required(ErrorMessage = "Please enter a valid amount to pay"), MaxLength(5)]//required for the user input
        public int AmountToPay { get; set; }
        [Required]//required for the user input
        public bool Received { get; set; }

    }
}
