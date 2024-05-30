using TuitionDbv1.Models;
using TuitionDb.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace TuitionDbv1.ViewModels
{
    public class ViewBatchStudents

    {
        [Key]
        public int ViewBatchStudentsId { get; set; }
        public Batch Batches { get; set; }
        public List<Student> Students { get; set; }
    }
}


