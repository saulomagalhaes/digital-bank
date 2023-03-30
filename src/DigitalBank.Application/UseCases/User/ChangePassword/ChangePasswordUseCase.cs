using DigitalBank.Application.Services.Cryptography;
using DigitalBank.Application.Services.LoggedInUser;
using DigitalBank.Communication.Requests;
using DigitalBank.Domain.Entities;
using DigitalBank.Domain.Repositories;
using DigitalBank.Domain.Repositories.User;
using DigitalBank.Exceptions;
using DigitalBank.Exceptions.ExceptionsBase;

namespace DigitalBank.Application.UseCases.User.ChangePassword;

public class ChangePasswordUseCase : IChangePasswordUseCase
{
    private readonly IUserUpdateOnlyRepository _userUpdateRepository;
    private readonly IUserReadOnlyRepository _userReadRepository;
    private readonly ILoggedInUser _loggedInUser;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PasswordEncrypter _passwordEncrypter;
    public ChangePasswordUseCase(IUserUpdateOnlyRepository userUpdateRepository, ILoggedInUser loggedInUser, 
        IUserReadOnlyRepository userReadRepository, PasswordEncrypter passwordEncrypter, IUnitOfWork unitOfWork)
    {
        _userUpdateRepository = userUpdateRepository;
        _loggedInUser = loggedInUser;
        _userReadRepository = userReadRepository;
        _passwordEncrypter = passwordEncrypter;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(RequestChangePasswordJson request)
    {
        var loggedInUser = await _loggedInUser.RecoverUser();

        var user = await _userReadRepository.GetUserById(loggedInUser.Id);

        Validate(request, user);

        user.Password = _passwordEncrypter.Encrypt(request.NewPassword);

        _userUpdateRepository.Update(user);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestChangePasswordJson request, Domain.Entities.User user)
    {
        var validator = new ChangePasswordValidator();
        var result = validator.Validate(request);

        var currentPasswordEncrypted = _passwordEncrypter.Encrypt(request.CurrentPassword);

        if(user.Password != currentPasswordEncrypted)
        {
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("currentPassword", ResourceErrorMessages.SENHA_ATUAL_INVALIDA));
        }

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ValidationsErrorException(errorMessages);
        }
    }
}
