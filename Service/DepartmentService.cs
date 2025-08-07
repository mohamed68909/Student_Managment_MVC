using Microsoft.EntityFrameworkCore;
using Student_Managmet_MVC.Data;
using Student_Managmet_MVC.Models;
using Student_Managmet_MVC.Service.Interface;

namespace Student_Managmet_MVC.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppsContext _context;

        public DepartmentService(AppsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dapartmant>> GetAllAsync()
        {
            return await _context.Dapartmant.ToListAsync();
        }

        public async Task<Dapartmant> GetByIdAsync(int id)
        {
            return await _context.Dapartmant.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task CreateAsync(Dapartmant department)
        {
            _context.Dapartmant.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Dapartmant department)
        {
            _context.Dapartmant.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var department = await _context.Dapartmant.FindAsync(id);
            if (department != null)
            {
                _context.Dapartmant.Remove(department);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Dapartmant.AnyAsync(d => d.Id == id);
        }
    }


}
