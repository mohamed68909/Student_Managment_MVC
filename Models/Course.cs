using System.ComponentModel.DataAnnotations;

namespace Student_Managmet_MVC.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters.")]
        public string Name { get; set; }
        [Required]
        public int Credits { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Student>? Students { get; set; } 
    }
}
