using System.ComponentModel.DataAnnotations;

namespace Student_Managmet_MVC.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public OfficeAssignment? OfficeAssignment { get; set; }

        public ICollection<Course>? Courses { get; set; }

      

    }
}
