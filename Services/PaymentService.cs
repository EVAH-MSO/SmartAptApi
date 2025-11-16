using Microsoft.EntityFrameworkCore;
using SmartAptApi.Data;
using SmartAptApi.Models;

namespace SmartAptApi.Services
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAll();
        Task<Payment?> GetById(int id);
        Task<Payment> Create(Payment payment);
    }

    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext _context;
        public PaymentService(AppDbContext context) => _context = context;

        public async Task<List<Payment>> GetAll() => await _context.Payments.Include(p => p.Bill).ToListAsync();

        public async Task<Payment?> GetById(int id) => await _context.Payments.Include(p => p.Bill).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Payment> Create(Payment payment)
        {
            var bill = await _context.Bills.FindAsync(payment.BillId);
            if (bill != null) bill.Paid = true;

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
    }
}
