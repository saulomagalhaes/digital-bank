using DigitalBank.Domain.Contracts.Repositories;
using DigitalBank.Domain.Entities;
using DigitalBank.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Infra.Data.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _db;

    public TransactionRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        _db.Transactions.Add(transaction);
        await _db.SaveChangesAsync();
        return transaction;
    }

    public async Task DeleteAsync(Transaction transaction)
    {
        _db.Transactions.Remove(transaction);
        await _db.SaveChangesAsync();
    }

    public async Task<ICollection<Transaction>> GetAllAsync()
    {
        return await _db.Transactions.ToListAsync();
    }

    public async Task<Transaction> GetByIdAsync(int id)
    {
        return await _db.Transactions.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateAsync(Transaction transaction)
    {
        _db.Transactions.Update(transaction);
        await _db.SaveChangesAsync();
    }
}
