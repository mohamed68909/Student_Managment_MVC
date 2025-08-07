using Student_Managmet_MVC.Models;

namespace Student_Managmet_MVC.Service.Interface
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Dapartmant>> GetAllAsync();
        Task<Dapartmant> GetByIdAsync(int id);
        Task CreateAsync(Dapartmant department);
        Task UpdateAsync(Dapartmant department);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }

}
