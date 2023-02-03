using DigitalBank.Application.Contracts.Services;
using DigitalBank.Application.DTOs.User;
using DigitalBank.Application.DTOs.Validations;
using DigitalBank.Domain.Contracts.Authentication;
using DigitalBank.Domain.Contracts.Repositories;

namespace DigitalBank.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDto userDto)
    {
        if (userDto == null)
            return ResultService.Fail<dynamic>("O objeto do usuário deve ser informado", 400);

        var result = new UserDtoValidator().Validate(userDto);
        if (!result.IsValid)
            return ResultService.RequestError<dynamic>("Problemas na validação", 400, result);

        var user = await _userRepository.GetUSerByEmailandPasswordAsync(userDto.Email, userDto.Password);
        if (user == null)
            return ResultService.Fail<dynamic>("Usuário ou senha inválidos", 404);
        return ResultService.Ok<dynamic>(_tokenGenerator.Generator(user), 200);
    }
}
