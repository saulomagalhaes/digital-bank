using AutoMapper;
using DigitalBank.Application.Services.Cryptography;
using DigitalBank.Application.Services.Token;
using DigitalBank.Communication.Requests;
using DigitalBank.Communication.Responses;
using DigitalBank.Domain.Repositories;
using DigitalBank.Exceptions.ExceptionsBase;

namespace DigitalBank.Application.UseCases.User.Register;

public class UserRegisterUseCase : IUserRegisterUseCase
{
    private readonly IUserWriteOnlyRepository _userWriteRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PasswordEncrypter _passwordEncrypter;
    private readonly TokenController _tokenController;

    public UserRegisterUseCase(IUserWriteOnlyRepository userWriteRepository, IMapper mapper, IUnitOfWork unitOfWork, PasswordEncrypter passwordEncrypter)
    {
        _userWriteRepository = userWriteRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _passwordEncrypter = passwordEncrypter;
    }

    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<Domain.Entities.User>(request);
        user.Password = _passwordEncrypter.Encrypt(user.Password);

        await _userWriteRepository.Add(user);

        await _unitOfWork.Commit();

        var token = _tokenController.GenerateToken(user.Email);

        return new ResponseRegisterUserJson
        {
            Token = token,
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new UserRegisterValidator().Validate(request);

        if (!validator.IsValid)
        {
            var errorMessages = validator.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ValidationsErrorException(errorMessages);
        }
    }
}
