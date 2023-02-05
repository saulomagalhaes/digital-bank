using DigitalBank.Domain.Contracts.Repositories;
using DigitalBank.Domain.Entities;
using DigitalBank.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<User> GetUSerByEmailandPasswordAsync(string email, string password)
    {
        return await _db.Users
            .Include(u => u.userPermissions)
            .ThenInclude(u => u.Permission)
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}
