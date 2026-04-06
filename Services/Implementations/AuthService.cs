using FarmAZ.Services.Interfaces;
using FarmAZ.Repositories.Interfaces;
using FarmAZ.Entities;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;
using FarmAZ.DTOs.Auth;
using FarmAZ.Helpers;

namespace FarmAZ.Services.Implementations{

public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;

        public AuthService(IUserRepository userRepository)=> _userRepo=userRepository;

        public async Task<User> RegisterAsync(RegisterDTO dto)
        {
            var existing =await _userRepo.GetByEmailAsync(dto.Email);
            if(existing!=null) throw new Exception("Email already existis");

            var user=new User
            {
                FullName=dto.FullName,
                Email=dto.Email,
                Role=dto.Role,
                PasswordHash=HashPassword(dto.Password)
            };

             await _userRepo.AddAsync(user);
             return user;
        }

       public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _userRepo.GetByEmailAsync(dto.Email);
        if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
            throw new Exception("Invalid credentials");

        return JwtHelper.GenerateToken(user);
    }

        private string HashPassword(string password)
{
    return BCrypt.Net.BCrypt.HashPassword(password);
}

private bool VerifyPassword(string password, string hash)
{
    return BCrypt.Net.BCrypt.Verify(password, hash);
}
    }
}
