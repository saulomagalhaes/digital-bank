using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBank.Api.Controllers;

[Authorize]
[ApiController]
public class BaseController : ControllerBase
{
    [NonAction]
    public bool ValidPermission(List<string> permissionUser, List<string> permissionNeeded)
    {
        return permissionNeeded.Any(x => permissionUser.Contains(x));
    }

    [NonAction]
    public IActionResult Forbidden()
    {
        var obj = new
        {
            message = "Usuário não autorizado"
        };

        return new ObjectResult(obj) { StatusCode = 403 };
    }
}
