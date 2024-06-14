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
            Batch_1530, Batch_1630, Batch_1730, Batch_1830, Batch_1930
        }

        [Key]
        public int BatchId { get; set; }
        [Required]
        public StudentBatchDay BatchDay { get; set; }
        [Required]
        public StudentBatchTime BatchTime { get; set; }
        [Required, MaxLength(400), Range(5,400)]
        public string BatchNotes { get; set; }

        public int SubjectId { get; set; }
        public Subject Subjects { get; set; }
   
        public int StaffId { get; set; }
        public Staff Staffs { get; set; }
        public ICollection<BatchStudent> BatchStudents { get; set; }

        [NotMapped]
        public string BatchDayTime => $"{BatchDay} {BatchTime}";
       
    }
}
