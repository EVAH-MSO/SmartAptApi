using SmartAptApi.Models;

namespace SmartAptApi.Services
{
    public interface ITenantService
    {
        Task<List<Tenant>> GetAll();
        Task<Tenant?> GetById(int id);
        Task<Tenant> Create(Tenant tenant);
        Task<Tenant?> Update(int id, Tenant tenant);
        Task<bool> Delete(int id);
    }
}
