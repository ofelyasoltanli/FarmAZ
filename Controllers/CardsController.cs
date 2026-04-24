using FarmAZ.DTOs.Card;
using FarmAZ.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FarmAZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService) => _cardService = cardService;

        private int GetUserId() =>
            int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new UnauthorizedAccessException());

        [HttpGet]
        public async Task<IActionResult> GetCard()
            => Ok(await _cardService.GetCardAsync(GetUserId()));

        [HttpPost("items")]
        public async Task<IActionResult> AddItem(CreateCardItemDto dto)
            => Ok(await _cardService.AddItemAsync(GetUserId(), dto));

        [HttpDelete("items/{cardItemId}")]
        public async Task<IActionResult> RemoveItem(int cardItemId)
            => Ok(await _cardService.RemoveItemAsync(GetUserId(), cardItemId));

        [HttpDelete]
        public async Task<IActionResult> ClearCard()
        {
            await _cardService.ClearCardAsync(GetUserId());
            return NoContent();
        }
    }
}