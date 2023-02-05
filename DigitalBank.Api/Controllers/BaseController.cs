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
            code = "permission_denied",
            message = "usuário não tem permissão para acessar esse recurso"
        };

        return new ObjectResult(obj) { StatusCode = 403 };
    }
}
