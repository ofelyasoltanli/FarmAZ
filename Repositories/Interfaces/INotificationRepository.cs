using FarmAZ.Entities;

namespace FarmAZ.Repositories.Interfaces{

public interface INotificationRepository
{
    Task<List<Notification>> GetByUserIdAsync(int userId);
    Task<Notification> AddAsync(Notification notification);
    Task MarkAsReadAsync(int id);
}
}