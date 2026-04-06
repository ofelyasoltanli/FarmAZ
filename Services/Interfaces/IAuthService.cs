using FarmAZ.Entities;
using FarmAZ.DTOs.Auth;

namespace FarmAZ.Services.Interfaces{

public interface IAuthService
{
    Task<User> RegisterAsync(RegisterDTO dto);
    Task<string> LoginAsync(LoginDto dto);
}
}