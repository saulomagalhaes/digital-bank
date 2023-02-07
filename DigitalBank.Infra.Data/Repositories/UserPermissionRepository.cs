using DigitalBank.Domain.Contracts.Repositories;
using DigitalBank.Domain.Entities;
using DigitalBank.Infra.Data.Context;

namespace DigitalBank.Infra.Data.Repositories;

public class UserPermissionRepository : IUserPermissionRepository
{
    private readonly AppDbContext _db;

    public UserPermissionRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task CreateAsync(UserPermission userPermission)
    {
        _db.UserPermissions.Add(userPermission);
        await _db.SaveChangesAsync();
    }
}
