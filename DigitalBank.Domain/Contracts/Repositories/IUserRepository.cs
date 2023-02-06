using DigitalBank.Domain.Entities;

namespace DigitalBank.Domain.Contracts.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
}
