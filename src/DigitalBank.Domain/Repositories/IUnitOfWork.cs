namespace DigitalBank.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
