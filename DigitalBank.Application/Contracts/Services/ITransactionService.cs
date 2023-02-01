using DigitalBank.Application.DTOs.Transaction;
using DigitalBank.Application.Services;

namespace DigitalBank.Application.Contracts.Services;

public interface ITransactionService
{
    Task<ResultService<ReadTransactionDto>> GetByIdAsync(int id);
    Task<ResultService<ICollection<ReadTransactionDto>>> GetAllAsync();
    Task<ResultService<ReadTransactionDto>> CreateAsync(CreateTransactionDto transactionDto);
    Task<ResultService> UpdateAsync(int id, UpdateTransactionDto transactionDto);
    Task<ResultService> DeleteAsync(int id);
}
