using FarmAZ.Data;
using FarmAZ.Entities;
using FarmAZ.Repositories.Interfaces; 
using Microsoft.EntityFrameworkCore;

namespace FarmAZ.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context) => _context = context;

        public async Task<Payment?> GetByOrderIdAsync(int orderId) =>
            await _context.Payments
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.OrderId == orderId);

        public async Task<Payment> AddAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
    }
}