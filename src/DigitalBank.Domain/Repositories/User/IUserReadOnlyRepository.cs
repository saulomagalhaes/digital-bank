namespace DigitalBank.Domain.Repositories.User;

public interface IUserReadOnlyRepository
{
    Task<bool> UserExistsWithEmail(string email);
    Task<Entities.User> Login(string email, string password);
    Task<Entities.User> GetUserByEmail(string email);
    Task<Entities.User> GetUserById(int id);
}
