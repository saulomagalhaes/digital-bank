using DigitalBank.Domain.Entities;

namespace DigitalBank.Domain.Contracts.Repositories;

public interface IPersonRepository
{
    Task<Person> GetByIdAsync(int id);
    Task<ICollection<Person>> GetAllAsync();
    Task UpdateAsync(Person person);
    Task DeleteAsync(Person person);
}
