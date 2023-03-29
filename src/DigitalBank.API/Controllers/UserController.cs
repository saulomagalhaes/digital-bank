using DigitalBank.Application.UseCases.Login;
using DigitalBank.Application.UseCases.User.ChangePassword;
using DigitalBank.Application.UseCases.User.Register;
using DigitalBank.Communication.Requests;
using DigitalBank.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBank.API.Controllers;

public class UserController : DigitalBankController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegisterUser(
        [FromServices] IUserRegisterUseCase usecase, 
        [FromBody] RequestRegisterUserJson request
        )
    {
        var result = await usecase.Execute(request);
        return Created(string.Empty, result);
    }

    [HttpPut("change-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> ChangePassword(
        [FromServices] IChangePasswordUseCase usecase,
        [FromBody] RequestChangePasswordJson request
        )
    {
        await usecase.Execute(request);
        return NoContent();
    }
}
