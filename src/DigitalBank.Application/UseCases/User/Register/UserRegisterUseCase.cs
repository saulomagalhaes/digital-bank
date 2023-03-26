using DigitalBank.Communication.Requests;

namespace DigitalBank.Application.UseCases.User.Register;

public class UserRegisterUseCase
{
    public Task Execute(RequestRegisterUserJson request)
    {

    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new UserRegisterValidator().Validate(request);

        if (!validator.IsValid)
        {
            var errorMessages = validator.Errors.Select(error => error.ErrorMessage).ToList();
            throw new Exception();
        }
    }
}
