namespace FarmAZ.DTOs.Payment
{
    public class PaymentResponseDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = "";
        public DateTime PaidAt { get; set; }
    }
}