using FarmAZ.DTOs.Payment;
using FarmAZ.Entities;
using FarmAZ.Enums;
using FarmAZ.Repositories.Interfaces;
using FarmAZ.Services.Interfaces;


namespace FarmAZ.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repo;

        public PaymentService(IPaymentRepository repo) => _repo = repo;

        public async Task<PaymentResponseDto> CreatePaymentAsync(CreatePaymentDTO dto)
        {
            var payment = new Payment
            {
                OrderId = dto.OrderId,
                Amount  = dto.Amount,
                Status  = PaymentStatus.Paid,
                PaidAt  = DateTime.UtcNow
            };

            var created = await _repo.AddAsync(payment);
            return MapToDto(created);
        }

        public async Task<PaymentResponseDto> GetByOrderIdAsync(int orderId)
        {
            var payment = await _repo.GetByOrderIdAsync(orderId)
                ?? throw new KeyNotFoundException($"Payment for order {orderId} not found.");

            return MapToDto(payment);
        }

        private static PaymentResponseDto MapToDto(Payment p) => new()
        {
            Id      = p.Id,
            OrderId = p.OrderId,
            Amount  = p.Amount,
            Status  = p.Status.ToString(),
            PaidAt  = p.PaidAt
        };
    }
}