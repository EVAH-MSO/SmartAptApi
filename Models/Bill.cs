namespace SmartAptApi.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public bool Paid { get; set; } = false;
    }
}
