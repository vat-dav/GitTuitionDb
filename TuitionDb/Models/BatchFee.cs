using Microsoft.Identity.Client;
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

        [Required,Range(1, int.MaxValue, ErrorMessage = "Please Enter a Valid numeric value"), Display(Name = "Fees")]//required for the user input
        [RegularExpression(@"^\d{1,4}$", ErrorMessage = "Please enter a positive numeric value and up to 4 digits.")]
        public int AmountToPay { get; set; }
        [Required]//required for the user input
        public bool Received { get; set; }

    }
}
