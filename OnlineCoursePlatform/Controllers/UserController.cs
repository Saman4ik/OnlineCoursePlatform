using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCoursePlatform.Helpers;
using OnlineCoursePlatform.Modellar;
using OnlineCoursePlatform.Repositorys;
using OnlineCoursePlatform.Services;

namespace OnlineCoursePlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;

    public UserController(IUnitOfWork unitOfWork, IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDto userDto)
    {
        var user = new User
        {
            Username = userDto.Username,
            Email = userDto.Email,
            PasswordHash = HashHelper.HashPassword(userDto.Password)
        };

        await _unitOfWork.Users.Add(user);
        await _emailService.SendEmailAsync(user.Email, "Verify your email", "Please verify your email.");

        return Ok(new { Message = "User registered successfully" });
    }
}
