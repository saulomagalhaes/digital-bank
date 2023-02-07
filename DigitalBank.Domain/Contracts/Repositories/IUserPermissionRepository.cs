using DigitalBank.Domain.Entities;

namespace DigitalBank.Domain.Contracts.Repositories;

public interface IUserPermissionRepository
{
    Task CreateAsync(UserPermission userPermission);
}
