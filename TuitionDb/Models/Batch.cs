using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TuitionDbv1.Models
{
    public class Batch
    {
        [Key] public int BatchId { get; set; }
        [Required, Display(Name = "Batch Day")]
        public StudentBatchDay BatchDay { get; set; }
        [Required, Display(Name = "Batch Time")]
        public StudentBatchTime BatchTime { get; set; }
        [Required(ErrorMessage = "Please enter batch notes"), MaxLength(400), Display(Name = "Batch Notes")]//required for the user input
        public string BatchNotes { get; set; }


        //nav props
    

    
        public int SubjectId { get; set; }
        public Subject Subjects { get; set; }
    
        

    
    public int StaffId { get; set; }
    public Staff Staffs { get; set; }
 
  
    


}
}
