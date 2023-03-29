using DigitalBank.Application.Services.Cryptography;
using DigitalBank.Application.Services.Token;
using DigitalBank.Communication.Requests;
using DigitalBank.Communication.Responses;
using DigitalBank.Domain.Repositories.User;
using DigitalBank.Exceptions.ExceptionsBase;

namespace DigitalBank.Application.UseCases.Login;

public class LoginUseCase : ILoginUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly PasswordEncrypter _passwordEncrypter;
    private readonly TokenController _tokenController;

    public LoginUseCase(IUserReadOnlyRepository userReadOnlyRepository, PasswordEncrypter passwordEncrypter, TokenController tokenController)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _passwordEncrypter = passwordEncrypter;
        _tokenController = tokenController;
    }

    public async Task<ResponseLoginJson> Execute(RequestLoginJson request)
    {
        var encryptedPassword = _passwordEncrypter.Encrypt(request.Password);

        var user = await _userReadOnlyRepository.Login(request.Email, encryptedPassword);

        if (user == null)
        {
            throw new LoginInvalidException();
        }

        return new ResponseLoginJson
        {
            Name = user.Name,
            Token = _tokenController.GenerateToken(user.Email),
        };
    }
}
