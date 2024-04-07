using System.ComponentModel.DataAnnotations;

namespace TuitionDbv1.Models
{
    public class BatchFee
    {
        [Key]
        public int FeeId { get; set; }

        public int StudentId { get; set; }
        public Student Students { get; set; }
        
        public decimal AmountToPay{ get; set; }
        public bool Received { get; set; }

    }
}
