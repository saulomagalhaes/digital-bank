using DigitalBank.Application.DTOs;
using DigitalBank.Application.DTOs.Person;
using DigitalBank.Application.Services;
using DigitalBank.Domain.Contracts.Repositories;
using DigitalBank.Domain.FiltersDb;

namespace DigitalBank.Application.Contracts.Services;

public interface IPersonService
{
    Task<ResultService<ReadPersonDto>> GetByIdAsync(int id);
    Task<ResultService<ICollection<ReadPersonDto>>> GetAllAsync();
    Task<ResultService<ReadPersonDto>> CreateAsync(CreatePersonDto personDto);
    Task<ResultService> UpdateAsync(int id, UpdatePersonDto personDto);
    Task <ResultService> DeleteAsync(int id);
    Task<ResultService<PagedBaseResponseDto<ReadPersonDto>>> GetPagedAsync(PersonFilterDb personFilterDb);
}
