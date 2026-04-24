namespace FarmAZ.DTOs.Payment
{
    public class CreatePaymentDTO
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
    }
}