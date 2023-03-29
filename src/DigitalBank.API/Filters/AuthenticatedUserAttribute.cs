using DigitalBank.Application.Services.Token;
using DigitalBank.Communication.Responses;
using DigitalBank.Domain.Repositories.User;
using DigitalBank.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace DigitalBank.API.Filters;

public class AuthenticatedUserAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    private readonly TokenController _tokenController;
    private readonly IUserReadOnlyRepository _userReadRepository;

    public AuthenticatedUserAttribute(TokenController tokenController, IUserReadOnlyRepository userReadRepository)
    {
        _tokenController = tokenController;
        _userReadRepository = userReadRepository;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenInRequest(context);

            var email = _tokenController.RecoverEmail(token);

            var user = await _userReadRepository.GetUserByEmail(email);

            if (user == null)
            {
                throw new Exception();
            }
        }
        catch (SecurityTokenExpiredException)
        {
            TokenExpired(context);
        }
        catch 
        {
            UserUnauthorized(context);
        }
    }

    private string TokenInRequest(AuthorizationFilterContext context)
    {
        var authorization = context.HttpContext.Request.Headers["Authorization"].ToString();

        if (string.IsNullOrWhiteSpace(authorization))
        {
            throw new Exception();
        }

        return authorization["Bearer".Length..].Trim();
    }

    private void TokenExpired(AuthorizationFilterContext context)
    {
        context.Result = new UnauthorizedObjectResult( new ResponseErrorJson(ResourceErrorMessages.TOKEN_EXPIRADO));
    }

    private void UserUnauthorized(AuthorizationFilterContext context)
    {
        context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(ResourceErrorMessages.USUARIO_SEM_PERMISSAO));
    }
}
