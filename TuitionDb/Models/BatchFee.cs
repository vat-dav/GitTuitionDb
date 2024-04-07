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
        
        public int AmountToPay { get; set; }
        public bool Received { get; set; }

    }
}
