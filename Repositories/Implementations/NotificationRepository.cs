using FarmAZ.Data;
using FarmAZ.Entities;
using FarmAZ.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmAZ.Repositories.Implementations{

public class NotificationRepository : INotificationRepository
{
    private readonly AppDbContext _context;

    public NotificationRepository(AppDbContext context) => _context = context;

    public async Task<List<Notification>> GetByUserIdAsync(int userId) =>
        await _context.Notifications
            .Where(n => n.UserId == userId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();

    public async Task<Notification> AddAsync(Notification notification)
    {
        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();
        return notification;
    }

    public async Task MarkAsReadAsync(int id)
    {
        var notification = await _context.Notifications.FindAsync(id);
        if (notification is not null)
        {
            notification.IsRead = true;
            await _context.SaveChangesAsync();
        }
    }
}
}