using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuitionDbv1.Models;

namespace TuitionDbv1.Models
{
    public class Batch
    {
        public enum StudentBatchDay
        {
            Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }
        public enum StudentBatchTime
        {
          [Display(Name ="3:30PM")] Batch_1530, [Display(Name = "4:30PM")] Batch_1630, [Display(Name = "5:30PM")] Batch_1730, [Display(Name = "6:30PM")] Batch_1830, [Display(Name = "7:30PM")] Batch_1930
        }

        [Key]
        public int BatchId { get; set; }
        [Required(ErrorMessage ="Please select a day"), Display(Name = "Batch Day")]
        public StudentBatchDay BatchDay { get; set; }
        [Required(ErrorMessage = "Please select a time"), Display(Name = "Batch Time")]
        public StudentBatchTime BatchTime { get; set; }

        public int SubjectId { get; set; }

        public Subject Subjects { get; set; }
   
        public int StaffId { get; set; }
        public Staff Staffs { get; set; }
        public ICollection<BatchStudent> BatchStudents { get; set; }

        [NotMapped]
        public string BatchDayTime => $"{BatchDay} {BatchTime}";
       
    }
}
