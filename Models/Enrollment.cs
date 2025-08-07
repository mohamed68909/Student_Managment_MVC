using System.ComponentModel.DataAnnotations;

namespace Student_Managmet_MVC.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        public string? Grade { get; set; }
        public  Student? Student { get; set; }
        public  Course? Course { get; set; }

      
    }
}
