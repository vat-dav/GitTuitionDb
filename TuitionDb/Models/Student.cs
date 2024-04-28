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
        Year0, Year1, Year2, Year3, Year4, Year5, Year6, Year7, Year8, Year9, Year10, Year11, Year12, Year13,
    }

    public enum StudentBatchDay
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday 
    }
    public enum StudentBatchTime
    {
        Batch_1530, Batch_1630, Batch_1730, Batch_1830, Batch_1930,
    }

    public enum PaymentMethod
    {
        BankTransfer, Cash, DirectDebit
    }

    public class Student
    {
        //Primary Key for models
        [Key] public int StudentId { get; set; }
        [Required(ErrorMessage ="Please enter a name"), MaxLength(30), Display(Name ="First Name")] //required for the user input
       public string StudentFirstName { get; set; }
        [Required(ErrorMessage = "Please enter a name"), MaxLength(30), Display(Name = "Last Name")] //required for the user input
        public string StudentLastName { get; set; }
        [RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics accepted."), Display(Name = "Phone No.")]//required for the user input
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
