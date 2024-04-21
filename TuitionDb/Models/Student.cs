using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TuitionDb.Models;
using Microsoft.AspNetCore.Identity;

namespace TuitionDbv1.Models
{
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
        BankTransfer = 0, Cash = 1, DirectDebit = 2
    }

    public class Student
    {
        //Primary Key for models
        [Key] public int StudentId { get; set; }
        [Required(ErrorMessage ="Please enter a name"), MaxLength(30), Display(Name ="First Name")] //required for the user input
       public string StudentFirstName { get; set; }
        [Required(ErrorMessage = "Please enter a name"), MaxLength(30), Display(Name = "Last Name")] //required for the user input
        public string StudentLastName { get; set; }
        [RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number"), Display(Name = "Phone No.")]//required for the user input
        public string StudentPhone { get; set; } //add limit
        [Required(ErrorMessage = "Please enter a school name under 30 characters"), MaxLength(30), Display(Name = "School")]//required for the user input
        public string StudentSchool { get; set; }


        [Required(ErrorMessage = "Please enter Year Level"), Display(Name = "Year Level")]//required for the user input
        public StudentYearLevel YearLevel { get; set; }
        [Required(ErrorMessage = "Please enter Course"), Display(Name = "Course")]//required for the user input
        public StudentCourse Course { get; set; }
        [Required(ErrorMessage = "Please enter Batch Day"), Display(Name = "Batch Day")]//required for the user input
        public StudentBatchDay BatchDay { get; set; }
        [Required(ErrorMessage = "Please enter Batch Time"), Display(Name = "Batch Time")]//required for the user input
        public StudentBatchTime BatchTime { get; set; }
        [Required(ErrorMessage = "Please enter Payment Type"), Display(Name = "Payment Type")]//required for the user input
        public PaymentMethod PaymentType { get; set; }
        [Required(ErrorMessage = "Please enter a concise address"), MaxLength(50), Display(Name = "Address")] //required for the user input
        public string BillingAddress { get; set; }
        [Required(ErrorMessage = "Please enter a date"), Display(Name = "Join Date")]//required for the user input
        public DateOnly JoinDate { get; set; }



        //nav props-relations
        
        ICollection<BatchFee> Fees { get; set; }
        ICollection<BatchStudent> BatchStudents { get; set; }
       
    }
}
