using FarmAZ.DTOs.Product;

namespace FarmAZ.Services.Interfaces{

public interface IProductService
{
    Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto, int userId);
    Task<List<ProductResponseDto>> GetAllAsync();
    Task<ProductResponseDto> GetByIdAsync(int id);

    Task<IEnumerable<ProductResponseDto>> GetNearbyAsync(double lat, double lng, double radiusKm);

}
}