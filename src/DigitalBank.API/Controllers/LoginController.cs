using DigitalBank.Application.UseCases.Login;
using DigitalBank.Communication.Requests;
using DigitalBank.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBank.API.Controllers;

public class LoginController : DigitalBankController
{
    [HttpPost]
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
