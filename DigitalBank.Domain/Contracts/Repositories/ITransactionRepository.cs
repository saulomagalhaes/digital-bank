using DigitalBank.Domain.Entities;

namespace DigitalBank.Domain.Contracts.Repositories;

public interface ITransactionRepository
{
    Task<Transaction> GetByIdAsync(int id);
    Task<ICollection<Transaction>> GetAllAsync();
    Task<Transaction> CreateAsync(Transaction transaction);
    Task UpdateAsync(Transaction transaction);
    Task DeleteAsync(Transaction transaction);
}
