using Microsoft.EntityFrameworkCore;
using SmartAptApi.Data;
using SmartAptApi.Models;

namespace SmartAptApi.Services
{
    public interface IBillService
    {
        Task<List<Bill>> GetAll();
        Task<Bill?> GetById(int id);
        Task<Bill> Create(Bill bill);
        Task<Bill?> Update(int id, Bill bill);
        Task<bool> Delete(int id);
    }

    public class BillService : IBillService
    {
        private readonly AppDbContext _context;
        public BillService(AppDbContext context) => _context = context;

        public async Task<List<Bill>> GetAll() => await _context.Bills.Include(b => b.Tenant).ToListAsync();

        public async Task<Bill?> GetById(int id) => await _context.Bills.Include(b => b.Tenant).FirstOrDefaultAsync(b => b.Id == id);

        public async Task<Bill> Create(Bill bill)
        {
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill?> Update(int id, Bill bill)
        {
            var existing = await _context.Bills.FindAsync(id);
            if (existing == null) return null;

            existing.Amount = bill.Amount;
            existing.Description = bill.Description;
            existing.DueDate = bill.DueDate;
            existing.Paid = bill.Paid;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            if (bill == null) return false;
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
