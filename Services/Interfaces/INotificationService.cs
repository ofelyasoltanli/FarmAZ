using FarmAZ.Entities;

namespace FarmAZ.Services.Interfaces{

public interface INotificationService
{
    Task<List<Notification>> GetUserNotificationsAsync(int userId);
    Task<Notification> SendNotificationAsync(int userId, string message);
    Task MarkAsReadAsync(int id);
}
}