using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Managmet_MVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [ StringLength(50)]
        [Required]

        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]

       public DateTime DataOfBirth { get; set; }


    
        public int DapartmantId { get; set; }
        public  Dapartmant? Dapartmant { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public ICollection<Instructor>? Instructors { get; set; }

    }
}
