using DigitalBank.Communication.Requests;
using DigitalBank.Communication.Responses;

namespace DigitalBank.Application.UseCases.Login;

public interface ILoginUseCase
{
    Task<ResponseLoginJson> Execute(RequestLoginJson request);
}
