using FarmAZ.Services.Interfaces;
using FarmAZ.Repositories.Interfaces;
using FarmAZ.Entities;
using FarmAZ.DTOs.Order;
using EntityOrderItem = FarmAZ.Entities.OrderItem;
namespace FarmAZ.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IProductRepository _productRepo;

        public OrderService(IOrderRepository repo, IProductRepository productRepo)
        {
            _repo = repo;
            _productRepo = productRepo;
        }

        public async Task<OrderResponseDto> CreateOrderAsync(CreatOrderDTO dto, int userId)
        {
            var order = new Order 
            { 
                UserId = userId,
                User = null!,                    
                Items = new List<EntityOrderItem>()
            };

            foreach (var item in dto.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                if (product == null) throw new Exception("Product not found");

                order.Items.Add(new EntityOrderItem
         {
    ProductId = product.Id,
    Quantity = item.Quantity
      });
            }

            await _repo.AddAsync(order);

            return new OrderResponseDto
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                Items = order.Items.Select(i => new OrderItemResponseDto
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product?.Name ?? string.Empty,  // null-safe
                    Quantity = i.Quantity
                }).ToList()
            };
        }

        public async Task<List<OrderResponseDto>> GetByUserAsync(int userId)
        {
            var orders = await _repo.GetByUserIdAsync(userId);
            return orders.Select(o => new OrderResponseDto
            {
                Id = o.Id,
                CreatedAt = o.CreatedAt,
                Items = o.Items.Select(i => new OrderItemResponseDto
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product?.Name ?? string.Empty,  // null-safe
                    Quantity = i.Quantity
                }).ToList()
            }).ToList();
        }
        
    }
}