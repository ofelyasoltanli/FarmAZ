using FarmAZ.Entities;
using FarmAZ.Repositories.Interfaces;
using FarmAZ.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmAZ.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) => _context = context;

   public async Task<User?> GetByEmailAsync(string email)
{
    return await _context.Users
        .FirstOrDefaultAsync(u => u.Email == email);  
}

public async Task<User?> GetByIdAsync(int id)
{
    return await _context.Users
        .FirstOrDefaultAsync(u => u.Id == id);  
}

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}