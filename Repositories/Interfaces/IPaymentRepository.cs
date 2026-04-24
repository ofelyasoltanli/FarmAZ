using FarmAZ.Entities;
namespace FarmAZ.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetByOrderIdAsync(int orderId);
        Task<Payment> AddAsync(Payment payment);
    }
}