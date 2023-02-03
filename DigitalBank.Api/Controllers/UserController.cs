using DigitalBank.Application.Contracts.Services;
using DigitalBank.Application.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBank.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAsync([FromBody] UserDto user)
    {
        var result = await _userService.GenerateTokenAsync(user);
        if (result.Success)
            return Ok(result.Data);
        if(result.Status == 400)
            return BadRequest(new { result.Message, result.Errors });
        return NotFound(new { result.Message, result.Errors });
    }
}
