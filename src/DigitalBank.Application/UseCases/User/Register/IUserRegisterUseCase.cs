using DigitalBank.Communication.Requests;
using DigitalBank.Communication.Responses;

namespace DigitalBank.Application.UseCases.User.Register;

public interface IUserRegisterUseCase
{
    Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);
}