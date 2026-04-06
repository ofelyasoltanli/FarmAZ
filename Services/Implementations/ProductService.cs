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

        public ProductService(IProductRepository repo)=> _repo=repo;

         public async Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto, int userId)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            City = dto.City,
            Address = dto.Address,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            ImageUrl = dto.ImageUrl,
            UserId = userId
        };
        await _repo.AddAsync(product);

        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            City = product.City,
            Address = product.Address,
            Latitude = product.Latitude,
            Longitude = product.Longitude,
            ImageUrl = product.ImageUrl,
            FarmerName = product.User?.FullName??""
        };
    }

      public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var products=await _repo.GetAllAsync();

            return products.Select(p=>new ProductResponseDto
            {
             Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            City = p.City,
            Address = p.Address,
            Latitude = p.Latitude,
            Longitude = p.Longitude,
            ImageUrl = p.ImageUrl,
            FarmerName = p.User?.FullName??""
        }).ToList();
        }

         public async Task<ProductResponseDto> GetByIdAsync(int id)
    {
        var p = await _repo.GetByIdAsync(id);
        if (p == null) throw new Exception("Product not found");

        return new ProductResponseDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            City = p.City,
            Address = p.Address,
            Latitude = p.Latitude,
            Longitude = p.Longitude,
            ImageUrl = p.ImageUrl,
            FarmerName = p.User?.FullName??""
        };
        }
    }
}