using FarmAZ.DTOs;
using FarmAZ.DTOs.Order;

namespace FarmAZ.Services.Interfaces{

public interface IOrderService
{
    Task<OrderResponseDto> CreateOrderAsync(CreatOrderDTO dto, int userId);
    Task<List<OrderResponseDto>> GetByUserAsync(int userId);
}
}