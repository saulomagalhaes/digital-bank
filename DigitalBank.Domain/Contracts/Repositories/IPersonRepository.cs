using DigitalBank.Domain.Entities;
using DigitalBank.Domain.FiltersDb;

namespace DigitalBank.Domain.Contracts.Repositories;

public interface IPersonRepository
{
    Task<Person> GetByIdAsync(int id);
    Task<ICollection<Person>> GetAllAsync();
    Task<Person> CreateAsync(Person person);
    Task UpdateAsync(Person person);
    Task DeleteAsync(Person person);
    Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb request);
}
