namespace DigitalBank.Domain.Repositories.User;

public interface IUpdateOnlyRepository
{
    void Update(Entities.User user);
}
