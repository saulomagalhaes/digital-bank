using DigitalBank.Domain.Contracts.Repositories;
using DigitalBank.Domain.Entities;

namespace DigitalBank.Infra.Data.Repositories;

public class AccountRepository : IAccountRepository
{
    public Task<Account> CreateAsync(Account account)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Account account)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Account>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Account> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Account account)
    {
        throw new NotImplementedException();
    }
}
