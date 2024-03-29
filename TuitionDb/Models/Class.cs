using System.ComponentModel.DataAnnotations;

namespace TuitionDb.Models
{
    public class Class
    {
        [Key] public int ClassId { get; set; }
        public string ClassDay { get; set; }
        public string ClassTime { get; set; }
        
        //nav props
        
        public ClassStudent ClassStudent { get; set; }

        public int SubjectId { get; set; }
        public ClassSubject ClassSubject { get; set; }

        public int StaffId { get; set; }
        public PplStaff PplStaff { get; set; }
    }
}
