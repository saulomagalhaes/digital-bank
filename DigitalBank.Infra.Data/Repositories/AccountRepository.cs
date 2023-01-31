using DigitalBank.Domain.Contracts.Repositories;
using DigitalBank.Domain.Entities;
using DigitalBank.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Infra.Data.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _db;

    public AccountRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Account> CreateAsync(Account account)
    {
        _db.Accounts.Add(account);
        await _db.SaveChangesAsync();
        return account;
    }

    public async Task DeleteAsync(Account account)
    {
        _db.Accounts.Remove(account);
        await _db.SaveChangesAsync();
    }

    public async Task<ICollection<Account>> GetAllAsync()
    {
        return await _db.Accounts.ToListAsync();
    }

    public async Task<Account> GetByIdAsync(int id)
    {
        return await _db.Accounts.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task UpdateAsync(Account account)
    {
        _db.Update(account);
        await _db.SaveChangesAsync();
    }
}
