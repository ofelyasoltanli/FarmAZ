using FarmAZ.Entities;

namespace FarmAZ.Repositories.Interfaces{

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<List<Order>> GetByUserIdAsync(int userId);
}
}