using AutoMapper;
using DigitalBank.Application.Contracts.Services;
using DigitalBank.Application.DTOs.Account;
using DigitalBank.Application.DTOs.Validations;
using DigitalBank.Domain.Contracts.Repositories;
using DigitalBank.Domain.Entities;

namespace DigitalBank.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public AccountService(IAccountRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ReadAccountDto>> CreateAsync(CreateAccountDto accountDto)
    {
        if (accountDto == null)
            return ResultService.Fail<ReadAccountDto>("O objeto da conta deve ser informado", 400);

        var result = new CreateAccountDtoValidator().Validate(accountDto);
        if (!result.IsValid)
            return ResultService.RequestError<ReadAccountDto>("Problemas na validação", 400, result);

        var person = _mapper.Map<Account>(accountDto);
        var data = await _accountRepository.CreateAsync(person);
        return ResultService.Ok(_mapper.Map<ReadAccountDto>(data), 201);
    }
    public async Task<ResultService> DeleteAsync(int id)
    {
        var account = await _accountRepository.GetByIdAsync(id);
        if (account == null)
            ResultService.Fail("Conta não encontrada", 404);

        await _accountRepository.DeleteAsync(account);
        return ResultService.Ok("Conta removida com sucesso", 204);
    }

    public async Task<ResultService<ICollection<ReadAccountDto>>> GetAllAsync()
    {
        var accounts = await _accountRepository.GetAllAsync();
        var data = _mapper.Map<ICollection<ReadAccountDto>>(accounts);
        return ResultService.Ok(data, 200);
    }

    public async Task<ResultService<ReadAccountDto>> GetByIdAsync(int id)
    {
        var account = await _accountRepository.GetByIdAsync(id);
        if (account == null)
            return ResultService.Fail<ReadAccountDto>("Conta não encontrada", 404);

        var data = _mapper.Map<ReadAccountDto>(account);
        return ResultService.Ok(data, 200);
    }

    public async Task<ResultService> UpdateAsync(int id, UpdateAccountDto accountDto)
    {
        if (accountDto == null)
            return ResultService.Fail("O objeto da conta deve ser informado", 400);

        var result = new UpdateAccountDtoValidator().Validate(accountDto);
        if (!result.IsValid)
            return ResultService.Ok("Problemas na validação", 400);

        var account = await _accountRepository.GetByIdAsync(id);
        if (account == null)
            return ResultService.Fail("Conta não encontrada", 404);

        account = _mapper.Map(accountDto, account);
        await _accountRepository.UpdateAsync(account);
        return ResultService.Ok("Conta atualizada com sucesso", 204);
    }
}
