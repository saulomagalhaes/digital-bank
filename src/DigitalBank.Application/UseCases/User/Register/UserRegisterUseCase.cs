using DigitalBank.Communication.Requests;
using DigitalBank.Exceptions.ExceptionsBase;

namespace DigitalBank.Application.UseCases.User.Register;

public class UserRegisterUseCase
{
    public async Task Execute(RequestRegisterUserJson request)
    {
        Validate(request);

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
