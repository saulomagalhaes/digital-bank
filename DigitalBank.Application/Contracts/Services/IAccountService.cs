using DigitalBank.Application.DTOs.Account;
using DigitalBank.Application.Services;

namespace DigitalBank.Application.Contracts.Services;

public interface IAccountService
{
    Task<ResultService<ReadAccountDto>> GetByIdAsync(int id);
    Task<ResultService<ICollection<ReadAccountDto>>> GetAllAsync();
    Task<ResultService<ReadAccountDto>> CreateAsync(CreateAccountDto accountDto);
    Task<ResultService> UpdateAsync(int id, UpdateAccountDto accountDto);
    Task<ResultService> DeleteAsync(int id);
}
