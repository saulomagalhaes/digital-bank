using DigitalBank.Application.Services.Token;
using DigitalBank.Domain.Entities;
using DigitalBank.Domain.Repositories.User;
using Microsoft.AspNetCore.Http;

namespace DigitalBank.Application.Services.LoggedInUser;

public class LoggedInUser : ILoggedInUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserReadOnlyRepository _userReadRepository;
    private readonly TokenController _tokenController;

    public LoggedInUser(IHttpContextAccessor httpContextAccessor, TokenController tokenController, IUserReadOnlyRepository userReadRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _tokenController = tokenController;
        _userReadRepository = userReadRepository;
    }

    public async Task<User> RecoverUser()
    {
        var authorization = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

        var token = authorization["Bearer".Length..].Trim();

        var userEmail = _tokenController.RecoverEmail(token);

        var user = await _userReadRepository.GetUserByEmail(userEmail);

        return user;
    }
}
