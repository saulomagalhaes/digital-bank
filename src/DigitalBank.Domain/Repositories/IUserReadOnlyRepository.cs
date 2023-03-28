using DigitalBank.Domain.Entities;

namespace DigitalBank.Domain.Repositories;

public interface IUserReadOnlyRepository
{
    Task<bool> UserExistsWithEmail(string email);
    Task<User> Login(string email, string password);
}
