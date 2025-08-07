using Microsoft.EntityFrameworkCore;
using Student_Managmet_MVC.Models;

namespace Student_Managmet_MVC.Data
{
    public class AppsContext : DbContext
    {
        public AppsContext(DbContextOptions<AppsContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Dapartmant> Dapartmant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Dapartmant>().HasData(
                new Dapartmant { Id = 1, Name = "Computer Science" },
                new Dapartmant { Id = 2, Name = "Information Systems" },
                new Dapartmant { Id = 3, Name = "Business" },
                new Dapartmant { Id = 4, Name = "Engineering" },
                new Dapartmant { Id = 5, Name = "Mathematics" }
            );

           
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Ahmed Ali", Email = "ahmed@example.com", DataOfBirth = new DateTime(2001, 5, 12), DapartmantId = 1 },
                new Student { Id = 2, Name = "Sara Mostafa", Email = "sara@example.com", DataOfBirth = new DateTime(2002, 7, 20), DapartmantId = 2 },
                new Student { Id = 3, Name = "Mohamed Tarek", Email = "mohamed@example.com", DataOfBirth = new DateTime(2000, 3, 15), DapartmantId = 3 },
                new Student { Id = 4, Name = "Nour Ali", Email = "nour@example.com", DataOfBirth = new DateTime(2001, 11, 8), DapartmantId = 4 },
                new Student { Id = 5, Name = "Youssef Hany", Email = "youssef@example.com", DataOfBirth = new DateTime(1999, 9, 25), DapartmantId = 5 }
            );

            
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "C#", Credits = 3 },
                new Course { Id = 2, Name = "ASP.NET Core", Credits = 4 },
                new Course { Id = 3, Name = "Databases", Credits = 3 },
                new Course { Id = 4, Name = "Algorithms", Credits = 3 },
                new Course { Id = 5, Name = "Operating Systems", Credits = 4 }
            );


            modelBuilder.Entity<Instructor>().HasData(
         new Instructor { Id = 1, Name = "Dr. Hadeer Mohamed", Email = "hadeer.mohamed@example.com", HireDate = new DateTime(2020, 1, 15) },
         new Instructor { Id = 2, Name = "Dr. Mostafa Hassan", Email = "mostafa.hassan@example.com", HireDate = new DateTime(2019, 6, 1) },
         new Instructor { Id = 3, Name = "Dr. Rania Ali", Email = "rania.ali@example.com", HireDate = new DateTime(2018, 9, 10) },
         new Instructor { Id = 4, Name = "Dr. Tarek Hamed", Email = "tarek.hamed@example.com", HireDate = new DateTime(2021, 3, 22) },
         new Instructor { Id = 5, Name = "Dr. Mona Adel", Email = "mona.adel@example.com", HireDate = new DateTime(2022, 7, 5) }
     );

            modelBuilder.Entity<OfficeAssignment>().HasData(
           new OfficeAssignment { InstructorId = 1, Location = "Room A101" },
           new OfficeAssignment { InstructorId = 2, Location = "Room B202" },
           new OfficeAssignment { InstructorId = 3, Location = "Room C303" },
           new OfficeAssignment { InstructorId = 4, Location = "Room D404" },
           new OfficeAssignment { InstructorId = 5, Location = "Room E505" }
       );



            
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, CourseId = 1, Grade = "A" },
                new Enrollment { Id = 2, StudentId = 2, CourseId = 2, Grade = "B" },
                new Enrollment { Id = 3, StudentId = 3, CourseId = 3, Grade = "C" },
                new Enrollment { Id = 4, StudentId = 4, CourseId = 4, Grade = "A" },
                new Enrollment { Id = 5, StudentId = 5, CourseId = 5, Grade = "B+" }
            );
                
          
            modelBuilder.Entity<Attendance>().HasData(
                new Attendance { Id = 1, StudentId = 1, CourseId = 1, Date = new DateTime(2025, 9, 1), IsPresent = true },
                new Attendance { Id = 2, StudentId = 2, CourseId = 2, Date = new DateTime(2025, 9, 1), IsPresent = false },
                new Attendance { Id = 3, StudentId = 3, CourseId = 3, Date = new DateTime(2025, 9, 1), IsPresent = true },
                new Attendance { Id = 4, StudentId = 4, CourseId = 4, Date = new DateTime(2025, 9, 1), IsPresent = true },
                new Attendance { Id = 5, StudentId = 5, CourseId = 5, Date = new DateTime(2025, 9, 1), IsPresent = false }
            );
        }
    }
}
