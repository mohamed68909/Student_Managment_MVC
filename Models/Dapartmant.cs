using Student_Managmet_MVC.Validtators;
using System.ComponentModel.DataAnnotations;

namespace Student_Managmet_MVC.Models
{
    public class Dapartmant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Department Name")]
        [Unique]
        public string Name { get; set; }
        
        public ICollection<Student>? Students { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public ICollection<Instructor>? Instructors { get; set; } 
    }
}