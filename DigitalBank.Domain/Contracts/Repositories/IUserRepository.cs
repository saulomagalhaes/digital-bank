using DigitalBank.Domain.Entities;

namespace DigitalBank.Domain.Contracts.Repositories;

public interface IUserRepository
{
    Task<User> GetUSerByEmailandPasswordAsync(string email, string password);
}
