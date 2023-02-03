using DigitalBank.Application.DTOs.User;
using DigitalBank.Application.Services;

namespace DigitalBank.Application.Contracts.Services;

public interface IUserService
{
    Task<ResultService<dynamic>> GenerateTokenAsync(UserDto userDto);
}
