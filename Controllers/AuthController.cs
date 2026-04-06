using Microsoft.AspNetCore.Mvc;
using FarmAZ.DTOs.Auth;
using FarmAZ.Services.Interfaces;
using FarmAZ.DTOs;

namespace FarmAZ.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth)=> _auth=auth;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var user=await _auth.RegisterAsync(registerDTO);
            return Ok(new {user.Id, user.FullName, user.Email, user.Role});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token= await _auth.LoginAsync(loginDto);
            return Ok(new {Token=token});
        }
    }
}