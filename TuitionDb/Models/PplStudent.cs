using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionDb.Models
{
    public class PplStudent
    {
        [Key] public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        //[Required]
        public string StudentPhone { get; set; } //add limit
        public string StudentSchool { get; set; }

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

        public StudentBatchTime BatchTime { get; set; }
        public StudentBatchDay BatchDay { get; set; }
        public StudentYearLevel YearLevel { get; set; }
        public StudentCourse Course { get; set; }
        public DateOnly JoinDate { get; set; }

        //nav props-relations
        [ForeignKey("Student")]
        public int ParentId { get; set; } 
        public PplParent PplParent { get; set; }
        [ForeignKey("Student")]
        public int StaffId { get; set; }
        public PplStaff PplStaff { get; set; }
       
        
        ICollection<BatchFee> BatchFees { get; set; }
        public BatchStudent BatchStudents { get; set; }
    }

    

}
