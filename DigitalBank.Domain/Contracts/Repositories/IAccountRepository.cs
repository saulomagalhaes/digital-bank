using DigitalBank.Domain.Entities;

namespace DigitalBank.Domain.Contracts.Repositories;

public interface IAccountRepository
{
    Task<Account> GetByIdAsync(int id);
    Task<ICollection<Account>> GetAllAsync();
    Task<Account> CreateAsync(Account account);
    Task UpdateAsync(Account account);
    Task DeleteAsync(Account account);
}
