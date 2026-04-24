using FarmAZ.Services.Interfaces;
using FarmAZ.Repositories.Interfaces;
using FarmAZ.Entities;
using FarmAZ.DTOs.Product;
using FarmAZ.Helpers;

namespace FarmAZ.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo) => _repo = repo;

        public async Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto, int userId)
        {
            var product = new Product
            {
                Name        = dto.Name,
                Description = dto.Description,
                Price       = dto.Price,
                City        = dto.City,
                Address     = dto.Address,
                Latitude    = dto.Latitude,
                Longitude   = dto.Longitude,
                ImageUrl    = dto.ImageUrl,
                UserId      = userId
            };

            await _repo.AddAsync(product);

          
            var created = await _repo.GetByIdAsync(product.Id)
                ?? throw new KeyNotFoundException("Product not found after creation.");

            return MapToDto(created);
        }

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return products.Select(MapToDto).ToList();
        }

        public async Task<ProductResponseDto> GetByIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Product with id {id} not found.");

            return MapToDto(product);
        }

        private static ProductResponseDto MapToDto(Product p) => new()
        {
            Id          = p.Id,
            Name        = p.Name,
            Description = p.Description,
            Price       = p.Price,
            City        = p.City,
            Address     = p.Address,
            Latitude    = p.Latitude,
            Longitude   = p.Longitude,
            ImageUrl    = p.ImageUrl,
            FarmerName  = p.User?.FullName ?? ""
        };
    
    public async Task<IEnumerable<ProductResponseDto>> GetNearbyAsync(
    double userLat, double userLng, double radiusKm)
{
    var products = await _repo.GetAllAsync();

    return products
        .Where(p => DistanceCalculator.CalculateDistance(
            userLat, userLng, p.Latitude, p.Longitude) <= radiusKm)
        .Select(MapToDto)
        .ToList();
}
    }
}