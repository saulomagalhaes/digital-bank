using DigitalBank.Communication.Requests;

namespace DigitalBank.Application.UseCases.User.ChangePassword;

public interface IChangePasswordUseCase
{
    Task Execute(RequestChangePasswordJson request);
}
