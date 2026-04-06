using FarmAZ.Data;
using FarmAZ.Entities;
using FarmAZ.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmAz.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)=> _context=context;

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetByUserIdAsync(int id)
        {
            return await _context.Orders
            .Include(o=>o.Items)
            .ThenInclude(i=>i.Product)
            .Where(o=>o.UserId==id)
            .ToListAsync();
        }
    }
}