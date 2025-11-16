using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartAptApi.Data;
using SmartAptApi.Helpers;
using SmartAptApi.Models;
using System.Security.Cryptography;
using System.Text;

namespace SmartAptApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtHelper _jwt;

        public AuthService(AppDbContext context, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwt = new JwtHelper(jwtSettings);
        }

        // Authenticate user
        public async Task<User?> Authenticate(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            return user;
        }

        // Register new user
        public async Task<User> Register(User user, string password)
        {
            user.PasswordHash = HashPassword(password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Hash password using SHA256
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        // Verify password against hash
        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }

        // Generate JWT token
        public string GenerateJwt(User user)
        {
            return _jwt.GenerateToken(user);
        }
    }
}
