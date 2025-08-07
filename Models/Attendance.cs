using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Managmet_MVC.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [ForeignKey("Student")]
        
        public int StudentId { get; set; }
        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [Required]
        [DataType(DataType.Date)]

        public DateTime Date { get; set; }
        [Required]

        [Display(Name = "Is Present")]
        public bool IsPresent { get; set; }
        public Student? Student { get; set; } 
        public Course? Course { get; set; } 
    }
}
