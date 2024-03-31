using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionDb.Models
{
    public class BatchFee
    {
        [Key] public int FeesId { get; set; }
        public int BatchId { get; set; }
        public BatchStudent ClassStudent { get; set; }

        [ForeignKey("BatchFee")]

        public int ParentId { get; set; }
        public PplParent PplParent { get; set; }

        [ForeignKey("BatchFee")]
        public int StudentId { get; set; }
        public PplStudent PplStudent { get; set; }

        public bool FeesPaid { get; set; }

        public PaymentMethod PayMethod { get; set; }

        public DateOnly PaymentDate { get; set; }


        public enum PaymentMethod
        {
            BankTransfer, Cash, DirectDebit
        }
    }
}
