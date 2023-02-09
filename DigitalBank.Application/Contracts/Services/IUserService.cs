using DigitalBank.Application.DTOs.User;
using DigitalBank.Application.Services;
using DigitalBank.Domain.Entities;

namespace DigitalBank.Application.Contracts.Services;

public interface IUserService
{
    Task<ResultService<TokenData>> GenerateTokenAsync(LoginUserDto userDto);
    Task<ResultService> RegisterAsync(RegisterUserDto userDto);
}
