namespace SmartAptApi.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public Bill Bill { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.Now;
    }
}
