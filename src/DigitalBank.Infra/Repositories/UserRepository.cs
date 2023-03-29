using DigitalBank.Domain.Entities;
using DigitalBank.Domain.Repositories.User;
using DigitalBank.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Infra.Repositories;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository, IUpdateOnlyRepository
{
    private readonly DigitalBankContext _context;

    public UserRepository(DigitalBankContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> Login(string email, string password)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
    }

    public void Update(User user)
    {
       _context.Users.Update(user);
    }

    public async Task<bool> UserExistsWithEmail(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email == email);
    }
}
