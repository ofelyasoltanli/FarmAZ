using FarmAZ.DTOs.Payment;

namespace FarmAZ.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> CreatePaymentAsync(CreatePaymentDTO dto);
        Task<PaymentResponseDto> GetByOrderIdAsync(int orderId);
    }
}