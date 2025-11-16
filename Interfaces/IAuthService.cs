using SmartAptApi.Models;

namespace SmartAptApi.Services
{
    public interface IAuthService
    {
        Task<User?> Authenticate(string email, string password);
        Task<User> Register(User user, string password);
        string GenerateJwt(User user);   // <-- add this
    }
}
