using FarmAZ.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmAZ.Controllers{

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _service;

    public NotificationsController(INotificationService service) => _service = service;

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserNotifications(int userId)
    {
        var result = await _service.GetUserNotificationsAsync(userId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> SendNotification(int userId, string message)
    {
        var result = await _service.SendNotificationAsync(userId, message);
        return Ok(result);
    }

    [HttpPut("{id}/read")]
    public async Task<IActionResult> MarkAsRead(int id)
    {
        await _service.MarkAsReadAsync(id);
        return NoContent();
    }
}
}