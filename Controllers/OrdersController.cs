using Microsoft.AspNetCore.Mvc;
using FarmAZ.DTOs.Order;
using FarmAZ.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FarmAZ.Controllers
{
[ApiController]
[Route("api/[controller]")]
[Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)=> _orderService=orderService;

[HttpGet]
public async Task<IActionResult> GetMyOrders()
{
    var claim = User.FindFirst(ClaimTypes.NameIdentifier);
    if (claim == null) return Unauthorized();
    var userId = int.Parse(claim.Value);
    
    var orders = await _orderService.GetByUserAsync(userId);
    return Ok(orders);
}

[HttpPost]
public async Task<IActionResult> Create(CreatOrderDTO dto)
{
    var claim = User.FindFirst(ClaimTypes.NameIdentifier);
    if (claim == null) return Unauthorized();
    var userId = int.Parse(claim.Value);
    
    var order = await _orderService.CreateOrderAsync(dto, userId);
    return Ok(order);
}

    }
}