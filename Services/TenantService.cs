using Microsoft.EntityFrameworkCore;
using SmartAptApi.Data;
using SmartAptApi.Models;

namespace SmartAptApi.Services
{
    public class TenantService : ITenantService
    {
        private readonly AppDbContext _context;
        public TenantService(AppDbContext context) => _context = context;

        public async Task<List<Tenant>> GetAll() => await _context.Tenants.ToListAsync();

        public async Task<Tenant?> GetById(int id) => await _context.Tenants.FindAsync(id);

        public async Task<Tenant> Create(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();
            return tenant;
        }

        public async Task<Tenant?> Update(int id, Tenant tenant)
        {
            var existing = await _context.Tenants.FindAsync(id);
            if (existing == null) return null;

            existing.FullName = tenant.FullName;
            existing.ApartmentNumber = tenant.ApartmentNumber;
            existing.Email = tenant.Email;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null) return false;
            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
