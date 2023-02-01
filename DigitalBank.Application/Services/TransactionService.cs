using AutoMapper;
using DigitalBank.Application.Contracts.Services;
using DigitalBank.Application.DTOs.Transaction;
using DigitalBank.Application.DTOs.Validations;
using DigitalBank.Domain.Contracts.Repositories;
using DigitalBank.Domain.Entities;

namespace DigitalBank.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ReadTransactionDto>> CreateAsync(CreateTransactionDto transactionDto)
    {
        if (transactionDto == null)
            return ResultService.Fail<ReadTransactionDto>("O objeto da transação deve ser informado", 400);

        var result = new CreateTransactionDtoValidator().Validate(transactionDto);
        if (!result.IsValid)
            return ResultService.RequestError<ReadTransactionDto>("Problemas na validação", 400, result);

        var transaction = _mapper.Map<Transaction>(transactionDto);
        var data = await _transactionRepository.CreateAsync(transaction);
        return ResultService.Ok(_mapper.Map<ReadTransactionDto>(data), 201);
    }

    public async Task<ResultService> DeleteAsync(int id)
    {
        var transaction = await _transactionRepository.GetByIdAsync(id);
        if (transaction == null)
            return ResultService.Fail("Transação não encontrada", 404);

        await _transactionRepository.DeleteAsync(transaction);
        return ResultService.Ok("Transação removida com sucesso", 204);
    }

    public async Task<ResultService<ICollection<ReadTransactionDto>>> GetAllAsync()
    {
        var transactions = await _transactionRepository.GetAllAsync();
        var data = _mapper.Map<ICollection<ReadTransactionDto>>(transactions);
        return ResultService.Ok(data, 200);
    }

    public async Task<ResultService<ReadTransactionDto>> GetByIdAsync(int id)
    {
        var transaction = await _transactionRepository.GetByIdAsync(id);
        if (transaction == null)
            return ResultService.Fail<ReadTransactionDto>("Transação não encontrada", 404);

        var data = _mapper.Map<ReadTransactionDto>(transaction);
        return ResultService.Ok(data, 200);
    }

    public async Task<ResultService> UpdateAsync(int id, UpdateTransactionDto transactionDto)
    {
        if (transactionDto == null)
            return ResultService.Fail("O objeto da transação deve ser informado", 400);

        var result = new UpdateTransactionDtoValidator().Validate(transactionDto);
        if (!result.IsValid)
            return ResultService.RequestError("Problemas na validação", 400, result);

        var transaction = await _transactionRepository.GetByIdAsync(id);
        if (transaction == null)
            return ResultService.Fail<ReadTransactionDto>("Transação não encontrada", 404);

        transaction = _mapper.Map(transactionDto, transaction);
        await _transactionRepository.UpdateAsync(transaction);
        return ResultService.Ok("Transação atualizada com sucesso", 204);
    }
}
