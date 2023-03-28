using DigitalBank.Application.UseCases.User.Login;
using DigitalBank.Application.UseCases.User.Register;
using DigitalBank.Communication.Requests;
using DigitalBank.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBank.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegisterUser(
        [FromServices] IUserRegisterUseCase usecase, 
        [FromBody] RequestRegisterUserJson request
        )
    {
        var result = await usecase.Execute(request);
        return Created(string.Empty, result);
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(ResponseLoginJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(
        [FromServices] ILoginUseCase usecase,
        [FromBody] RequestLoginJson request
        )
    {
        var result = await usecase.Execute(request);
        return Ok(result);
    }
}
