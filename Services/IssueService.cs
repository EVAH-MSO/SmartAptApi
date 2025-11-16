using Microsoft.EntityFrameworkCore;
using SmartAptApi.Data;
using SmartAptApi.Models;

namespace SmartAptApi.Services
{
    public interface IIssueService
    {
        Task<List<Issue>> GetAll();
        Task<Issue?> GetById(int id);
        Task<Issue> Create(Issue issue);
        Task<Issue?> UpdateStatus(int id, string status);
    }

    public class IssueService : IIssueService
    {
        private readonly AppDbContext _context;
        public IssueService(AppDbContext context) => _context = context;

        public async Task<List<Issue>> GetAll() => await _context.Issues.Include(i => i.Tenant).ToListAsync();

        public async Task<Issue?> GetById(int id) => await _context.Issues.Include(i => i.Tenant).FirstOrDefaultAsync(i => i.Id == id);

        public async Task<Issue> Create(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            return issue;
        }

        public async Task<Issue?> UpdateStatus(int id, string status)
        {
            var issue = await _context.Issues.FindAsync(id);
            if (issue == null) return null;
            issue.Status = status;
            await _context.SaveChangesAsync();
            return issue;
        }
    }
}
