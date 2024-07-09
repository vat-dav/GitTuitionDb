using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TuitionDbv1.Models;
using Microsoft.AspNetCore.Identity;

namespace TuitionDbv1.Models
{
    public enum StudentCourse
    {
        Cambridge, NCEA, IB
    }

    public enum StudentYearLevel
    {
        [Display(Name = "Year 0")] Year0, [Display(Name = "Year 1")] Year1, [Display(Name = "Year 2")] Year2, [Display(Name = "Year 3")] Year3, [Display(Name = "Year 4")] Year4, [Display(Name = "Year 5")] Year5, [Display(Name = "Year 6")] Year6, [Display(Name = "Year 7")] Year7, [Display(Name = "Year 8")] Year8, [Display(Name = "Year 9")] Year9, [Display(Name = "Year 10")] Year10, [Display(Name = "Year 11")] Year11, [Display(Name = "Year 12")] Year12, [Display(Name = "Year 13")] Year13
    }

   

    public enum PaymentMethod
    {
        [Display(Name = "Bank Transfer")] BankTransfer, Cash, [Display(Name = "Direct Debit")] DirectDebit
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
        
        [Required(ErrorMessage = "Please enter Payment Type"), Display(Name = "Payment Type")]//required for the user input
        public PaymentMethod PaymentType { get; set; }
        [Required(ErrorMessage = "Please enter a concise address"), MaxLength(50), Display(Name = "Address")] //required for the user input
        public string BillingAddress { get; set; }
        [Required(ErrorMessage = "Please enter a date"), Display(Name = "Join Date")]//required for the user input
        public DateOnly JoinDate { get; set; }
        ICollection<BatchStudent> BatchStudents { get; set; }


        [NotMapped]
        public string FullName => $"{StudentFirstName} {StudentLastName}";



    
       
    }
}
