using FarmAZ.Entities;

namespace FarmAZ.Repositories.Interfaces{

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);  
}
}