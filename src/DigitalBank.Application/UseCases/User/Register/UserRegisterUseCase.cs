using AutoMapper;
using DigitalBank.Communication.Requests;
using DigitalBank.Domain.Repositories;
using DigitalBank.Exceptions.ExceptionsBase;

namespace DigitalBank.Application.UseCases.User.Register;

public class UserRegisterUseCase
{
    private readonly IUserWriteOnlyRepository _userWriteRepository;
    private readonly IMapper _mapper;

    public UserRegisterUseCase(IUserWriteOnlyRepository userWriteRepository, IMapper mapper)
    {
        _userWriteRepository = userWriteRepository;
        _mapper = mapper;
    }

    public async Task Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<Domain.Entities.User>(request);
        user.Password = "criptografar";

        await _userWriteRepository.Add(user);

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
