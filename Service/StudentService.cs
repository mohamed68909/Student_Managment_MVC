using Microsoft.EntityFrameworkCore;
using Student_Managmet_MVC.Data;
using Student_Managmet_MVC.Models;
using Student_Managmet_MVC.Service.Interface;

namespace Student_Managmet_MVC.Service
{
    public class StudentService : IStudentService
    {
        private readonly AppsContext _context;

        public StudentService(AppsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.Include(s => s.Dapartmant).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.Include(s => s.Dapartmant)
                                          .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }

}
