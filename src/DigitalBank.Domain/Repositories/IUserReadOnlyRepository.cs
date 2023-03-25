namespace DigitalBank.Domain.Repositories;

public interface IUserReadOnlyRepository
{
    Task<bool> UserExistsWithEmail(string email);
}
