using System.ComponentModel.DataAnnotations;

namespace TuitionDb.Models
{
    public class ClassFee
    {
        [Key] public int FeesId { get; set; }
        public int ClassId { get; set; }
        public ClassStudent ClassStudent { get; set; }

        public int ParentId { get; set; }
        public PplParent PplParent { get; set; }

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
