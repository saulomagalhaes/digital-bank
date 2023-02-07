using AutoMapper;
using DigitalBank.Application.Contracts.Services;
using DigitalBank.Application.DTOs.User;
using DigitalBank.Application.DTOs.Validations;
using DigitalBank.Application.Utils;
using DigitalBank.Domain.Contracts.Authentication;
using DigitalBank.Domain.Contracts.Repositories;
using DigitalBank.Domain.Entities;

namespace DigitalBank.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IUserPermissionRepository _userPermissionRepository;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator, IMapper mapper, IPersonRepository personRepository, IUserPermissionRepository userPermissionRepository, IAccountRepository accountRepository)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
        _personRepository = personRepository;
        _userPermissionRepository = userPermissionRepository;
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<dynamic>> GenerateTokenAsync(LoginUserDto userDto)
    {
        if (userDto == null)
            return ResultService.Fail<dynamic>("O objeto do usuário deve ser informado", 400);

        var result = new LoginUserDtoValidator().Validate(userDto);
        if (!result.IsValid)
            return ResultService.RequestError<dynamic>("Problemas na validação", 400, result);

        var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDto.Email, userDto.Password);
        if (user == null)
            return ResultService.Fail<dynamic>("Usuário ou senha inválidos", 404);
        return ResultService.Ok<dynamic>(_tokenGenerator.Generator(user), 200);
    }

    public async Task<ResultService> RegisterAsync(RegisterUserDto userDto)
    {
        if (userDto == null)
            return ResultService.Fail<dynamic>("O objeto do usuário deve ser informado", 400);

        var result = new RegisterUserDtoValidator().Validate(userDto);
        if (!result.IsValid)
            return ResultService.RequestError<dynamic>("Problemas na validação", 400, result);

        var user = _mapper.Map<User>(userDto);
        var userData = await _userRepository.CreateAsync(user);
        
        var person = _mapper.Map<Person>(userDto);
        var personData = await _personRepository.CreateAsync(person);

        var account = new Account()
        {
            Number = GenerateAccountNumber.GenerateRandomNumber(),
            Balance = 0.00m,
            PersonId = personData.Id,
        };

        await _accountRepository.CreateAsync(account);

        var userPermission = new UserPermission()
        {
            UserId = userData.Id,
            PermissionId = 2
        };

        await _userPermissionRepository.CreateAsync(userPermission);

        return ResultService.Ok("Usuario registrado com sucesso", 201);
    }
}
