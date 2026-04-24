using FarmAZ.Entities;
using FarmAZ.Repositories.Interfaces;
using FarmAZ.Services.Interfaces;

namespace FarmAZ.Services.Implementations{

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _repo;

    public NotificationService(INotificationRepository repo) => _repo = repo;

    public async Task<List<Notification>> GetUserNotificationsAsync(int userId) =>
        await _repo.GetByUserIdAsync(userId);

    public async Task<Notification> SendNotificationAsync(int userId, string message)
    {
        var notification = new Notification
        {
            UserId = userId,
            Message = message
        };
        return await _repo.AddAsync(notification);
    }

    public async Task MarkAsReadAsync(int id) =>
        await _repo.MarkAsReadAsync(id);
}
}