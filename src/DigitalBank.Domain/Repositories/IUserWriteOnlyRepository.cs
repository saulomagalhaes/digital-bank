using DigitalBank.Domain.Entities;

namespace DigitalBank.Domain.Repositories;

public interface IUserWriteOnlyRepository
{
    Task Add(User user);
}
