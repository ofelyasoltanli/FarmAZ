using FarmAZ.Data;
using FarmAZ.Entities;
using FarmAZ.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmAZ.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)  // ← ? əlavə edildi
        {
            return await _context.Products
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}