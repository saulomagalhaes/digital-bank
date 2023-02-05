using DigitalBank.Domain.Contracts.Authentication;

namespace DigitalBank.Api.Authentication;

public class CurrentUser : ICurrentUser
{
    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        var httpContext = httpContextAccessor.HttpContext;
        var claims = httpContext.User.Claims;

        if(claims.Any(x => x.Type == "id"))
        {
            var id = Convert.ToInt32(claims.First(x => x.Type == "id").Value);
            Id = id;
        }

        if (claims.Any(x => x.Type == "email"))
        {
            var email = claims.First(x => x.Type == "email").Value;
            Email = email;
        }

        if (claims.Any(x => x.Type == "permissions"))
        {
            var permissions = claims.First(x => x.Type == "permissions").Value;
            Permissions = permissions;
        }
    }
    public int Id { get ; set; }
    public string Email { get; set; }
    public string Permissions { get ; set ; }
}
