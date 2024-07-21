using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuitionDbv1.Models;

namespace TuitionDbv1.Models
{
    public class Batch
    {

        public enum StudentBatchDay // enum to prevent user misentry, for the class day
        {
            Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }
        public enum StudentBatchTime // enum to prevent user misentry, for the class time, added display name attributes for user experience
        {
          [Display(Name ="3:30PM")] Batch_1530, [Display(Name = "4:30PM")] Batch_1630, [Display(Name = "5:30PM")] Batch_1730, [Display(Name = "6:30PM")] Batch_1830, [Display(Name = "7:30PM")] Batch_1930
        }

        [Key]
        public int BatchId { get; set; } // primary key for batch model

        [Required(ErrorMessage ="Please select a day"), Display(Name = "Batch Day")]
        public StudentBatchDay BatchDay { get; set; } // batchday with display name "Batch Day" for user experience

        [Required(ErrorMessage = "Please select a time"), Display(Name = "Batch Time")]
        public StudentBatchTime BatchTime { get; set; } // batchtime with display name "Batch Time" for user experience

        public int SubjectId { get; set; } // foreign key, relation to the subject table

        public Subject Subjects { get; set; } // link to the subject model
   
        public int StaffId { get; set; } // foreign key, relation to the staff table
        public Staff Staffs { get; set; } // link to the staff model
        public ICollection<BatchStudent> BatchStudents { get; set; } // link to the batchstudent table

        [NotMapped]
        public string BatchDayTime => $"{BatchDay} {BatchTime}"; // notmapped variable so doesn't write to database, makes variable that I can use in the front end index etc.
       
    }
}
