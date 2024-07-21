using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TuitionDbv1.Models;
using Microsoft.AspNetCore.Identity;

namespace TuitionDbv1.Models
{
    public enum StudentCourse // declares the Student course enum to prevent user misentry
    {
        Cambridge, NCEA, IB
    }

    public enum StudentYearLevel // declares the Student year level enum to prevent user misentry, with display names to make it more user friendly
    {
        [Display(Name = "Year 0")] Year0, [Display(Name = "Year 1")] Year1, [Display(Name = "Year 2")] Year2, [Display(Name = "Year 3")] Year3, [Display(Name = "Year 4")] Year4, [Display(Name = "Year 5")] Year5, [Display(Name = "Year 6")] Year6, [Display(Name = "Year 7")] Year7, [Display(Name = "Year 8")] Year8, [Display(Name = "Year 9")] Year9, [Display(Name = "Year 10")] Year10, [Display(Name = "Year 11")] Year11, [Display(Name = "Year 12")] Year12, [Display(Name = "Year 13")] Year13
    }

   

    public enum PaymentMethod // declares the Student paymentmethod enum to prevent user misentry, with displayname attribute to make it more user friendly
    {
        [Display(Name = "Bank Transfer")] BankTransfer, Cash, [Display(Name = "Direct Debit")] DirectDebit
    }

    public class Student
    {
    
        [Key] public int StudentId { get; set; }     // primary Key 
        [Required(ErrorMessage ="Please enter a first name"), MaxLength(50, ErrorMessage ="Please enter a first name between 1-50 characters"), Display(Name ="First Name")] 

       public string StudentFirstName { get; set; } // student first name with max length of 50, display name of "First Name", validation for required and max length.
        [Required(ErrorMessage = "Please enter a last name"), MaxLength(50, ErrorMessage = "Please enter a last name between 1-50 characters"), Display(Name = "Last Name")] //required for the user input
        public string StudentLastName { get; set; }  // student last name with max length of 50, display name of "Last Name", validation for required and max length.

        [Required(ErrorMessage ="Please enter a phone number")][RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics accepted. Eg.) '0221234567'"), Display(Name = "Phone No.")]//required for the user input
        public string StudentPhone { get; set; } // student/student's parent phone  with Regular Expression validation, display name of "Phone No.", validation for regular expression.

        [Required(ErrorMessage = "Please enter a school name."), MaxLength(50, ErrorMessage = "Please enter a valid school name upto 50 characters"), Display(Name = "School")]//required for the user input
        public string StudentSchool { get; set; } // students school with max length of 50, display name of "School", validation for required and Max length.


        [Required(ErrorMessage = "Please enter Year Level"), Display(Name = "Year Level")]
        public StudentYearLevel YearLevel { get; set; } // required enum for students year level

        [Required(ErrorMessage = "Please enter Course"), Display(Name = "Course")]
        public StudentCourse Course { get; set; } // required enum for the students course
        
        [Required(ErrorMessage = "Please enter Payment Type"), Display(Name = "Payment Type")]
        public PaymentMethod PaymentType { get; set; } // required enum for the students payment type

        [Required(ErrorMessage = "Please enter an address"), MaxLength(100, ErrorMessage ="Please enter an address upto 100 characters"), Display(Name = "Address")]
        public string BillingAddress { get; set; } // required enum for the students/parents billing address

        [Required(ErrorMessage = "Please enter a date"), Display(Name = "Join Date")]
        public DateOnly JoinDate { get; set; } // required date with front end validation, display name "Join Date"
        ICollection<BatchStudent> BatchStudents { get; set; } // links to the BatchStudents model


        [NotMapped, Display(Name = "Student Name")]
        public string FullName => $"{StudentFirstName} {StudentLastName}"; // makes a notmapped variable of FullName to be used in the front end.





    }
}
