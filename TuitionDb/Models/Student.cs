using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TuitionDb.Models;
using Microsoft.AspNetCore.Identity;

namespace TuitionDbv1.Models
{
    /*public class TuitionDbUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentSchool { get; set; }
    }
    */
    public enum StudentCourse
    {
        Cambridge, NCEA, IB
    }

    public enum StudentYearLevel
    {
        Year0 = 0, Year1 = 1, Year2 = 2, Year3 = 3, Year4 = 4, Year5 = 5, Year6 = 6, Year7 = 7, Year8 = 8, Year9 = 9, Year10 = 10, Year11 = 11, Year12 = 12, Year13 = 13,
    }

    public enum StudentBatchDay
    {
        Monday = 0, Tuesday = 1, Wednesday = 2, Thursday = 3, Friday = 4, Saturday = 5, Sunday = 6
    }
    public enum StudentBatchTime
    {
        Batch_1530 = 0, Batch_1630 = 1, Batch_1730 = 2, Batch_1830 = 3, Batch_1930 = 4,
    }

    public enum PaymentMethod
    {
        BankTransfer, Cash, DirectDebit
    }

    public class Student
    {
        //Primary Key for models
        [Key] public int StudentId { get; set; }
        [Required(ErrorMessage ="Please enter a name"), MaxLength(30)] //required for the user input
        public string StudentFirstName { get; set; }
        [Required(ErrorMessage = "Please enter a name"), MaxLength(30)] //required for the user input
        public string StudentLastName { get; set; }
        [Required]//required for the user input
        public string StudentPhone { get; set; } //add limit
        [Required]
        public string StudentSchool { get; set; }

        
     
        public StudentYearLevel YearLevel { get; set; }
        public StudentCourse Course { get; set; }
        public StudentBatchDay BatchDay { get; set; }
        public StudentBatchTime BatchTime { get; set; }
        public PaymentMethod PaymentType { get; set; }
        [Required(ErrorMessage = "Please enter a name"), MaxLength(30)] //required for the user input
        public string BillingAddress { get; set; }
        public DateOnly JoinDate { get; set; }



        //nav props-relations

        [ForeignKey("Student")]
      
        ICollection<BatchStudent> BatchStudents { get; set; }
 
    }
}
