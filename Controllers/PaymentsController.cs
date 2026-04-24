using FarmAZ.DTOs.Payment;
using FarmAZ.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmAZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentsController(IPaymentService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentDTO dto)
        {
            var result = await _service.CreatePaymentAsync(dto);
            return Ok(result);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var result = await _service.GetByOrderIdAsync(orderId);
            return Ok(result);
        }
    }
}