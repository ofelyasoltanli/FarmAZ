using Microsoft.AspNetCore.Mvc;
using FarmAZ.DTOs.Product;
using FarmAZ.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using FarmAZ.Services.Implementations;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using FarmAZ.Helpers;

namespace FarmAZ.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)=> _productService=productService;

        [HttpGet]
        public async Task<IActionResult> GetAll()=>Ok (await _productService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)=> Ok(await _productService.GetByIdAsync(id));

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
         var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new UnauthorizedAccessException());            var product=await _productService.CreateProductAsync(dto, userId);
            return Ok(product);
        }

        [HttpGet("nearby")]
        public async Task<IActionResult> GetNearby(double userLat, double userLng, double radiusKm = 10)
        {
           var products = await _productService.GetAllAsync();
          var nearby = products
             .Where(p => DistanceCalculator.CalculateDistance(userLat, userLng, p.Latitude, p.Longitude) <= radiusKm)
             .ToList();

           return Ok(nearby);
        }
    }
}