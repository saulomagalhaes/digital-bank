using DigitalBank.Domain.Contracts.Repositories;
using DigitalBank.Domain.Entities;
using DigitalBank.Domain.FiltersDb;
using DigitalBank.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Infra.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _db;

    public PersonRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Person> GetByIdAsync(int id)
    {
        return await _db.People.FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<ICollection<Person>> GetAllAsync()
    {
        return await _db.People.ToListAsync();
    }
    public async Task<Person> CreateAsync(Person person)
    {
        _db.People.Add(person);
        await _db.SaveChangesAsync();
        return person;
    }
    public async Task UpdateAsync(Person person)
    {
        _db.Update(person);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Person person)
    {
        _db.Remove(person);
        await _db.SaveChangesAsync();
    }

    public async Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb request)
    {
        var people = _db.People.AsQueryable();
        if (!string.IsNullOrEmpty(request.Name))
           people = people.Where(p => p.Name.Contains(request.Name));

        return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<Person>, Person>(people, request);
    }
}
