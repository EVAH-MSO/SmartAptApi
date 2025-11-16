namespace SmartAptApi.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string ApartmentNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
