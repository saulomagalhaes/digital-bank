using DigitalBank.Domain.Entities;

namespace DigitalBank.Domain.Contracts.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    Task<User> CheckEmailExists(string email);
}
